using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class ShoppingCartItemRepositoryAsync : BaseRepositoryAsync<ShoppingCartItem>, IShoppingCartItemRepositoryAsync
    {
        public ShoppingCartItemRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
