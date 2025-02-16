namespace ShippingMicroservice.ApplicationCore.Contracts.Service
{
    public interface IOrderServiceAsync
    {
        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
    }
}
