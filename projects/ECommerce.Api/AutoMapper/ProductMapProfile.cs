using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.ProductCatalog.Models;
using System;

namespace ECommerce.Api.AutoMapper
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ApiProduct>()
                .ForMember(x => x.IsAvailable, opt => opt.MapFrom(x => x.Availability > 0));

            CreateMap<ApiProduct, Product>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id != null && x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
        }
    }
}
