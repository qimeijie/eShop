using AuthenticationMicroservice.ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationMicroservice.Infrastucture.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<string> passwordHasher;

        public PasswordService(PasswordHasher<string> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }
        public string HashPasswordAsync(string user, string password)
        {
            return passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPasswordAsync(string user, string inputPassword, string hashedPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(user, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
