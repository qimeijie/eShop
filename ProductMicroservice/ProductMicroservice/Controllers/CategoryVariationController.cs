using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationServiceAsync categoryVariationServiceAsync;

        public CategoryVariationController(ICategoryVariationServiceAsync categoryVariationServiceAsync)
        {
            this.categoryVariationServiceAsync = categoryVariationServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryVariationRequestModel categoryVariationRequestModel)
        {
            var response = await categoryVariationServiceAsync.InsertAsync(categoryVariationRequestModel);
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryVariationServiceAsync.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            var response = await categoryVariationServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(int categoryId)
        {
            var response = await categoryVariationServiceAsync.GetCategoryVariationByCategoryId(categoryId);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryVariationServiceAsync.DeleteAsync(id);
            return Ok(result);
        }
    }
}
