namespace OrderAPI.ApplicationCore.Models
{
    public class PaymentRequestModel
    {
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public string Expiry { get; set; }
        public bool IsDefault { get; set; }

    }
}
