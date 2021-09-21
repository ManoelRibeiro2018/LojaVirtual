using LojaVirtual.Database;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LojaVirtualContext _lojaVirtualContext;
        public ClienteRepository(LojaVirtualContext lojaVirtualContext)
        {
            _lojaVirtualContext = lojaVirtualContext;
        }
        public void Atualizar(int id)
        {
            _lojaVirtualContext.Update(id);
            _lojaVirtualContext.SaveChanges();
        }

        public int Cadastar(Cliente cliente)
        {
            _lojaVirtualContext.Clientes.Add(cliente);
            _lojaVirtualContext.SaveChanges();
            return cliente.Id;
        }

        public void Deletar(int id)
        {
            var cliente = ObterCliente(id);
            _lojaVirtualContext.Remove(cliente);
            _lojaVirtualContext.SaveChanges();
        }

        public Cliente Login(string Email, string Senha)
        {
           return _lojaVirtualContext.Clientes.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
        }

        public Cliente ObterCliente(int id)
        {
            return _lojaVirtualContext.Clientes.Find(id);
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            return _lojaVirtualContext.Clientes.ToList();
        }
    }
}
