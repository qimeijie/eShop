using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
    public interface IOrderDetailRepositoryAsync : IRepositoryAsync<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId); 
    }
}
