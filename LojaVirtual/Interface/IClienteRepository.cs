using LojaVirtual.Interface;
using LojaVirtual.Models;
using LojaVirtual.Repository.Interface;

namespace LojaVirtual.Repositories
{
    public interface IClienteRepository : IGenericRepository<User>, ILogin<User>
    {

    }
}
