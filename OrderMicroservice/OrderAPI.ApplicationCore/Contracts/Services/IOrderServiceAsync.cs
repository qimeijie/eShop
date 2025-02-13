using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
        Task<OrderResponseModel> InsertAsync(OrderRequestModel orderRequestModel);
        Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int orderId);
        Task<string> CheckOrderStatusAsync(int orderId);
        Task<OrderResponseModel> CancelOrderAsync(int orderId);
        Task<OrderResponseModel> CompleteOrderAsync(int orderId);
        Task<OrderResponseModel> UpdateAsync(OrderRequestModel orderRequestModel);
    }
}
