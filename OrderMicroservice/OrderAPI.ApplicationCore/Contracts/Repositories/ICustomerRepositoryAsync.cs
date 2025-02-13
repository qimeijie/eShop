using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
    public interface ICustomerRepositoryAsync : IRepositoryAsync<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerAddressByUserIdAsync(int userId);

    }
}
