using LojaVirtual.Filter;
using LojaVirtual.InputModel;
using LojaVirtual.Interface;
using LojaVirtual.Libraries;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interface;
using LojaVirtual.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly INewslertterEmails _repositoryNewslertterEmail;
        private readonly ILoginService _loginService;
        public HomeController(IUserService userService, INewslertterEmails newslertter, ILoginService loginService)
        {
            _userService = userService;
            _repositoryNewslertterEmail = newslertter;
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            //var user = new Cliente()
            //{
            //    Cpf = Faker.RandomNumber.Next(11, 11).ToString(),
            //    DataNascimento = DateTime.Now,
            //    Email = "manoel@gmail.com",
            //    Nome = "manoel",
            //    Role = "adm",
            //    Sexo = "Masculino",
            //    Telefone = Faker.RandomNumber.Next(11, 11).ToString(),
            //    Senha = "manoel",               

            //};
            //_userService.Insert(user);
            return View();
        }

        [Authorize]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarEmailPromocao([FromForm] NewslertterEmail newslertterEmail)
        {
            if (ModelState.IsValid)
            {
                _repositoryNewslertterEmail.Salvar(newslertterEmail);
                TempData["MSG"] = "Fique atento aos seus emails :)";
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return View(nameof(Index));
            }
        }
        public IActionResult ContatoAcao([FromForm] Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                }
                else
                {
                    ViewData["MSG_E"] = "è necessário preencher todas as informações";
                }

            }
            catch (Exception)
            {
                ViewData["MSG_E"] = "Opss... erro ao enviar a mensagem, tente de novo mais tarde!!!";
                //TODO - implementar log
            }

            return View("Contato");

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login([FromForm] LoginInputModel login)
        {
            var user = _userService.Login(login.Email, login.Password);
            if (user != null)
            {
                _loginService.Login(user);
                return RedirectToAction(nameof(Panel));
            }
            return RedirectToAction("Index");
        }

        [ClientAuthorize]
        [HttpGet]
        public IActionResult Panel()
        {
            return new ContentResult { Content = "Negado" };
        }


        [HttpPost]
        public IActionResult CadastroCliente([FromForm] User cliente)
        {
            if (ModelState.IsValid)
            {
                _userService.Insert(cliente);
                TempData["MSG-S"] = "Cadastro do sucesso";
                return RedirectToAction(nameof(Cadastro));
            }
            return View(nameof(Cadastro));
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Carrinho()
        {
            return View();
        }
    }
}
