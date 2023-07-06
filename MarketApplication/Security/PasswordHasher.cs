using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarketApplication.Security
{
    public class PasswordHasher
    {
        public static (string PasswordHash, string Passwordsalt) Hash(string Password)
        {
            string salt = Guid.NewGuid().ToString();

            string hash = BCrypt.Net.BCrypt.HashPassword(Password + salt);   
          
            return (PasswordHash: hash, Passwordsalt: salt);
        }

        public static bool Verify(string password, string passwordHash, string salt)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
        }
    }
}
