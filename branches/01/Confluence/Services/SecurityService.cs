using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Confluence.Services
{
    class SecurityService : ISecurityService
    {
        private const String HEX = "{0:x2}";
        public String GetHash(String plaintext)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] stream = md5.ComputeHash(new ASCIIEncoding().GetBytes(plaintext));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in stream)
                sb.AppendFormat(HEX, b);
            return sb.ToString(); ;
        }
    }
}
