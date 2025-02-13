using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface IVariationValueServiceAsync
    {
        Task<IEnumerable<VariationValueResponseModel>> GetAllAsync();
        Task<int> InsertAsync(VariationValueRequestModel entity);
    }
}
