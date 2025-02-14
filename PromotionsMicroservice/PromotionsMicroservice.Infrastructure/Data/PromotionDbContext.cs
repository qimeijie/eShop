using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Entities;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class PromotionDbContext : DbContext
    {
        public PromotionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
    }
}
