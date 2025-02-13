using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Infrastructure.Services
{
    public class CategoryVariationServiceAsync : ICategoryVariationServiceAsync
    {
        private readonly IMapper mapper;
        private readonly ICategoryVariationRepositoryAsync categoryVariationRepositoryAsync;

        public CategoryVariationServiceAsync(IMapper mapper, ICategoryVariationRepositoryAsync categoryVariationRepositoryAsync)
        {
            this.mapper = mapper;
            this.categoryVariationRepositoryAsync = categoryVariationRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return categoryVariationRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>(await categoryVariationRepositoryAsync.GetAllAsync());
        }

        public async Task<CategoryVariationResponseModel?> GetByIdAsync(int id)
        {
            return mapper.Map<CategoryVariationResponseModel>(await categoryVariationRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryId(int categoryId)
        {
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>(await categoryVariationRepositoryAsync.GetCategoryVariationByCategoryId(categoryId));
        }

        public Task<int> InsertAsync(CategoryVariationRequestModel entity)
        {
            var v = mapper.Map<CategoryVariation>(entity);
            return categoryVariationRepositoryAsync.InsertAsync(v);
        }

        public Task<int> UpdateAsync(CategoryVariationRequestModel entity)
        {
            var v = mapper.Map<CategoryVariation>(entity);
            return categoryVariationRepositoryAsync.UpdateAsync(v);
        }
    }
}
