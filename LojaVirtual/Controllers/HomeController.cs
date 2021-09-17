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

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService  _userService;
        private readonly INewslertterEmails _repositoryNewslertterEmail;
        public HomeController(IUserService userService, INewslertterEmails newslertter)
        {
            _userService = userService;
            _repositoryNewslertterEmail = newslertter;
        }

        public IActionResult Index()
        {
            var user = new Cliente()
            {
                Cpf = Faker.RandomNumber.Next(11, 11).ToString(),
                DataNascimento = DateTime.Now,
                Email = "manoel@gmail.com",
                Nome = "manoel",
                Role = "adm"
                
            };
            return View();
        }

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
        public IActionResult Login([FromForm] Cliente cliente)
        {
            if (!String.IsNullOrEmpty(cliente.Email))
            {
                HttpContext.Session.Set("Id", new byte[] {10});
                HttpContext.Session.SetString("Cpf", "12345678912");
                return new ContentResult {Content = "Logado!" };
            }
            else
            {
                return new ContentResult { Content = "Erro!" };
               
            }
        }


        [HttpGet]
        public IActionResult Panel()
        {
            byte[] usuarioId;
            if (HttpContext.Session.TryGetValue("Id", out usuarioId))
            {
                return new ContentResult { Content = "Usuario: " + usuarioId[0] + ". Logado!" };
            }
            else
            {
                return new ContentResult { Content = "Não Logado!" };
            }
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
