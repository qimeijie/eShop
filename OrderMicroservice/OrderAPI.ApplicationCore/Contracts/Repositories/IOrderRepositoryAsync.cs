using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentByCustomerIdAsync(int customerId);
        Task<Order> GetOrderWithDetailbyIdAsync(int id);
    }
}
