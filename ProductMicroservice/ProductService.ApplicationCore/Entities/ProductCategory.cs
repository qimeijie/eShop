namespace ProductMicroservice.ApplicationCore.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public ProductCategory ParentCategory { get; set; }
        public IEnumerable<ProductCategory> ChildCategories { get; set; }
    }
}
