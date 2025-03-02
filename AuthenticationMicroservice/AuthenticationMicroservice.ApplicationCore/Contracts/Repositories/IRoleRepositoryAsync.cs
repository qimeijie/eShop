using AuthenticationMicroservice.ApplicationCore.Entities;

namespace AuthenticationMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IRoleRepositoryAsync : IRepositoryAsync<Role>
    {
        Task<Role?> GetByNameAsync(string name);
    }
}
