using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Helpers
{
    public class Crypt
    {
        private readonly string _pepperForPassword;
        public Crypt(string pepperForPassword)
        {
            _pepperForPassword = pepperForPassword; // TODO: Azure key vaulttiin
        }
   
        public Tuple<string, string> GenerateUserPassword(string userPassword)
        {   
            string returnPassword, salt = string.Empty;
            salt = Crypt.GenerateUserSalt();
            returnPassword = GenerateHashedPassword(
                            string.Concat(_pepperForPassword, userPassword),
                            salt);
            return new Tuple<string, string>(returnPassword, salt);
        }

        public static string GenerateUserSalt()
        {
            var builder = new StringBuilder(10);
            const int lettersOffset = 26;
            Random _random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var @char = (char)_random.Next('a', 'a' + lettersOffset);
                builder.Append(@char);
            }
            string randomString = builder.ToString();

            builder.Append(_random.Next(10, 1000));

            return builder.ToString();
        }
        public static string GenerateHashedPassword(string UserPepperedPassword, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: UserPepperedPassword,
                salt: Encoding.ASCII.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
