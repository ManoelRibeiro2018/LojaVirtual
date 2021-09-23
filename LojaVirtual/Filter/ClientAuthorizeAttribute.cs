using LojaVirtual.Interface;
using LojaVirtual.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Filter
{
    public class ClientAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private ILoginService _loginService;

        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           _loginService = (LoginService)context.HttpContext.RequestServices.GetService(typeof(ILoginService));
            var login = _loginService.GetSessionClient();
            if (login != null)
            {
                context.Result = new ContentResult { Content = "Logado!" };
            }
        }
    }
}
