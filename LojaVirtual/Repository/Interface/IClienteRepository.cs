using LojaVirtual.Interface;
using LojaVirtual.Models;
using LojaVirtual.Repository.Interface;

namespace LojaVirtual.Repositories
{
    public interface IClienteRepository : IGenericRepository<Cliente>, ILogin<Cliente>
    {

    }
}
