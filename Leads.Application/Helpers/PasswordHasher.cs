using System.Security.Cryptography;
using System.Text;


namespace Leads.Application.Helpers
{
    public static class PasswordHasher
    {
        public class PasswordHashResult
        {
            public string Hash { get; set; } = string.Empty;
            public string Salt { get; set; } = string.Empty;
        }

        public static PasswordHashResult CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return new PasswordHashResult
            {
                Salt = Convert.ToBase64String(salt),
                Hash = Convert.ToBase64String(hash)
            };
        }

        public static bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            using var hmac = new HMACSHA512(saltBytes);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var computedHashString = Convert.ToBase64String(computedHash);
            return computedHashString == storedHash;
        }
    }
}
