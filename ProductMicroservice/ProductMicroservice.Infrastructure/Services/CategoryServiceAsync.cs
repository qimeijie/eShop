using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Infrastructure.Services
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;

        public CategoryServiceAsync(IMapper mapper, ICategoryRepositoryAsync categoryRepositoryAsync)
        {
            this.mapper = mapper;
            this.categoryRepositoryAsync = categoryRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return categoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductCategoryResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<ProductCategoryResponseModel>>(await categoryRepositoryAsync.GetAllAsync());
        }

        public async Task<ProductCategoryResponseModel?> GetByIdAsync(int id)
        {
            return mapper.Map<ProductCategoryResponseModel>(await categoryRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentCategoryId(int parentCategoryId)
        {
            return mapper.Map<IEnumerable<ProductCategoryResponseModel>>(await categoryRepositoryAsync.GetCategoryByParentCategoryId(parentCategoryId));
        }

        public Task<int> InsertAsync(ProductCategoryRequestModel entity)
        {
            var c = mapper.Map<ProductCategory>(entity);
            return categoryRepositoryAsync.InsertAsync(c);
        }

        public Task<int> UpdateAsync(ProductCategoryRequestModel entity)
        {
            var c = mapper.Map<ProductCategory>(entity);
            return categoryRepositoryAsync.UpdateAsync(c);
        }
    }
}
