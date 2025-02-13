using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class RegionRepotitoryAsync : BaseRepositoryAsync<Region>, IRegionRepositoryAsync
    {
        private readonly ShippingDbContext shippingDbContext;

        public RegionRepotitoryAsync(ShippingDbContext shippingDbContext) : base(shippingDbContext)
        {
            this.shippingDbContext = shippingDbContext;
        }

        public async Task<IEnumerable<Shipper>> GetShipperByRegion(string region)
        {
            return await shippingDbContext.Regions.AsNoTracking()
                .Where(r => r.Name == region)
                .SelectMany(r => r.ShipperRegions.Select(sr => sr.Shipper))
                .ToListAsync();
        }
    }
}
