using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
    {
        private readonly OrderDbContext orderDbContext;

        public ShoppingCartRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartByCustomerIdAsync(int customerId)
        {
            return await orderDbContext.ShoppingCarts.AsNoTracking()
                .Where(sc => sc.CustomerId == customerId)
                .Include(sc => sc.ShoppingCartItems)
                .ToListAsync();
        }
    }
}
