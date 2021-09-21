using LojaVirtual.Interface;
using LojaVirtual.Models;
using LojaVirtual.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Service
{
    public class LoginService
    {
        private readonly ISessionCookie _sessionCookie;

        public LoginService(ISessionCookie sessionCookie)
        {
            _sessionCookie = sessionCookie;
        }
        public void Login(LoginViewModel  viewModel)
        {
            var modelJson = JsonConvert.SerializeObject(viewModel);
            _sessionCookie.InsertSession("login", modelJson);
        }

        public LoginViewModel GetSessionClient()
        {
            if (_sessionCookie.ExistSession("login"))
            {
                return null;
            }
            var client = _sessionCookie.FindSession("login");
            return JsonConvert.DeserializeObject<LoginViewModel>(client);
        }

        public void Logout()
        {
            _sessionCookie.RemoveAllSession();
        }
    }
}
