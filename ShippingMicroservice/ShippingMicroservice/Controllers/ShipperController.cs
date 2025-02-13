using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Service;
using ShippingMicroservice.ApplicationCore.Models;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperServiceAsync shipperServiceAsync;

        public ShipperController(IShipperServiceAsync shipperServiceAsync)
        {
            this.shipperServiceAsync = shipperServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await shipperServiceAsync.GetAllShippersAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ShipperRequestModel shipperRequestModel)
        {
            if(ModelState.IsValid)
            {
                var response = await shipperServiceAsync.InsertAsync(shipperRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpPut]
        public async Task<IActionResult> Update(ShipperRequestModel shipperRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await shipperServiceAsync.UpdateAsync(shipperRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await shipperServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("shipper/region/{region}")]
        public async Task<IActionResult> GetShippersByRegion(string region)
        {
            var response = await shipperServiceAsync.GetShipperByRegion(region);
            return Ok(response);
        }
    }
}
