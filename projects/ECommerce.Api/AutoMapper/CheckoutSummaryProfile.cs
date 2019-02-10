using AutoMapper;
using ECommerce.Api.Models;
using ECommerce.Checkout.Models;

namespace ECommerce.Api.AutoMapper
{
    public class CheckoutSummaryMapProfile : Profile
    {
        public CheckoutSummaryMapProfile()
        {
            CreateMap<CheckoutSummary, ApiCheckoutSummary>()
                .ForMember(x => x.Products, opt => opt.MapFrom(x => x.Products));

            CreateMap<CheckoutProduct, ApiCheckoutProduct>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.Product.Id))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Product.Name));
        }
    }
}
