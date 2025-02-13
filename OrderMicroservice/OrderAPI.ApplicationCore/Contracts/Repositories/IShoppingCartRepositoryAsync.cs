using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
    public interface IShoppingCartRepositoryAsync : IRepositoryAsync<ShoppingCart>
    {
        Task<IEnumerable<ShoppingCart>> GetShoppingCartByCustomerIdAsync(int customerId);
    }
}
