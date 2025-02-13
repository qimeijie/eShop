using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemServiceAsync shoppingCartItemServiceAsync;

        public ShoppingCartItemController(IShoppingCartItemServiceAsync shoppingCartItemServiceAsync)
        {
            this.shoppingCartItemServiceAsync = shoppingCartItemServiceAsync;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int id)
        {
            var response = await shoppingCartItemServiceAsync.DeleteAsync(id);
            return Ok(response);
        }
    }
}
