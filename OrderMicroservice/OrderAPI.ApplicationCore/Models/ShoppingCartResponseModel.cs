namespace OrderAPI.ApplicationCore.Models
{
    public class ShoppingCartResponseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public IEnumerable<ShoppingCartItemResponseModel> ShoppingCartItems { get; set; }
    }
}
