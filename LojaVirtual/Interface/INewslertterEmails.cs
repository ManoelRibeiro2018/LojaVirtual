using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Interface
{
    public interface INewslertterEmails
    {
        void Salvar(NewslertterEmail newslertterEmail);

        IEnumerable<NewslertterEmail> newslertterEmails();
    }
}
