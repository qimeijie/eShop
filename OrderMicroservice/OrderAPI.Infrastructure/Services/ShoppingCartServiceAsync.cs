using AutoMapper;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Infrastructure.Services
{
    public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IShoppingCartRepositoryAsync shoppingCartRepositoryAsync;

        public ShoppingCartServiceAsync(IMapper mapper, IShoppingCartRepositoryAsync shoppingCartRepositoryAsync)
        {
            this.mapper = mapper;
            this.shoppingCartRepositoryAsync = shoppingCartRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return shoppingCartRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerIdAsync(int customerId)
        {
            var items = await shoppingCartRepositoryAsync.GetShoppingCartByCustomerIdAsync(customerId);
            return mapper.Map<IEnumerable<ShoppingCartResponseModel>>(items);
        }

        public async Task<ShoppingCartResponseModel> InsertAsync(ShoppingCartRequestModel shoppingCartRequestModel)
        {
            var response = await shoppingCartRepositoryAsync.InsertAsync(mapper.Map<ShoppingCart>(shoppingCartRequestModel));
            return mapper.Map<ShoppingCartResponseModel>(response);
        }
    }
}
