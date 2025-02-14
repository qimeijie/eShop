using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServiceAsync promotionServiceAsync;

        public PromotionController(IPromotionServiceAsync promotionServiceAsync)
        {
            this.promotionServiceAsync = promotionServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await promotionServiceAsync.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PromotionRequestModel promotionRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await promotionServiceAsync.InsertAsync(promotionRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpPut]
        public async Task<IActionResult> Update(PromotionRequestModel promotionRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await promotionServiceAsync.UpdateAsync(promotionRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await promotionServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await promotionServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("activePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            var response = await promotionServiceAsync.GetActivePromotionsAsync();
            return Ok(response);
        }

        [HttpGet("promotionByProductName")]
        public async Task<IActionResult> GetByProductName(string productName)
        {
            var response = await promotionServiceAsync.GetPromotionByProductNameAsync(productName);
            return Ok(response);
        }

    }
}
