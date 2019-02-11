using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;

namespace ECommerce.Checkout.Models
{
    public static class CheckoutServiceResolver
    {
        private static readonly Random random = new Random(DateTime.UtcNow.Second);

        public static ICheckoutService Resolve()
        {
            return ServiceProxy.Create<ICheckoutService>(
                new Uri("fabric:/ECommerce/ECommerce.CheckoutService"),
                new ServicePartitionKey(GetLong()));
        }

        private static long GetLong()
        {
            var buf = new byte[8];
            random.NextBytes(buf);
            return BitConverter.ToInt64(buf, 0);
        }
    }
}
