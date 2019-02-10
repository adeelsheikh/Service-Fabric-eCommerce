using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.ProductCatalog.Models
{
    public interface IProductCatalogService : IService
    {
        Task AddProduct(Product product);

        Task DeleteProduct(Guid productId);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(Guid productId);
    }
}
