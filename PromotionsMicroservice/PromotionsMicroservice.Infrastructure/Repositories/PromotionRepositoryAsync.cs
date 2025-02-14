using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class PromotionRepositoryAsync : BaseRepositoryAsync<Promotion>, IPromotionRepositoryAsync
    {
        private readonly PromotionDbContext promotionDbContext;

        public PromotionRepositoryAsync(PromotionDbContext promotionDbContext) : base(promotionDbContext)
        {
            this.promotionDbContext = promotionDbContext;
        }

        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
        {
            return await promotionDbContext.Promotions.AsNoTracking().Where(p => p.PromotionState == PromotionState.Active).ToListAsync();
        }

        public async Task<IEnumerable<Promotion>> GetPromotionByProductNameAsync(string name)
        {
            return await promotionDbContext.Promotions.AsNoTracking()
                .Where(p => p.PromotionDetails.Any(d => d.ProductCategoryName == name))
                .ToListAsync();
        }
    }
}
