using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(ProductCategoryRequestModel productCategoryRequestModel)
        {
            var response = await categoryServiceAsync.InsertAsync(productCategoryRequestModel);
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
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await categoryServiceAsync.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await categoryServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await categoryServiceAsync.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int parentCategoryId)
        {
            var response = await categoryServiceAsync.GetCategoryByParentCategoryId(parentCategoryId);
            return Ok(response);
        }

    }
}
