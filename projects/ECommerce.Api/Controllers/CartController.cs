using ECommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserActor.Interfaces;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ApiCart> Get(string userId)
        {
            var products = await UserActorResolver.Resolve(userId).GetCartItems();

            return new ApiCart
            {
                UserId = userId,
                Items = products.Select(x => new ApiCartItem
                {
                    ProductId = x.Key.ToString(),
                    Quantity = x.Value
                })
            };
        }

        [HttpPost("{userId}")]
        public async Task Add(string userId, [FromBody] ApiCartAddRequest request)
        {
            await UserActorResolver.Resolve(userId).AddToCart(request.ProductId, request.Quantity);
        }

        [HttpDelete("{userId}")]
        public async Task Clear(string userId)
        {
            await UserActorResolver.Resolve(userId).ClearCart();
        }
    }
}