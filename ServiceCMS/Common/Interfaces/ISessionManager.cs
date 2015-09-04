using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISessionManager
    {
        T Get<T>(string key);

        void Set(string key, object data);

        bool IsSet(string key);

        void Remove(string key);      
    }
}
