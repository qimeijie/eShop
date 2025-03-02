using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.ApplicationCore.Entities;
using AuthenticationMicroservice.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Infrastucture.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly AccountDbContext accountDbContext;

        public UserRepositoryAsync(AccountDbContext accountDbContext) : base(accountDbContext)
        {
            this.accountDbContext = accountDbContext;
        }

        public Task<User?> GetUserAsync(string username)
        {
           return accountDbContext.Users.AsNoTracking().Where(u => u.UserName == username).FirstOrDefaultAsync();
        }           
    }
}
