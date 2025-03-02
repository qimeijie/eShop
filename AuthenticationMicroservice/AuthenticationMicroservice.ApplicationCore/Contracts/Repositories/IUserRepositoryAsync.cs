using AuthenticationMicroservice.ApplicationCore.Entities;

namespace AuthenticationMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IUserRepositoryAsync : IRepositoryAsync<User>
    {
        Task<User?> GetUserAsync(string username);
    }
}
