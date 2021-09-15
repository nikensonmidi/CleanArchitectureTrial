using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DodoBed.Manufacturing.Application.Features.Products
{
    public static class ProductCommandValidator
    {

        public static async Task<CreateProductCommand> AsValid(this CreateProductCommand request, CreateProductCommandValidation validator)
        {
          
            var validation = await validator.ValidateAsync(request);
            if (validation.Errors.Count > 0) { throw new ValidationException(validation.Errors); }

            return request;
        }
        public static async Task<UpdateProductCommand> AsValid(this UpdateProductCommand request, UpdateProductCommandValidation validator)
        {

            var validation = await validator.ValidateAsync(request);
            if (validation.Errors.Count > 0) { throw new ValidationException(validation.Errors); }

            return request;
        }



    }
    [ScopedService]
    public class UpdateProductCommandValidation:AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull();

            RuleFor(e => e.Description)
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .NotNull();
            RuleFor(e => e.ProductId)
                .GreaterThan(0).WithMessage("{PropertyName} cannot be less than 0");
             
            RuleFor(e => e)
            .MustAsync(UniqueDescription).WithMessage("The description {PropertyValue} already exists.")
               .MustAsync(UniqueName).WithMessage("The name {PropertyValue} already exists.");

        }
        private async Task<bool> UniqueName(UpdateProductCommand e, CancellationToken token)
        {
    
            return ! _productRepository.GetAll().Any(p => p.ItemId != e.ProductId && p.Name.Trim().ToLower() == e.Name.Trim().ToLower() );
        }

        private async Task<bool> UniqueDescription(UpdateProductCommand e, CancellationToken token)
        {
            return !_productRepository.GetAll().Any(p => p.ItemId != e.ProductId && p.Description.Trim().ToLower() == e.Description.Trim().ToLower());
        }
    }
    [ScopedService]
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
      

        public CreateProductCommandValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(e => e.Description)
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MustAsync(UniqueDescription).WithMessage("That description already exist")
               .NotNull();
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotNull()
                .MustAsync(UniqueName).WithMessage("That name already exist")
                .MaximumLength(100).WithMessage("{PropertyName} cannot be longer than 100 characters");
            RuleFor(e => e.ProductId)
            .GreaterThan(0).WithMessage("{PropertyName} cannot be less than 0");
        }

        private async Task<bool> UniqueName(string name, CancellationToken token)
        {
            return !_productRepository.GetAll().Any(p =>  p.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        private async Task<bool> UniqueDescription(string desc, CancellationToken token)
        {
            return ! _productRepository.GetAll().Any(p => p.Description.Trim().ToLower() == desc.Trim().ToLower());
        }
    }

}
