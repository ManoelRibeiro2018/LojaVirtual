using LojaVirtual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Interface
{
    public interface ILoginService
    {
        public void Login(LoginViewModel viewModel);

        public LoginViewModel GetSessionClient();

        public void Logout();
    }
}
