using LojaVirtual.Libraries;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Interface;
using LojaVirtual.ViewModel;
using LojaVirtual.InputModel;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using LojaVirtual.Service;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly INewslertterEmails _repositoryNewslertterEmail;
        private readonly LoginService _loginService;
        public HomeController(IUserService userService, INewslertterEmails newslertter, LoginService loginService)
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


        [HttpGet]
        public IActionResult Panel()
        {
            var login = _loginService.GetSessionClient();
            if (login != null)
            {
                return new ContentResult { Content = "Logado!" };
            }
            return new ContentResult { Content = "Não Logado!" };
        }


        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
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
