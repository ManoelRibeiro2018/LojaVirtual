using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Interface
{
    public interface IGenericRepository<T>
    {
        T Insert(T Entity);
        void Update(int id, T Entity);
        void Delete(int id);
        T Find(int id);
        List<T> FindAll();
    }
}
