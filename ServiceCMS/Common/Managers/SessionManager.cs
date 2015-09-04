using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Interfaces;

namespace Common.Managers
{
    public class SessionManager:ISessionManager
    {
        public T Get<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        public void Set(string key, object data)
        {
            if (data == null)
                return;
            HttpContext.Current.Session.Add(key, data);
        }

        public bool IsSet(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}
