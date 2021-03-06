using LojaVirtual.Models;
using LojaVirtual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Interface
{
    public interface IUserService
    {
        LoginViewModel Login(string email, string password);
        int Insert(User cliente);
        void Update(int id, User cliente);
        void Delete(int id);       
        
    }
}
