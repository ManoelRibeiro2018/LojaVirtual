using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Visualizar()
        {
            return View(GetProduto());
        }
        public Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Celular",
                Descricao = "s10",
                Valor = 2000
            };
        }
    }
}
