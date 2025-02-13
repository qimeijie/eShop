using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationServiceAsync productVariationServiceAsync;
        public ProductVariationController(IProductVariationServiceAsync productVariationServiceAsync)
        {
            this.productVariationServiceAsync = productVariationServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductVariationValueRequestModel productVariationValueRequestModel)
        {
            var response = await productVariationServiceAsync.InsertAsync(productVariationValueRequestModel);
            if (response == 1)
            {
                return Ok("Saved");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductVariation()
        {
            var response = await productVariationServiceAsync.GetAllAsync();
            return Ok(response);
        }
    }
}
