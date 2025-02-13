using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options)
        {
            
        }

        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<ShipperRegion> ShipperRegions { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipperRegion>().HasKey(sr => new { sr.ShipperId, sr.RegionId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
