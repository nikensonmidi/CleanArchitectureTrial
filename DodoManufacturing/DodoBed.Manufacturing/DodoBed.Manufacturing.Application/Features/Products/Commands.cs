using AutoMapper;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application.Features.Products
{
    public class CreateProductCommand:IRequest<long>
    {
        public long ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
           var response =  await _productRepository.AddAsync(product);
            return response.ItemId;
        }
    }


}
