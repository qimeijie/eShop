using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionsMicroservice.ApplicationCore.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        [MinLength(2, ErrorMessage = "Name must be more than 2")]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR(4000)")]
        public string Description { get; set; }
        [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100.")]
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PromotionState PromotionState { get; set; }

        public IEnumerable<PromotionDetail> PromotionDetails { get; set; }
    }

    public enum PromotionState
    {
        Active,
        InActive
    }
}
