using ECommerce.ProductCatalog.Contracts;
using ECommerce.ProductCatalog.Domain;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.ProductCatalog.Services
{
    public class ServiceFabricProductRepository : IProductRepository
    {
        private readonly IReliableStateManager _stateManager;
        private IReliableDictionary<Guid, Product> _productsCollection;

        public ServiceFabricProductRepository(IReliableStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        private IReliableDictionary<Guid, Product> ProductsCollection =>
            _productsCollection ?? (_productsCollection = _stateManager.GetOrAddAsync<IReliableDictionary<Guid, Product>>("products").Result);

        public async Task AddProduct(Product product)
        {
            using (var tx = _stateManager.CreateTransaction())
            {
                await ProductsCollection.AddOrUpdateAsync(tx, product.Id, product, (id, value) => product);

                await tx.CommitAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var result = new List<Product>();

            using (var tx = _stateManager.CreateTransaction())
            {
                var enumerable = await ProductsCollection.CreateEnumerableAsync(tx, EnumerationMode.Unordered);

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

        public async Task RemoveAll()
        {
            using (var tx = _stateManager.CreateTransaction())
            {
                var enumerable = await ProductsCollection.CreateEnumerableAsync(tx, EnumerationMode.Unordered);

                using (var enumerator = enumerable.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        await ProductsCollection.TryRemoveAsync(tx, enumerator.Current.Key);
                    }
                }

                await tx.CommitAsync();
            }
        }
    }
}
