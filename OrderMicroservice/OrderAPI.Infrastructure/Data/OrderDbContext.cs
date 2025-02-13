using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Customer)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.CustomerId);
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.AddressId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(i => i.ShoppingCart)
                .WithMany(c => c.ShoppingCartItems)
                .HasForeignKey(i => i.CartId);

            modelBuilder.Entity<PaymentMethod>()
                .HasOne(m => m.PaymentType)
                .WithMany(t => t.paymentMethods)
                .HasForeignKey(m => m.PaymentTypeId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.ShoppingCarts)
                .HasForeignKey(c => c.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
