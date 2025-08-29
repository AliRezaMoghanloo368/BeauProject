using BeauProject.Shared.Exceptions;
using BeauProject.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Shared.Extensions
{
    public static class PasswordExtension
    {
        public static string HashPassword(this string password, string salt, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ActioException("empty_password",
                    "Password can not be empty.");
            }

            //salt = encrypter.GetSalt();
            return encrypter.GetHash(password, salt);
        }

        public static string GenerateSalt(this string salt, IEncrypter encrypter)
        {
            return encrypter.GetSalt();
        }
    }
}
