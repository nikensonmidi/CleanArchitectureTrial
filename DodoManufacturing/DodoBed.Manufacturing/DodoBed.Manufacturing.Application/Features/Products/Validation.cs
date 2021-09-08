using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DodoBed.Manufacturing.Application.Features.Products
{
    public static class ProductCommandValidator
    {

        public static async Task<CreateProductCommand> AsValid(this CreateProductCommand request)
        {
          
            var validation = await new CreateProductCommandValidation().ValidateAsync(request);
            if (validation.Errors.Count > 0) { throw new ValidationException(validation.Errors); }

            return request;
        }
    }
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
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
