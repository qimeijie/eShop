using Microsoft.AspNetCore.Mvc;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly IReviewServiceAsync reviewServiceAsync;

        public CustomerReviewController(IReviewServiceAsync reviewServiceAsync)
        {
            this.reviewServiceAsync = reviewServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await reviewServiceAsync.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ReviewRequestModel reviewRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await reviewServiceAsync.InsertAsync(reviewRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpPut]
        public async Task<IActionResult> Update(ReviewRequestModel reviewRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await reviewServiceAsync.UpdateAsync(reviewRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response =await reviewServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await reviewServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await reviewServiceAsync.GetByUserIdAsync(userId);
            return Ok(response);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(string productId)
        {
            var response = await reviewServiceAsync.GetByProductIdAsync(productId);
            return Ok(response);
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetByYeard(int year)
        {
            var response = await reviewServiceAsync.GetByYearAsync(year);
            return Ok(response);
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var response = await reviewServiceAsync.ApproveReviewAsync(id);
            return Ok(response);
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var response = await reviewServiceAsync.RejectReviewAsync(id);
            return Ok(response);
        }
    }
}
