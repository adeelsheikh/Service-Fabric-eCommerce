using Newtonsoft.Json;
using System.Collections.Generic;

namespace ECommerce.Api.Models
{
    public class ApiCart
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("item")]
        public IEnumerable<ApiCartItem> Items { get; set; }
    }
}
