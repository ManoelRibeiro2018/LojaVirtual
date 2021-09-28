using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repository.Interface
{
    public interface ILogin<T>
    {
        T Login(string email, string senha);
    }
}
