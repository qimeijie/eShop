using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class UserAddressRepositoryAsync : BaseRepositoryAsync<UserAddress>, IUserAddressRepositoryAsync
    {
        public UserAddressRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
