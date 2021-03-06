using LojaVirtual.Database;
using LojaVirtual.Interface;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository :  IClienteRepository
    {
        private readonly LojaVirtualContext _lojaVirtualContext;
        public ClienteRepository(LojaVirtualContext lojaVirtualContext)
        {
            _lojaVirtualContext = lojaVirtualContext;
        }    
        public User Insert(User Entity)
        {
            _lojaVirtualContext.Clientes.Add(Entity);
            _lojaVirtualContext.SaveChanges();
            return Entity;
        }
        public void Update(int id, User Entity)
        {
            _lojaVirtualContext.Update(id);
            _lojaVirtualContext.SaveChanges();
        }

        public User Login(string Email, string Password)
        {
           return _lojaVirtualContext.Clientes.Where(m => m.Email == Email && m.Password == Password).FirstOrDefault();
        }


        public void Delete(int id)
        {
            var cliente = Find(id);
            _lojaVirtualContext.Remove(cliente);
            _lojaVirtualContext.SaveChanges();
        }

        public User Find(int id)
        {
            return _lojaVirtualContext.Clientes.SingleOrDefault(c => c.Id == id);
        }


        public List<User> FindAll()
        {
            return _lojaVirtualContext.Clientes.ToList();
        }
    }
}
