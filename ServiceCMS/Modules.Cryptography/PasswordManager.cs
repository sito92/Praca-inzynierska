using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.Cryptography.Interfaces;

namespace Modules.Cryptography
{
    public class PasswordManager:IPasswordManager
    {
        private IHashComputer _hashComputer;
        public PasswordManager(IHashComputer hashComputer)
        {
            _hashComputer = hashComputer;
        }

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return _hashComputer.GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == _hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }
}
