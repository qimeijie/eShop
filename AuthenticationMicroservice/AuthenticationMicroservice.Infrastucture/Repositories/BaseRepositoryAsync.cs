using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Infrastucture.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly AccountDbContext accountDbContext;

        public BaseRepositoryAsync(AccountDbContext accountDbContext)
        {
            this.accountDbContext = accountDbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await accountDbContext.Set<T>().FindAsync(id);
            if (result != null)
                accountDbContext.Set<T>().Remove(result);

            return await accountDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await accountDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await accountDbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await accountDbContext.Set<T>().AddAsync(entity);
            return await accountDbContext.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(T entity)
        {
            accountDbContext.Entry(entity).State = EntityState.Modified;
            return accountDbContext.SaveChangesAsync();
        }
    }
}
