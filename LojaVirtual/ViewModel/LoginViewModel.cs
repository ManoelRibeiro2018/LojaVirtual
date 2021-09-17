using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
