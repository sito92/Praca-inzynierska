using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Cryptography
{
    public static class SaltGenerator
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;
        private static Encoding encoding = Encoding.UTF8;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {        
            byte[] saltBytes = new byte[SALT_SIZE];

            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            string saltString = encoding.GetString(saltBytes);

            return saltString;
        }
    }
}
