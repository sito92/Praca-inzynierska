using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Cryptography.Interfaces
{
   public  interface IPasswordManager
    {
        string GeneratePasswordHash(string plainTextPassword, out string salt);

        bool IsPasswordMatch(string password, string salt, string hash);
    }
}
