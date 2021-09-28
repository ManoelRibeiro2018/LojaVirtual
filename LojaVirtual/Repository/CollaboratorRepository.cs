
using LojaVirtual.Database;
using LojaVirtual.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly LojaVirtualContext _context;

        public CollaboratorRepository(LojaVirtualContext lojaVirtualContext)
        {
            _context = lojaVirtualContext;
        }
        public Collaborator Insert(Collaborator Entity)
        {
            _context.Collaborators.Add(Entity);
            _context.SaveChanges();
            return Entity;
        }
        public void Update(int id, Collaborator Entity)
        {
            _context.Collaborators.Update(Entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var collaborator = Find(id);
            _context.Collaborators.Remove(collaborator);
            _context.SaveChanges();
        }

        public Collaborator Find(int id)
        {
           return _context.Collaborators.SingleOrDefault(c => c.Id == id);
        }

        public List<Collaborator> FindAll()
        {
            return _context.Collaborators.ToList();
        }

      
        public Collaborator Login(string email, string senha)
        {
            throw new NotImplementedException();
        }

      
    }
}
