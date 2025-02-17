using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderCompletedEventResponseModel>> GetAllOrdersAsync();
        Task<OrderCompletedEventResponseModel> InsertAsync(OrderRequestModel orderRequestModel);
        Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int orderId);
        Task<string> CheckOrderStatusAsync(int orderId);
        Task<OrderCompletedEventResponseModel> CancelOrderAsync(int orderId);
        Task<OrderCompletedEventResponseModel> OrderCompletedAsync(int orderId);
        Task<OrderCompletedEventResponseModel> UpdateAsync(OrderRequestModel orderRequestModel);
        Task<bool> UpdateOrderStatusAsync(int id, string status);
    }
}
