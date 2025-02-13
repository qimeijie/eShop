using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly OrderDbContext orderDbContext;

        public CustomerRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomerAddressByUserIdAsync(int userId)
        {
            return await orderDbContext.Customers.AsNoTracking()
                .Where(c => c.UserId == userId)
                .Include(c => c.UserAddresses)
                .ThenInclude(ua => ua.Address)
                .ToListAsync();
        }
    }
}
