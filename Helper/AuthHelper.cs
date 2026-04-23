using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace InventoryManagement.Helper
{
    public static class AuthHelper
    {
        public static string HashPassword(string Password, byte[] SaltBytes)
        {
            if (Password == null || SaltBytes == null)
            {
                return string.Empty;
            }
            string hashPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: Password, salt: SaltBytes, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 32));
            return hashPassword;
        }
    }
}
