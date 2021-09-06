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
    public class ProductListQuery:IRequest<IEnumerable<ProductDTO>>
    {

    }
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts =  _productRepository.GetAll().AsQueryable();
            return _mapper.Map<IEnumerable<ProductDTO>>(allProducts);
        }
    }
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
