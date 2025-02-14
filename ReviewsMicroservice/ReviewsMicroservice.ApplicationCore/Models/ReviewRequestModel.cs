using ReviewsMicroservice.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReviewsMicroservice.ApplicationCore.Models
{
    public class ReviewRequestModel
    {
        public string? CustomerId { get; set; }
        [Required(ErrorMessage = "CustomerName is required.")]
        [StringLength(256, ErrorMessage = "CustomerName cannot exceed 256 characters.")]
        [MinLength(2, ErrorMessage = "Length of CustomerName must be more than 2")]
        public string CustomerName { get; set; }
        public string? OrderId { get; set; }
        [Required(ErrorMessage = "OrderDate is required.")]
        public DateTime OrderDate { get; set; }
        public string? ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is required.")]
        [StringLength(255, ErrorMessage = "ProductName cannot exceed 255 characters.")]
        [MinLength(2, ErrorMessage = "Length of ProductName must be more than 2")]
        public string ProductName { get; set; }
        public double RatingValue { get; set; }
        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        [MinLength(2, ErrorMessage = "Length of Comment must be more than 2")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "ReviewDate is required.")]
        public DateTime ReviewDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReviewState ReviewState { get; set; }
    }
}
