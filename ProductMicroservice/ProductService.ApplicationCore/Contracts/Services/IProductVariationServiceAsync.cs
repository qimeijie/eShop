using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface IProductVariationServiceAsync
    {
        Task<IEnumerable<ProductVariationValueResponseModel>> GetAllAsync();
        Task<int> InsertAsync(ProductVariationValueRequestModel entity);
    }
}
