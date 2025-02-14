using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionsMicroservice.ApplicationCore.Entities
{
    public class PromotionDetail
    {
        public int Id { get; set; }
        [ForeignKey("Promotion")]
        public int PromotionId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        public Promotion Promotion { get; set; }
    }
}
