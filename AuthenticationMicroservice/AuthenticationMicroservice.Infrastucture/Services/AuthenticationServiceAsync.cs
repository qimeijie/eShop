using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.ApplicationCore.Contracts.Services;
using AuthenticationMicroservice.ApplicationCore.Entities;
using AuthenticationMicroservice.ApplicationCore.Models;
using AutoMapper;

namespace AuthenticationMicroservice.Infrastucture.Services
{
    public class AuthenticationServiceAsync : IAuthenticationServiceAsync
    {
        private readonly IMapper mapper;
        private readonly ITokenService tokenHandler;
        private readonly IUserRepositoryAsync userRepositoryAsync;
        private readonly IUserRoleRepositoryAsync userRoleRepositoryAsync;
        private readonly IRoleRepositoryAsync roleRepositoryAsync;

        private const int TOKEN_VALID_MIN = 60;

        public AuthenticationServiceAsync(IMapper mapper, ITokenService tokenHandler, IUserRepositoryAsync userRepositoryAsync, IUserRoleRepositoryAsync userRoleRepositoryAsync, IRoleRepositoryAsync roleRepositoryAsync)
        {
            this.mapper = mapper;
            this.tokenHandler = tokenHandler;
            this.userRepositoryAsync = userRepositoryAsync;
            this.userRoleRepositoryAsync = userRoleRepositoryAsync;
            this.roleRepositoryAsync = roleRepositoryAsync;
        }
        public Task<int> DeleteAsync(int id)
        {
            return userRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserHttpResponse>> GetAllUsersAsync()
        {
            return mapper.Map<IEnumerable<UserHttpResponse>>(await userRepositoryAsync.GetAllAsync());
        }

        public async Task<UserHttpResponse> GetUserAsync(int id)
        {
            return mapper.Map<UserHttpResponse>(await userRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<AuthenticationHttpResponse> LoginAsync(AuthenticationHttpRequest request)
        {
            var user = await userRepositoryAsync.GetUserAsync(request.UserName) ?? throw new Exception("User does not exists");
            // should use hashedpassword to verify
            if (user.Password != request.Password)
            {
                throw new Exception("Invalid Password");
            }
            var roles = await userRoleRepositoryAsync.GetUserRolesAsync(user.Id);
            return tokenHandler.GenerateToken(user.UserName, TOKEN_VALID_MIN, roles.Select(r => r.Name));
        }

        public async Task<int> RegisterAdminAsync(int userId)
        {
            var user = await userRepositoryAsync.GetByIdAsync(userId) ?? throw new Exception("User does not exists");

            var adminRole = await roleRepositoryAsync.GetByNameAsync("Admin") ?? throw new Exception("Admin role does not exists");
            var userRole = await userRoleRepositoryAsync.GetUserRoleAsync(user.Id, adminRole.Id);
            if (userRole == null) 
            {
                return await userRoleRepositoryAsync.InsertAsync(new UserRole() { UserId = user.Id, RoleId = adminRole.Id });
            }
            return 0;
        }

        public async Task<int> RegisterCustomerAsync(int userId)
        {
            var user = await userRepositoryAsync.GetByIdAsync(userId) ?? throw new Exception("User does not exists");
            var role = await roleRepositoryAsync.GetByNameAsync("Customer") ?? throw new Exception("Admin role does not exists");
            var userRole = await userRoleRepositoryAsync.GetUserRoleAsync(user.Id, role.Id);
            if (userRole == null)
            {
                return await userRoleRepositoryAsync.InsertAsync(new UserRole() { UserId = user.Id, RoleId = role.Id });
            }
            return await Task.FromResult(0);
        }

        public Task<int> UpdateAsync(UserHttpRequest user)
        {
            return userRepositoryAsync.UpdateAsync(mapper.Map<User>(user));
        }
    }
}
