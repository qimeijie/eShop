namespace ProductMicroservice.ApplicationCore.Entities
{
    public class VariationValue
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public string Value { get; set; }
        public CategoryVariation CategoryVariation { get; set; }
    }
}
