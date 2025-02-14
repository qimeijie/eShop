using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly PromotionDbContext promotionDbContext;

        public BaseRepositoryAsync(PromotionDbContext promotionDbContext)
        {
            this.promotionDbContext = promotionDbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await promotionDbContext.Set<T>().FindAsync(id);
            if (result != null)
                promotionDbContext.Set<T>().Remove(result);

            return await promotionDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await promotionDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await promotionDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await promotionDbContext.Set<T>().AddAsync(entity);
            await promotionDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            promotionDbContext.Entry(entity).State = EntityState.Modified;
            await promotionDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
