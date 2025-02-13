using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentByCustomerId(int customerId);
    }
}
