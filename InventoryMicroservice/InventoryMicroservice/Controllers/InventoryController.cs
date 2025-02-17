using Microsoft.AspNetCore.Mvc;
using SharedNotificationService;

namespace InventoryMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly RabbitMqServiceAsync rabbitMqServiceAsync;

        public InventoryController()
        {
            this.rabbitMqServiceAsync = new RabbitMqServiceAsync("Inventory Microservice", Server.Local);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompletedOrder()
        {
            await rabbitMqServiceAsync.ReadMessage();
            return Ok();
        }
    }
}
