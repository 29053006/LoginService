using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace LoginService.Services.Hash
{
    public class HashingServices(PasswordHasher<string> _passwordHasher) : IHashingServices
    {
        public string hashing(string str)
        {
            return _passwordHasher.HashPassword(null, str);

        }
        public bool verifyHash(string hashedPassword, string providedPassword, DateTimeOffset ExpiratePassword)
        {

            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success && ExpiratePassword > DateTimeOffset.UtcNow;

        }

    }

}
