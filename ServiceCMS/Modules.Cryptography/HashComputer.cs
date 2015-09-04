using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Modules.Cryptography.Interfaces;

namespace Modules.Cryptography
{
    public class HashComputer : IHashComputer
    {
        private Encoding encoding = Encoding.UTF8;
        public string GetPasswordHashAndSalt(string message)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = encoding.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            
            return encoding.GetString(resultBytes);
        }
    }
}
