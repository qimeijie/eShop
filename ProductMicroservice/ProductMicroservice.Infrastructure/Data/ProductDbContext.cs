using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryVariation> CategoryVariations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductVariationValue> ProductVariationValues { get; set; }
        public DbSet<VariationValue> VariationValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.ParentCategory)
                .WithMany(pc => pc.ChildCategories)
                .HasForeignKey(pc => pc.ParentCategoryId);

            modelBuilder.Entity<CategoryVariation>()
                .HasOne(cv => cv.ProductCategory)
                .WithMany()
                .HasForeignKey(cv => cv.CategoryId);

            modelBuilder.Entity<ProductVariationValue>().HasKey(pv => new { pv.ProductId, pv.VariationValueId });
            modelBuilder.Entity<ProductVariationValue>()
                .HasOne(pv => pv.VariationValue)
                .WithMany()
                .HasForeignKey(pv => pv.VariationValueId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductVariationValue>()
                .HasOne(pv => pv.Product)
                .WithMany()
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VariationValue>()
                .HasOne(v => v.CategoryVariation)
                .WithMany()
                .HasForeignKey(v => v.VariationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
