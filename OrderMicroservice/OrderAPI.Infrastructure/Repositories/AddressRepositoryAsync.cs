using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class AddressRepositoryAsync : BaseRepositoryAsync<Address>, IAddressRepositoryAsync
    {
        public AddressRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
