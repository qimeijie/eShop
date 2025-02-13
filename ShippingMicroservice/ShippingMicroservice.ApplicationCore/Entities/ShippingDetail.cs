using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class ShippingDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("Shipper")]
        public int ShipperId { get; set; }
        public string ShippingStatus { get; set; }
        public string TrackingNumber { get; set; }
        public Shipper Shipper { get; set; }
    }
}
