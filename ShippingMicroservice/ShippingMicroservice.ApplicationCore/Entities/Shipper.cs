using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        [MinLength(2)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string? EmailId { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string? Phone { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        [MinLength(2)]
        public string ContactPerson { get; set; }

        public IEnumerable<ShippingDetail> ShippingDetails { get; set; }
        public IEnumerable<ShipperRegion> ShipperRegions { get; set; }
    }
}
