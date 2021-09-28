using LojaVirtual.Interface;
using LojaVirtual.Models;

namespace LojaVirtual.Repository.Interface
{
    public interface ICollaboratorRepository : IGenericRepository<Collaborator>, ILogin<Collaborator>
    {

    }
}
