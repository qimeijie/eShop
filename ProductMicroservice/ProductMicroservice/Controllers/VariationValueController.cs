using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueServiceAsync variationValueServiceAsync;

        public VariationValueController(IVariationValueServiceAsync variationValueServiceAsync)
        {
            this.variationValueServiceAsync = variationValueServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Save(VariationValueRequestModel variationValueRequestModel)
        {
            var response = await variationValueServiceAsync.InsertAsync(variationValueRequestModel);
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
        public async Task<IActionResult> GetVariationId()
        {
            var response = await variationValueServiceAsync.GetAllAsync();
            return Ok(response);
        }
    }
}
