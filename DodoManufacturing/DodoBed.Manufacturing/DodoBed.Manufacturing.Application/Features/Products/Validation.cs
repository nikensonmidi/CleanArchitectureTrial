using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using FluentValidation;

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


      
    }
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
        }

        private async Task<bool> UniqueName(string name, CancellationToken token)
        {
            return !(await _productRepository.IsNameUnique(name));
        }

        private async Task<bool> UniqueDescription(string desc, CancellationToken token)
        {
            return !(await _productRepository.IsDescriptionUnique(desc));
        }
    }

}
