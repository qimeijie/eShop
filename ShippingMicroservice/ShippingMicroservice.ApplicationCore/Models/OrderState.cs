namespace ShippingMicroservice.ApplicationCore.Models
{
    public enum OrderState
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Completed,
        Canceled,
        Returned
    }
}
