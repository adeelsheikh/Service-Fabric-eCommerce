using Newtonsoft.Json;

namespace ECommerce.Api.Models
{
    public class ApiCartItem
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
