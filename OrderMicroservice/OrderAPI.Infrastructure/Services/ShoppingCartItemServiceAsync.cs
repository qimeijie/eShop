using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;

namespace OrderAPI.Infrastructure.Services
{
    public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
    {
        private readonly IShoppingCartItemRepositoryAsync shoppingCartItemRepositoryAsync;

        public ShoppingCartItemServiceAsync(IShoppingCartItemRepositoryAsync shoppingCartItemRepositoryAsync)
        {
            this.shoppingCartItemRepositoryAsync = shoppingCartItemRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return shoppingCartItemRepositoryAsync.DeleteAsync(id);
        }
    }
}
