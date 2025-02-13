using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductVariationRepositoryAsync : BaseRepositoryAsync<ProductVariationValue>, IProductVariationRepositoryAsync
    {
        public ProductVariationRepositoryAsync(ProductDbContext productDbContext) : base(productDbContext)
        {
        }
    }
}
