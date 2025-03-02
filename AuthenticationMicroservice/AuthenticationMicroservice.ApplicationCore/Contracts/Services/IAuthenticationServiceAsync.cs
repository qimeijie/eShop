using AuthenticationMicroservice.ApplicationCore.Models;

namespace AuthenticationMicroservice.ApplicationCore.Contracts.Services
{
    public interface IAuthenticationServiceAsync
    {
        Task<IEnumerable<UserHttpResponse>> GetAllUsersAsync();
        Task<UserHttpResponse> GetUserAsync(int id);
        Task<AuthenticationHttpResponse> LoginAsync(AuthenticationHttpRequest request);
        Task<int> RegisterAdminAsync(int userId);
        Task<int> RegisterCustomerAsync(int userId);
        Task<int> UpdateAsync(UserHttpRequest user);
        Task<int> DeleteAsync(int id);


    }
}
