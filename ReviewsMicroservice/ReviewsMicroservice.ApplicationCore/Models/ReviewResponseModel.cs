using ReviewsMicroservice.ApplicationCore.Entities;
using System.Text.Json.Serialization;

namespace ReviewsMicroservice.ApplicationCore.Models
{
    public class ReviewResponseModel
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ProductId { get; set; }
        public string ProductName { get; set; }
        public double RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReviewState ReviewState { get; set; } 
    }
}
