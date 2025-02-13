using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Models;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServiceAsync shoppingCartServiceAsync;

        public ShoppingCartController(IShoppingCartServiceAsync shoppingCartServiceAsync)
        {
            this.shoppingCartServiceAsync = shoppingCartServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartByCustomerId(int customerId)
        {
            var response = await shoppingCartServiceAsync.GetShoppingCartByCustomerIdAsync(customerId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveShoppingCart(ShoppingCartRequestModel shoppingCartRequestModel)
        {
            var response = await shoppingCartServiceAsync.InsertAsync(shoppingCartRequestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            var response = await shoppingCartServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

    }
}
