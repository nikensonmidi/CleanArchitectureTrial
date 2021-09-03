using AutoMapper;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application.Features.Products
{
    public class ProductListQuery:IRequest<IQueryable<ProductDTO>>
    {

    }
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IQueryable<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IQueryable<ProductDTO>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts =  _productRepository.GetAll();
            return _mapper.Map<IQueryable<ProductDTO>>(allProducts);
        }
    }
    public class ProductDTO
    {
        public long ItemId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
