using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CoinExApiAccess.Core
{
    public class Security
    {
        /// <summary>
        /// Get HMAC Signature
        /// </summary>
        /// <param name="message">Message to sign</param>
        /// <returns>string of signed message</returns>
        public string GetHMACSignature(string message)
        {
            using (var md5 = MD5.Create())
            {
                var msgBytes = Encoding.ASCII.GetBytes(message);
                var hashBytes = md5.ComputeHash(msgBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
