using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;

namespace ECommerce.Checkout.Models
{
    public static class CheckoutServiceResolver
    {
        public static ICheckoutService Resolve()
        {
            return ServiceProxy.Create<ICheckoutService>(
                new Uri("fabric:/ECommerce/ECommerce.Checkout"),
                new ServicePartitionKey(0));
        }
    }
}
