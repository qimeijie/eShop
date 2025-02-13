using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly ProductDbContext productDbContext;

        public ProductRepositoryAsync(ProductDbContext productDbContext) : base(productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<IEnumerable<Product>> GetListProducts(int pageId, int pageSize, int? categoryId)
        {
            var query = productDbContext.Products.AsNoTracking();
            if (categoryId != null) 
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            return await query.Skip(pageSize * (pageId - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
        {
            return await productDbContext.Products.AsNoTracking().Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByProductName(string productName)
        {
            return await productDbContext.Products.AsNoTracking().Where(p => p.Name == productName).ToListAsync();
        }
    }
}
