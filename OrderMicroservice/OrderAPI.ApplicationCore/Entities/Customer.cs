namespace OrderAPI.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ProfilePic { get; set; }
        public int UserId { get; set; }

        public IEnumerable<UserAddress> UserAddresses { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    }
}
