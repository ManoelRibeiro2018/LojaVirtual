using LojaVirtual.Interface;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
   public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Cliente Login(string Email, string Senha);

    }
}
