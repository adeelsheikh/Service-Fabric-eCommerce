using ECommerce.ProductCatalog.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.ProductCatalog.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task AddProduct(Product product);
    }
}
