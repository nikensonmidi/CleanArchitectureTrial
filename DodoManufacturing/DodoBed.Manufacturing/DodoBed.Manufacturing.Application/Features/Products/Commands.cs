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
    public class CreateProductCommand: ProductDTO,IRequest<long>
    {
    }

   public  class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductCommandValidation _validator;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, CreateProductCommandValidation validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            request = await request.AsValid(_validator);
            var product = _mapper.Map<Product>(request);
         
            var response =  await _productRepository.AddAsync(product);
            return response.ItemId;
        }
    }

    public class UpdateProductCommand:ProductDTO, IRequest<UpdateProductCommand>
    {

    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly UpdateProductCommandValidation _validator;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, UpdateProductCommandValidation validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateProductCommand> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            request = await request.AsValid(_validator);
            var updatedProduct = _mapper.Map<Product>(request);
       
            var product = await  _productRepository.UpdateAsync(updatedProduct);
            _mapper.Map(product, request, typeof(Product), typeof(UpdateProductCommand));
            return request;
        }
    }

    public class DeleteProductCommand: ProductDTO, IRequest
    {
      
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async  Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var deletedProduct = _productRepository.GetAll().FirstOrDefault(e => e.ItemId == request.ProductId);
            if(deletedProduct == null) { throw new BadRequestException("Unable to locate product"); }
            await _productRepository.DeleteAsync(deletedProduct);
            return Unit.Value;
        }
    }




}
