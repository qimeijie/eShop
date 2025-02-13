using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface ICategoryVariationServiceAsync
    {
        Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryId(int categoryId);
        Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync();
        Task<CategoryVariationResponseModel?> GetByIdAsync(int id);
        Task<int> InsertAsync(CategoryVariationRequestModel entity);
        Task<int> UpdateAsync(CategoryVariationRequestModel entity);
        Task<int> DeleteAsync(int id);
    }
}
