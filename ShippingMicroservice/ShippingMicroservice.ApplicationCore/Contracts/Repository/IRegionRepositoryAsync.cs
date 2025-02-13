using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IRegionRepositoryAsync : IRepositoryAsync<Region>
    {
        Task<IEnumerable<Shipper>> GetShipperByRegion(string region);
    }
}
