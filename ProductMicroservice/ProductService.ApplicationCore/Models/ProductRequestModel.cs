﻿namespace ProductMicroservice.ApplicationCore.Models
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quality { get; set; }
        public string ProductImage { get; set; }
        public string SKU { get; set; }
    }
}
