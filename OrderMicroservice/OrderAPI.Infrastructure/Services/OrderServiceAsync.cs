using AutoMapper;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Infrastructure.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IOrderRepositoryAsync orderRepositoryAsync;
        private readonly IOrderDetailRepositoryAsync orderDetailRepositoryAsync;

        public OrderServiceAsync(IMapper mapper, IOrderRepositoryAsync orderRepositoryAsync, IOrderDetailRepositoryAsync orderDetailRepositoryAsync)
        {
            this.mapper = mapper;
            this.orderRepositoryAsync = orderRepositoryAsync;
            this.orderDetailRepositoryAsync = orderDetailRepositoryAsync;
        }

        public async Task<OrderResponseModel> CancelOrderAsync(int orderId)
        {
            var order = await orderRepositoryAsync.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Cannot Cancel Order, Not Found");
            }
            order.OrderStatus = "Cancel";
            var updatedOrder = await orderRepositoryAsync.UpdateAsync(order);
            return mapper.Map<OrderResponseModel>(updatedOrder);
        }

        public async Task<string> CheckOrderStatusAsync(int orderId)
        {
            return (await orderRepositoryAsync.GetByIdAsync(orderId))?.OrderStatus ?? "Not Found";
        }

        public Task<OrderResponseModel> CompleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
        {
            var orders = await orderRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<OrderResponseModel>>(orders);
        }

        public async Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int orderId)
        {
            var orderDetails = await orderDetailRepositoryAsync.GetOrderDetailsByOrderIdAsync(orderId);
            return mapper.Map<IEnumerable<OrderDetailResponseModel>>(orderDetails);
        }

        public async Task<OrderResponseModel> InsertAsync(OrderRequestModel orderRequestModel)
        {
            var order = mapper.Map<Order>(orderRequestModel);
            order = await orderRepositoryAsync.InsertAsync(order);
            return mapper.Map<OrderResponseModel>(order);
        }

        public async Task<OrderResponseModel> UpdateAsync(OrderRequestModel orderRequestModel)
        {
            var order = mapper.Map<Order>(orderRequestModel);
            order = await orderRepositoryAsync.UpdateAsync(order);
            return mapper.Map<OrderResponseModel>(order);
        }
    }
}
