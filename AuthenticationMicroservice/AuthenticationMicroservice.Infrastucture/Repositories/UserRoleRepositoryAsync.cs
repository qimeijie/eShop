using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.ApplicationCore.Entities;
using AuthenticationMicroservice.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Infrastucture.Repositories
{
    public class UserRoleRepositoryAsync : BaseRepositoryAsync<UserRole>, IUserRoleRepositoryAsync
    {
        private readonly AccountDbContext accountDbContext;

        public UserRoleRepositoryAsync(AccountDbContext accountDbContext) : base(accountDbContext)
        {
            this.accountDbContext = accountDbContext;
        }

        public Task<UserRole?> GetUserRoleAsync(int userId, int roleId)
        {
            return accountDbContext.UserRoles.AsNoTracking().Where(ur => ur.UserId == userId && ur.RoleId == roleId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(int userId)
        {
            return await accountDbContext.UserRoles.AsNoTracking().Where(ur => ur.UserId == userId).Select(ur => ur.Role).ToListAsync();
        }
    }
}
