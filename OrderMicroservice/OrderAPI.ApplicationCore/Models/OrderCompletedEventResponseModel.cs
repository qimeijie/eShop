using OrderAPI.ApplicationCore.Entities;
using System.Text.Json.Serialization;

namespace OrderAPI.ApplicationCore.Models
{
    public class OrderCompletedEventResponseModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public decimal BillAmount { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderDetailResponseModel> OrderDetailResponseModels { get; set; }
    }
}
