using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface IShoppingCartServiceAsync
    {
        Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerIdAsync(int customerId);
        Task<ShoppingCartResponseModel> InsertAsync(ShoppingCartRequestModel shoppingCartRequestModel);
        Task<int> DeleteAsync(int id);
    }
}
