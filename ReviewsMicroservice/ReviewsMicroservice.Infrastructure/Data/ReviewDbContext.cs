using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Entities;

namespace ReviewsMicroservice.Infrastructure.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }
}
