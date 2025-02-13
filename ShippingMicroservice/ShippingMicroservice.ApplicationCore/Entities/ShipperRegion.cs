using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class ShipperRegion
    {
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        [ForeignKey("Shipper")]
        public int ShipperId { get; set; }
        public bool Active { get; set; }

        public Region Region { get; set; }
        public Shipper Shipper { get; set; }
    }
}
