using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T: class
    {
        private readonly ProductDbContext productDbContext;

        public BaseRepositoryAsync(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await productDbContext.Set<T>().FindAsync(id);
            if (result != null)
                productDbContext.Set<T>().Remove(result);

            return await productDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await productDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await productDbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await productDbContext.Set<T>().AddAsync(entity);
            return await productDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            productDbContext.Entry(entity).State = EntityState.Modified;
            return await productDbContext.SaveChangesAsync();
        }
    }
}
