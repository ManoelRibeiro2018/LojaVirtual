using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Interface
{
    public interface ISessionCookie
    {
        public void InsertSession(string key, string valor);
        public void UpdateSession(string key, string valor);
        public void DeleteSession(string key);
        public string FindSession(string key);
        public bool ExistSession(string key);
        public void RemoveAllSession();
    }
}
