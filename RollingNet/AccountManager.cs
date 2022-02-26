using System;
using System.Security.Cryptography;
using System.Text;

namespace RollingRess.Net
{
    public enum LoginResult
    {
        InternetUnavailable,
        IdNotExist,
        WrongPassword,
        LoginSuccessful,
    }
    public abstract class AccountManager
    {
        private string password;
        public const int MinLength = 4;
        public string Id { get; set; }
        public string Password
        {
            private get => password; set
            {
                if (value.Length < 4)
                    throw new ArgumentException($"AccountManager: Password length less than {MinLength}.");

                StringBuilder sb = new();
                using SHA256 passHash = SHA256.Create();
                Encoding enc = Encoding.UTF8;
                byte[] result = passHash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));

                password = sb.ToString();
            }
        }

        public AccountManager() { }
        public AccountManager(string id, string password) { Id = id; Password = password; }

        public virtual LoginResult Login()
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Password))
                throw new ArgumentException("AccountManager: Id or Password is empty.");

            // check internet is available
            // else return LoginResult.InternetUnavailable;

            return VerifyLogin(Id, Password);
        }

        protected abstract LoginResult VerifyLogin(string id, string password);
    }
}
