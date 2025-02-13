using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class OrderDetailsRepositoryAsync : BaseRepositoryAsync<OrderDetail>, IOrderDetailRepositoryAsync
    {
        private readonly OrderDbContext orderDbContext;

        public OrderDetailsRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await orderDbContext.OrderDetails.AsNoTracking().Where(od => od.OrderId == orderId).ToListAsync();
        }
    }
}
