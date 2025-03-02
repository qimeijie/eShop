using AuthenticationMicroservice.ApplicationCore.Entities;

namespace AuthenticationMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IUserRoleRepositoryAsync : IRepositoryAsync<UserRole>
    {
        Task<UserRole?> GetUserRoleAsync(int userId, int roleId);
        Task<IEnumerable<Role>> GetUserRolesAsync(int userId);
    }
}
