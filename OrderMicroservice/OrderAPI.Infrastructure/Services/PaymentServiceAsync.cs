using AutoMapper;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Infrastructure.Services
{
    public class PaymentServiceAsync : IPaymentServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IPaymentMethodRepositoryAsync paymentMethodRepositoryAsync;
        private readonly IOrderRepositoryAsync orderRepositoryAsync;

        public PaymentServiceAsync(IMapper mapper, IPaymentMethodRepositoryAsync paymentMethodRepositoryAsync, IOrderRepositoryAsync orderRepositoryAsync)
        {
            this.mapper = mapper;
            this.paymentMethodRepositoryAsync = paymentMethodRepositoryAsync;
            this.orderRepositoryAsync = orderRepositoryAsync;
        }

        public Task<int> DeleteAsync(int id)
        {
            return paymentMethodRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<PaymentResponseModel>> GetPaymentByCustomerIdAsync(int customerId)
        {
            var payments = await orderRepositoryAsync.GetPaymentByCustomerId(customerId);
            return mapper.Map<IEnumerable<PaymentResponseModel>>(payments);
        }

        public async Task<PaymentResponseModel> InsertAsync(PaymentRequestModel paymentRequestModel)
        {
            var response = await paymentMethodRepositoryAsync.InsertAsync(mapper.Map<PaymentMethod>(paymentRequestModel));
            return mapper.Map<PaymentResponseModel>(response);
        }

        public async Task<PaymentResponseModel> UpdateAsync(PaymentRequestModel paymentRequestModel)
        {
            var response = await paymentMethodRepositoryAsync.UpdateAsync(mapper.Map<PaymentMethod>(paymentRequestModel));
            return mapper.Map<PaymentResponseModel>(response);
        }
    }
}
