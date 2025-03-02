using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.ApplicationCore.Entities;
using AuthenticationMicroservice.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Infrastucture.Repositories
{
    public class RoleRepositoryAsync : BaseRepositoryAsync<Role>, IRoleRepositoryAsync
    {
        private readonly AccountDbContext accountDbContext;

        public RoleRepositoryAsync(AccountDbContext accountDbContext) : base(accountDbContext)
        {
            this.accountDbContext = accountDbContext;
        }

        public Task<Role?> GetByNameAsync(string name)
        {
            return accountDbContext.Roles.AsNoTracking().Where(r => EF.Functions.Like(r.Name, name)).FirstOrDefaultAsync();
        }
    }
}
