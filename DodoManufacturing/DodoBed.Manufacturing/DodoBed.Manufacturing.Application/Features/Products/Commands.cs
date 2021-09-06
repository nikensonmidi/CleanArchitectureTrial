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
using FluentValidation;

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
            request = await request.Validate();
            var product = _mapper.Map<Product>(request);
           var response =  await _productRepository.AddAsync(product);
            return response.ItemId;
        }
    }

    public static class ProductCommandValidator
    {

        public static async Task<CreateProductCommand> Validate(this CreateProductCommand request)
        {
            var validation =  await  new CreateProductCommandValidation().ValidateAsync(request); 
            if(validation.Errors.Count > 0) { throw new ValidationException(validation.Errors); }
            
            return request;
        }
    }
    public  class CreateProductCommandValidation: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull();
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} cannot be longer than 100 characters");
        }
      
    }


}
