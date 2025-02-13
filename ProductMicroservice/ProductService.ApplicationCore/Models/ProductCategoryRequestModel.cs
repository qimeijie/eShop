namespace ProductMicroservice.ApplicationCore.Models
{
    public class ProductCategoryRequestModel
    {
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
