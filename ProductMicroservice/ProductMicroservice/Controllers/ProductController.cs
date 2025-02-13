using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync productServiceAsync)
        {
            this.productServiceAsync = productServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts(int pageId = 1, int pageSize = 10, int? categoryId = null)
        {
            var response = await productServiceAsync.GetListProducts(pageId, pageSize, categoryId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await productServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductRequestModel productRequestModel)
        {
            var response = await productServiceAsync.InsertAsync(productRequestModel);
            if (response == 1)
            {
                return Ok("Saved");
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel productRequestModel)
        {
            var response = await productServiceAsync.UpdateAsync(productRequestModel);
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
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var response = await productServiceAsync.GetProductByCategoryId(categoryId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var response = await productServiceAsync.GetProductByProductName(name);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await productServiceAsync.DeleteAsync(id);
            return Ok(result);
        }
    }
}
