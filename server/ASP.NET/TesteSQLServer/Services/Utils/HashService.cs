using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace TesteSQLServer.Services.Utils {
    public class HashService {
        protected string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false) {
            if (salt == null || salt.Length != 16) {
                salt = new byte[128 / 8];

                using (var rngCsp = new RNGCryptoServiceProvider()) {
                    rngCsp.GetNonZeroBytes(salt);
                }
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            if (needsOnlyHash) return hashed;

            return $"{hashed}:{Convert.ToBase64String(salt)}";
        }

        protected bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck) {
            var passwordAndSalt = hashedPasswordWithSalt.Split(":");

            if (passwordAndSalt == null || passwordAndSalt.Length != 2) return false;

            var salt = Convert.FromBase64String(passwordAndSalt[1]);

            if (salt == null) return false;

            var hashOfPasswordToCheck = HashPassword(passwordToCheck, salt, true);

            if (String.Compare(passwordAndSalt[0], hashOfPasswordToCheck) == 0) return true;

            return false;
        }
    }
}
