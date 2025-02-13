using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperRepositoryAsync : BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
    {
        public ShipperRepositoryAsync(ShippingDbContext shippingDbContext) : base(shippingDbContext)
        {
        }
    }
}
