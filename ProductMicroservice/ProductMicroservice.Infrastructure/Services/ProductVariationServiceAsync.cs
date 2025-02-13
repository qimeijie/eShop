using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Infrastructure.Services
{
    public class ProductVariationServiceAsync : IProductVariationServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IProductVariationRepositoryAsync productVariationRepositoryAsync;

        public ProductVariationServiceAsync(IMapper mapper, IProductVariationRepositoryAsync productVariationRepositoryAsync)
        {
            this.mapper = mapper;
            this.productVariationRepositoryAsync = productVariationRepositoryAsync;
        }
        public async Task<IEnumerable<ProductVariationValueResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<ProductVariationValueResponseModel>>(await productVariationRepositoryAsync.GetAllAsync());
        }

        public Task<int> InsertAsync(ProductVariationValueRequestModel entity)
        {
            var v = mapper.Map<ProductVariationValue>(entity);
            return productVariationRepositoryAsync.InsertAsync(v);
        }
    }
}
