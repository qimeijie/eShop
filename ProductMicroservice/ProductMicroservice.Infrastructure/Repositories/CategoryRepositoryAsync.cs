using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryRepositoryAsync : BaseRepositoryAsync<ProductCategory>, ICategoryRepositoryAsync
    {
        private readonly ProductDbContext productDbContext;

        public CategoryRepositoryAsync(ProductDbContext productDbContext) : base(productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategoryByParentCategoryId(int parentCategoryId)
        {
            return await productDbContext.ProductCategories.AsNoTracking().Where(c => c.ParentCategoryId == parentCategoryId).ToListAsync();
        }
    }
}
