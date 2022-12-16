using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Helpers
{
    // Fonte: https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2
    public static class PasswordHashHelper
    {
        private const int SaltSize = 16;  // 128 bit
        private const int Iterations = 10000;
        private const int KeySize = 32;  // 256 bit

        public static string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA512);

            var saltSize = Convert.ToBase64String(algorithm.Salt);
            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));

            return $"{Iterations}.{saltSize}.{key}";
        }

        public static (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. Should be formatted as '{iterations}.{salt}.{hash}'.");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var saltSize = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != Iterations;

            using var algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA512);

            var keyToCheck = algorithm.GetBytes(KeySize);

            var verified = keyToCheck.SequenceEqual(key);

            return (verified, needsUpgrade);
        }
    }
}
