using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Models;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            this.customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddressByUserId(int userId)
        {
            var addresses = await customerServiceAsync.GetCustomerAddressByUserIdAsync(userId);
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomerAddress(CustomerAddressRequestModel customerAddressRequestModel)
        {
            var response = await customerServiceAsync.SaveCustomerAddressAsync(customerAddressRequestModel);
            return Ok(response);
        }
    }
}
