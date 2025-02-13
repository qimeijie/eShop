using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Models;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceAsync paymentServiceAsync;

        public PaymentController(IPaymentServiceAsync paymentServiceAsync)
        {
            this.paymentServiceAsync = paymentServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
        {
            var response = await paymentServiceAsync.GetPaymentByCustomerIdAsync(customerId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> SavePayment(PaymentRequestModel paymentRequestModel)
        {
            var response = await paymentServiceAsync.InsertAsync(paymentRequestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var response = await paymentServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(PaymentRequestModel paymentRequestModel)
        {
            var response = await paymentServiceAsync.UpdateAsync(paymentRequestModel);
            return Ok(response);
        }
    }
}
