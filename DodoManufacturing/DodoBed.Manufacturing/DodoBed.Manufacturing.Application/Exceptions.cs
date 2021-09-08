using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application
{
    public class ValidationException:ApplicationException
    {
        public ValidationException(string message):base(message)
        {

        }
        public ValidationException(IEnumerable<ValidationFailure> failures )
        {
            ValidationErrors = new List<string>();
            foreach (var item in failures)
            {

                ValidationErrors.Add(item.ErrorMessage);
            }
        }
        public List<string> ValidationErrors { get; set; }

    }

    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string message):base(message)
        {

        }
    }

    public class BadRequestException:ApplicationException
    {
        public BadRequestException(string message):base(message)
        {

        }
       
    }

   


}
