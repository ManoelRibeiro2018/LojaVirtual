using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewslertterEmailRepository : INewslertterEmails
    {
        private readonly LojaVirtualContext _lojaVirtualContext;
        public NewslertterEmailRepository(LojaVirtualContext lojaVirtualContext)
        {
            _lojaVirtualContext = lojaVirtualContext;
        }       

        public void Salvar(NewslertterEmail newslertterEmail)
        {
            _lojaVirtualContext.NewslertterEmails.Add(newslertterEmail);
        }
        public IEnumerable<NewslertterEmail> newslertterEmails()
        {
            return _lojaVirtualContext.NewslertterEmails.ToList();
        }
    }
}
