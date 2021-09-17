using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
   public interface IClienteRepository 
    {
        Cliente Login(string Email, string Senha);
        int Cadastar(Cliente cliente);
        void Atualizar(int id);
        void Deletar(int id);
        Cliente ObterCliente(int id);
        IEnumerable<Cliente> ObterTodosClientes();

    }
}
