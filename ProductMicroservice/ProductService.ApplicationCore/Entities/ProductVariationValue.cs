namespace ProductMicroservice.ApplicationCore.Entities
{
    public class ProductVariationValue
    {
        public int ProductId { get; set; }
        public int VariationValueId { get; set; }
        public Product Product { get; set; }
        public VariationValue VariationValue { get; set; }
    }
}
