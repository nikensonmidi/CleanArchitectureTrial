
using DodoBed.Manufacturing.Application.Features.Products;
using DodoBed.Manufacturing.Domain.Entities;
using AutoMapper;

namespace DodoBed.Manufacturing.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductId,
                opt => opt.MapFrom(src => src.ItemId))              
                .ReverseMap();
            CreateMap<ProductDTO, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
          
        }
    }
}
