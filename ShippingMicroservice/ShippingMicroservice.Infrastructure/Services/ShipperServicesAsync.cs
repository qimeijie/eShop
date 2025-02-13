using AutoMapper;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Service;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShipperServicesAsync : IShipperServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;
        private readonly IRegionRepositoryAsync regionRepositoryAsync;

        public ShipperServicesAsync(IMapper mapper, IShipperRepositoryAsync shipperRepositoryAsync, IRegionRepositoryAsync regionRepositoryAsync)
        {
            this.mapper = mapper;
            this.shipperRepositoryAsync = shipperRepositoryAsync;
            this.regionRepositoryAsync = regionRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return shipperRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllShippersAsync()
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await shipperRepositoryAsync.GetAllAsync());
        }

        public async Task<ShipperResponseModel> GetByIdAsync(int id)
        {
            return mapper.Map<ShipperResponseModel>(await shipperRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetShipperByRegion(string region)
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await regionRepositoryAsync.GetShipperByRegion(region));
        }

        public async Task<ShipperResponseModel> InsertAsync(ShipperRequestModel shipperRequestModel)
        {
            return mapper.Map<ShipperResponseModel>(await shipperRepositoryAsync.InsertAsync(mapper.Map<Shipper>(shipperRequestModel)));
        }

        public async Task<ShipperResponseModel> UpdateAsync(ShipperRequestModel shipperRequestModel)
        {
            return mapper.Map<ShipperResponseModel>(await shipperRepositoryAsync.UpdateAsync(mapper.Map<Shipper>(shipperRequestModel)));
        }
    }
}
