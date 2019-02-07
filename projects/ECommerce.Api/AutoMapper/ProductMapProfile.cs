using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.ProductCatalog.Domain;

namespace ECommerce.Api.AutoMapper
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ApiProduct>();

            CreateMap<ApiProduct, Product>();
        }
    }
}
