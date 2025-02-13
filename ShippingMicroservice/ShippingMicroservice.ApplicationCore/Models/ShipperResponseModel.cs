using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingMicroservice.ApplicationCore.Models
{
    public class ShipperResponseModel
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

        public IEnumerable<ShipperRegionResponseModel> ShipperRegionResponseModels { get; set; }
    }
}
