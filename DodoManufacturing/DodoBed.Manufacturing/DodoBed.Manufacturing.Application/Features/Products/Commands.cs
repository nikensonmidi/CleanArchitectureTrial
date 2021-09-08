﻿using AutoMapper;
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
            request = await request.AsValid();
            var product = _mapper.Map<Product>(request);
            bool isDuplicated = _productRepository.GetAll().Any(e =>  e.Name.Trim().ToLower() == product.Name.Trim().ToLower());
            if (isDuplicated) { throw new BadRequestException($"That name {product.Name} already exist."); }
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
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommand> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var updatedProduct = _mapper.Map<Product>(request);
           bool isDuplicated = _productRepository.GetAll().Any(e => e.ItemId != updatedProduct.ItemId && e.Name.Trim().ToLower() == updatedProduct.Name.Trim().ToLower());
            if (isDuplicated) { throw new BadRequestException($"That name {updatedProduct.Name} already exist."); }
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
