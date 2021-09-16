using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext;
        }

        public void InsertSession(string key, string valor)
        {
            _httpContext.HttpContext.Session.SetString(key, valor);
        }
        public void UpdateSession(string key, string valor)
        {
            if (!ExistSession(key))
            {

                DeleteSession(key); 
            }
            _httpContext.HttpContext.Session.SetString(key, valor);
        }

        public void DeleteSession(string key)
        {
            _httpContext.HttpContext.Session.Remove(key);
        }

        public string FindSession(string key)
        {
            return _httpContext.HttpContext.Session.GetString(key);
        }

        public bool ExistSession(string key)
        {
            return FindSession(key) == null;
        }

        public void RemoveAllSession()
        {
            _httpContext.HttpContext.Session.Clear();
        }
    }
}
