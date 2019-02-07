using ECommerce.ProductCatalog.Domain;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.ProductCatalog.Communication
{
    public interface IProductCatalogService : IService
    {
        Task AddProduct(Product product);

        Task<IEnumerable<Product>> GetAllProducts();
    }
}
