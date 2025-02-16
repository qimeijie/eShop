using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public decimal BillAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
        public Customer Customer { get; set; }
    }

    public enum OrderStatus
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
