﻿namespace OrderAPI.ApplicationCore.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<PaymentMethod> paymentMethods { get; set; }
    }
}
