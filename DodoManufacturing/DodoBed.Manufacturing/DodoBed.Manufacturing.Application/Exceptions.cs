using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application
{
    public class ValidationException:Exception
    {
        public ValidationException(string message):base(message)
        {

        }
        public IEnumerable<string> ValidationErrors { get; set; }

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
