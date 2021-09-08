using AutoMapper;
using DodoBed.Manufacturing.Application.Features.Products;
using DodoBed.Manufacturing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductId,
                opt => opt.MapFrom(src => src.ItemId)).ReverseMap();
            CreateMap<ProductDTO, UpdateProductCommand>().ReverseMap();
           
          
        }
    }
}
