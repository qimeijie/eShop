namespace OrderAPI.ApplicationCore.Entities
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public bool IsDefaultAddress { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
