using Newtonsoft.Json;
using System;

namespace ECommerce.Api.Models
{
    public class ApiCartAddRequest
    {
        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
