using AuthenticationMicroservice.ApplicationCore.Models;

namespace AuthenticationMicroservice.ApplicationCore.Contracts.Services
{
    public interface ITokenService
    {
        AuthenticationHttpResponse GenerateToken(string userName, int tokenValidMins, IEnumerable<string> roles);
    }
}
