using Newtonsoft.Json;
using System;

namespace ECommerce.Api.Models
{
    public class ApiCheckoutProduct
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
