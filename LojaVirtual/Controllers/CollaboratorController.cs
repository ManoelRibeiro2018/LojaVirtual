using LojaVirtual.InputModel;
using LojaVirtual.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController()
        {
        }
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastar([FromBody] CollaboratorInputModel model)
        {
            var collaborato =  _collaboratorService.Insert(model);
            return View(collaborato);
        }

        [HttpGet]
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
