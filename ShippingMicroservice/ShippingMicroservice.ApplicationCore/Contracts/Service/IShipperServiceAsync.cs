using ShippingMicroservice.ApplicationCore.Models;

namespace ShippingMicroservice.ApplicationCore.Contracts.Service
{
    public interface IShipperServiceAsync
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync();
        Task<ShipperResponseModel> InsertAsync(ShipperRequestModel shipperRequestModel);
        Task<ShipperResponseModel> UpdateAsync(ShipperRequestModel shipperRequestModel);
        Task<ShipperResponseModel> GetByIdAsync(int id);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<ShipperResponseModel>> GetShipperByRegion(string region);
    }
}
