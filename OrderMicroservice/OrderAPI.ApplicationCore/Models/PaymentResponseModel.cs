namespace OrderAPI.ApplicationCore.Models
{
    public class PaymentResponseModel
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public string Expiry { get; set; }
        public bool IsDefault { get; set; }

        public PaymentTypeResponseModel PaymentTypeResponseModel { get; set; }
    }
}
