using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class OrderRepositoryAsync : BaseRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly OrderDbContext orderDbContext;

        public OrderRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public Task<Order> GetOrderWithDetailbyIdAsync(int id)
        {
            return orderDbContext.Orders.AsNoTracking().Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentByCustomerIdAsync(int customerId)
        {
            return await orderDbContext.Orders.AsNoTracking()
                .Where(o => o.CustomerId == customerId)
                .SelectMany(o => o.PaymentMethods)
                .ToListAsync();
        }
    }
}
