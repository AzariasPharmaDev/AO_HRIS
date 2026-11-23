
using System;
using System.Security.Cryptography;

namespace AO_HRIS.Security
{
    public static class PasswordHelper
    {
        private const int Iterations = 210000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                return "PBKDF2-SHA256$" +
                       Iterations + "$" +
                       Convert.ToBase64String(salt) + "$" +
                       Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(
            string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(storedHash))
                return false;

            string[] parts = storedHash.Split('$');

            if (parts.Length != 4 ||
                parts[0] != "PBKDF2-SHA256")
                return false;

            try
            {
                int iterations = int.Parse(parts[1]);

                if (iterations < 10000 ||
                    iterations > 1000000)
                    return false;

                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expected = Convert.FromBase64String(parts[3]);

                if (salt.Length != SaltSize ||
                    expected.Length != HashSize)
                    return false;

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256))
                {
                    byte[] actual = pbkdf2.GetBytes(expected.Length);

                    int difference = 0;

                    for (int i = 0; i < expected.Length; i++)
                        difference |= actual[i] ^ expected[i];

                    return difference == 0;
                }
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            catch (CryptographicException)
            {
                return false;
            }
        }
    }
}
