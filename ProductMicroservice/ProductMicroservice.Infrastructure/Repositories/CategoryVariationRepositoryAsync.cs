using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryVariationRepositoryAsync : BaseRepositoryAsync<CategoryVariation>, ICategoryVariationRepositoryAsync
    {
        private readonly ProductDbContext productDbContext;

        public CategoryVariationRepositoryAsync(ProductDbContext productDbContext) : base(productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int categoryId)
        {
            return await productDbContext.CategoryVariations.AsNoTracking().Where(cv => cv.CategoryId == categoryId).ToListAsync();
        }
    }
}
