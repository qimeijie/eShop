using PromotionsMicroservice.ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PromotionsMicroservice.ApplicationCore.Models
{
    public class PromotionRequestModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Name must be less than 256")]
        [MinLength(2, ErrorMessage = "Name must be more than 2")]
        public string Name { get; set; }
        [Required]
        [StringLength(5000, ErrorMessage = "Name must be less than 5000")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100.")]
        public double Discount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PromotionState PromotionState { get; set; }
    }
}
