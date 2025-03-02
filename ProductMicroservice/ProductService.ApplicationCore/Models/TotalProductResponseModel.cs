namespace ProductMicroservice.ApplicationCore.Models
{
    public class TotalProductResponseModel
    {
        public int TotalNumber { get; set; }
        public IEnumerable<ProductResponseModel> Products { get; set; }
    }
}
