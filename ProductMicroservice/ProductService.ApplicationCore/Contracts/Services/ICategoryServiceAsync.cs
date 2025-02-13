using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface ICategoryServiceAsync
    {
        Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentCategoryId(int parentCategoryId);
        Task<IEnumerable<ProductCategoryResponseModel>> GetAllAsync();
        Task<ProductCategoryResponseModel?> GetByIdAsync(int id);
        Task<int> InsertAsync(ProductCategoryRequestModel entity);
        Task<int> UpdateAsync(ProductCategoryRequestModel entity);
        Task<int> DeleteAsync(int id);
    }
}
