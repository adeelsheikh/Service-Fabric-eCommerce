using ECommerce.ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.ProductCatalog.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task AddProduct(Product product);

        Task DeleteProduct(Guid productId);

        Task RemoveAll();

        Task<Product> GetProduct(Guid productId);
    }
}
