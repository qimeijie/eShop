using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Infrastructure.Services
{
    public class VariationValueServiceAsync : IVariationValueServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IVariationValueRepositoryAsync variationValueRepositoryAsync;

        public VariationValueServiceAsync(IMapper mapper, IVariationValueRepositoryAsync variationValueRepositoryAsync)
        {
            this.mapper = mapper;
            this.variationValueRepositoryAsync = variationValueRepositoryAsync;
        }

        public async Task<IEnumerable<VariationValueResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<VariationValueResponseModel>>(await variationValueRepositoryAsync.GetAllAsync());
        }

        public Task<int> InsertAsync(VariationValueRequestModel entity)
        {
            var v = mapper.Map<VariationValue>(entity);
            return variationValueRepositoryAsync.InsertAsync(v);
        }
    }
}
