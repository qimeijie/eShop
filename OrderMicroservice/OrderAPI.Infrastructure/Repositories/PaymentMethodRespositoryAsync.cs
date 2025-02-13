using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
    public class PaymentMethodRespositoryAsync : BaseRepositoryAsync<PaymentMethod>, IPaymentMethodRepositoryAsync
    {
        public PaymentMethodRespositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
