using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsMicroservice.ApplicationCore.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        [MinLength(2, ErrorMessage = "Length of CustomerName must be more than 2")]
        public string CustomerName { get; set; }
        public string? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ProductId { get; set; }
        [Column(TypeName = "NVARCHAR(255)")]
        [MinLength(2, ErrorMessage = "Length of ProductName must be more than 2")]
        public string ProductName { get; set; }
        public double RatingValue { get; set; }
        [Column(TypeName = "NVARCHAR(500)")]
        [MinLength(2, ErrorMessage = "Length of Comment must be more than 2")]
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public ReviewState ReviewState { get; set; } = ReviewState.UnSet;
    }
    public enum ReviewState
    {
        Approved,
        Rejected,
        UnSet
    }
}
