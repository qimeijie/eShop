namespace AuthenticationMicroservice.ApplicationCore.Contracts.Services
{
    public interface IPasswordService
    {
        string HashPasswordAsync(string user, string password);
        bool VerifyPasswordAsync(string user, string inputPassword, string hashedPassword);
    }
}
