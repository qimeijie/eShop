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

        public async Task<OrderCompletedEventResponseModel> CancelOrderAsync(int orderId)
        {
            var order = await orderRepositoryAsync.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Cannot Cancel Order, Not Found");
            }
            order.OrderStatus = OrderStatus.Canceled;
            var updatedOrder = await orderRepositoryAsync.UpdateAsync(order);
            return mapper.Map<OrderCompletedEventResponseModel>(updatedOrder);
        }

        public async Task<string> CheckOrderStatusAsync(int orderId)
        {
            return (await orderRepositoryAsync.GetByIdAsync(orderId))?.OrderStatus.ToString() ?? "Not Found";
        }

        public async Task<OrderCompletedEventResponseModel> OrderCompletedAsync(int orderId)
        {
            var order = await orderRepositoryAsync.GetOrderWithDetailbyIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Cannot Complete Order, Not Found");
            }
            order.OrderStatus = OrderStatus.Completed;
            var updatedOrder = await orderRepositoryAsync.UpdateAsync(order);
            return mapper.Map<OrderCompletedEventResponseModel>(updatedOrder);
        }

        public async Task<IEnumerable<OrderCompletedEventResponseModel>> GetAllOrdersAsync()
        {
            var orders = await orderRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<OrderCompletedEventResponseModel>>(orders);
        }

        public async Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int orderId)
        {
            var orderDetails = await orderDetailRepositoryAsync.GetOrderDetailsByOrderIdAsync(orderId);
            return mapper.Map<IEnumerable<OrderDetailResponseModel>>(orderDetails);
        }

        public async Task<OrderCompletedEventResponseModel> InsertAsync(OrderRequestModel orderRequestModel)
        {
            var order = mapper.Map<Order>(orderRequestModel);
            order = await orderRepositoryAsync.InsertAsync(order);
            return mapper.Map<OrderCompletedEventResponseModel>(order);
        }

        public async Task<OrderCompletedEventResponseModel> UpdateAsync(OrderRequestModel orderRequestModel)
        {
            var order = mapper.Map<Order>(orderRequestModel);
            order = await orderRepositoryAsync.UpdateAsync(order);
            return mapper.Map<OrderCompletedEventResponseModel>(order);
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string status)
        {
            if(!Enum.TryParse(status, true, out OrderStatus orderStatus))
            {
                return false;
            }
            var order =await orderRepositoryAsync.GetByIdAsync(id);
            if(order == null)
            {
                return false;
            }
            order.OrderStatus = orderStatus;
            await orderRepositoryAsync.UpdateAsync(order);
            return true;
        }
    }
}
