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
        /// <param name="apiSecret">Api secret</param>
        /// <returns>string of signed message</returns>
        public string GetHMACSignature(string message, string apiSecret)
        {
            message = message + $"&secretKey={apiSecret}";
            byte[] msgBytes = Encoding.UTF8.GetBytes(message);
            byte[] keyBytes = Encoding.UTF8.GetBytes(apiSecret);

            var md5 = new HMACMD5(keyBytes);
            var hash = md5.ComputeHash(msgBytes);

            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }
    }
}
