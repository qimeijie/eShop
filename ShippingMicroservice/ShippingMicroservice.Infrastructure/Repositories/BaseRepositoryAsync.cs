using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ShippingDbContext shippingDbContext;

        public BaseRepositoryAsync(ShippingDbContext shippingDbContext)
        {
            this.shippingDbContext = shippingDbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await shippingDbContext.Set<T>().FindAsync(id);
            if (result != null)
                shippingDbContext.Set<T>().Remove(result);

            return await shippingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await shippingDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await shippingDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await shippingDbContext.Set<T>().AddAsync(entity);
            await shippingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            shippingDbContext.Entry(entity).State = EntityState.Modified;
            await shippingDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
