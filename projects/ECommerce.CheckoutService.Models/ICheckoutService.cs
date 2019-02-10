using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Checkout.Models
{
    public interface ICheckoutService : IService
    {
        Task<CheckoutSummary> CheckoutCart(string userId);

        Task<IEnumerable<CheckoutSummary>> GetOrderHitory(string userId);
    }
}
