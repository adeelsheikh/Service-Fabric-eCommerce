using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;

namespace ECommerce.ProductCatalog.Models
{
    public static class ProductCatalogServiceResolver
    {
        public static IProductCatalogService Resolve()
        {
            return ServiceProxy.Create<IProductCatalogService>(
                new Uri("fabric:/ECommerce/ECommerce.ProductCatalog"),
                new ServicePartitionKey(0));
        }
    }
}
