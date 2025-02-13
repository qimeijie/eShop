using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly OrderDbContext orderDbContext;

        public BaseRepositoryAsync(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await orderDbContext.Set<T>().FindAsync(id);
            if (result != null)
                orderDbContext.Set<T>().Remove(result);

            return await orderDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await orderDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await orderDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await orderDbContext.Set<T>().AddAsync(entity);
            await orderDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            orderDbContext.Entry(entity).State = EntityState.Modified;
            await orderDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
