using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Utilities;

namespace BeauProject.Shared.Data.Services
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
