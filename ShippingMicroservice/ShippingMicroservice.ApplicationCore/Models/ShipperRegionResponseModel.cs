namespace ShippingMicroservice.ApplicationCore.Models
{
    public class ShipperRegionResponseModel
    {
        public int RegionId { get; set; }
        public int ShipperId { get; set; }
        public bool Active { get; set; }
        public RegionResponseModel RegionResponseModel { get; set; }
    }
}