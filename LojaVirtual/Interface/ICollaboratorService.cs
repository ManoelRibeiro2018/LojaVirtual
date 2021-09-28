using LojaVirtual.Models;
using LojaVirtual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Interface
{
    public interface ICollaboratorService
    {
        LoginViewModel Login(string email, string password);
        int Insert(Collaborator collaborator);
        void Update(int id, Collaborator collaborator);
        void Delete(int id);
    }
}
