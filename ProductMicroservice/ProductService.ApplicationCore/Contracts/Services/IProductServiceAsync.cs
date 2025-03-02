using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface IProductServiceAsync
    {
        Task<TotalProductResponseModel> GetListProducts(int pageId, int pageSize, int? categoryId);
        Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int categoryId);
        Task<IEnumerable<ProductResponseModel>> GetProductByProductName(string productName);
        Task<IEnumerable<ProductResponseModel>> GetAllAsync();
        Task<ProductResponseModel?> GetByIdAsync(int id);
        Task<int> InsertAsync(ProductRequestModel entity);
        Task<int> UpdateAsync(ProductRequestModel entity);
        Task<int> DeleteAsync(int id);
    }
}
