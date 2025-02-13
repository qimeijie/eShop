namespace OrderAPI.ApplicationCore.Models
{
    public class CustomerAddressRequestModel
    {
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int CustomerId { get; set; }
        public bool IsDefaultAddress { get; set; }
    }
}
