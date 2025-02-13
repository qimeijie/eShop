using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.ApplicationCore.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        [ForeignKey("ShoppingCart")]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
