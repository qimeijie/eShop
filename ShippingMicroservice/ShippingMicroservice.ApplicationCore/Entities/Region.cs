namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ShipperRegion> ShipperRegions { get; set; }
    }
}
