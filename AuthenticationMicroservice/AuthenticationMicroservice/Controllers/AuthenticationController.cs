using AuthenticationMicroservice.ApplicationCore.Contracts.Services;
using AuthenticationMicroservice.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServiceAsync authenticationServiceAsync;

        public AuthenticationController(IAuthenticationServiceAsync authenticationServiceAsync)
        {
            this.authenticationServiceAsync = authenticationServiceAsync;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationHttpRequest request)
        {
            var response = await authenticationServiceAsync.LoginAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(int userId)
        {
            var response = await authenticationServiceAsync.RegisterAdminAsync(userId);
            return Ok(response);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UserHttpRequest request)
        {
            var response = await authenticationServiceAsync.UpdateAsync(request);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int userId)
        {
            var response = await authenticationServiceAsync.DeleteAsync(userId);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await authenticationServiceAsync.GetAllUsersAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterCustomer(int userId)
        {
            var response = await authenticationServiceAsync.RegisterCustomerAsync(userId);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var response = await authenticationServiceAsync.GetUserAsync(userId);
            return Ok(response);
        }
    }
}
