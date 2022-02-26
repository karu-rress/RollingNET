using System;
using System.Security.Cryptography;
using System.Text;

namespace RollingRess.Security
{
    public static class Security
    {
        public static string SHA256Encrypt(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] encryptBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(encryptBytes);
        }

        public static string SHA512Encrypt(string input)
        {
            using SHA512 sha256 = SHA512.Create();
            byte[] encryptBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(encryptBytes);
        }
    }
}
