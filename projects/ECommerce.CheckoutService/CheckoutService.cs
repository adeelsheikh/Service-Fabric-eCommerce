using ECommerce.Checkout.Models;
using ECommerce.ProductCatalog.Models;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserActor.Interfaces;

namespace ECommerce.CheckoutService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class CheckoutService : StatefulService, ICheckoutService
    {
        public CheckoutService(StatefulServiceContext context)
            : base(context)
        { }

        public async Task<CheckoutSummary> CheckoutCart(string userId)
        {
            var result = new CheckoutSummary
            {
                Date = DateTime.UtcNow,
                Products = new List<CheckoutProduct>()
            };

            var userActor = UserActorResolver.Resolve(userId);
            var cartItems = await userActor.GetCartItems();

            var catalogService = ProductCatalogServiceResolver.Resolve();

            foreach (var cartItem in cartItems)
            {
                var product = await catalogService.GetProduct(cartItem.Key);
                result.Products.Add(new CheckoutProduct
                {
                    Product = product,
                    Price = product.Price,
                    Quantity = cartItem.Value
                });
            }

            result.TotalPrice = result.Products.Sum(p => p.Price);

            await userActor.ClearCart();

            await AddToHistory(result);

            return result;
        }

        public async Task<IEnumerable<CheckoutSummary>> GetOrderHitory(string userId)
        {
            var result = new List<CheckoutSummary>();
            var history = await StateManager.GetOrAddAsync<IReliableDictionary<DateTime, CheckoutSummary>>("history");

            using (var tx = StateManager.CreateTransaction())
            {
                var enumerable = await history.CreateEnumerableAsync(tx, EnumerationMode.Unordered);

                using (var enumerator = enumerable.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        result.Add(enumerator.Current.Value);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return this.CreateServiceRemotingReplicaListeners();
        }

        private async Task AddToHistory(CheckoutSummary checkout)
        {
            var history = await StateManager
                .GetOrAddAsync<IReliableDictionary<DateTime, CheckoutSummary>>("history");

            using (var tx = StateManager.CreateTransaction())
            {
                await history.AddAsync(tx, checkout.Date, checkout);

                await tx.CommitAsync();
            }
        }
    }
}
