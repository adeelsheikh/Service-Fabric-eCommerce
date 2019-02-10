using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.Checkout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CheckoutController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("{userId}")]
        public async Task<ApiCheckoutSummary> Checkout(string userId)
        {
            var summary = await CheckoutServiceResolver.Resolve().CheckoutCart(userId);

            return _mapper.Map<ApiCheckoutSummary>(summary);
        }

        [Route("history/{userId}")]
        public async Task<IEnumerable<ApiCheckoutSummary>> GetHistory(string userId)
        {
            var history = await CheckoutServiceResolver.Resolve().GetOrderHitory(userId);

            return history.Select(_mapper.Map<ApiCheckoutSummary>);
        }
    }
}
