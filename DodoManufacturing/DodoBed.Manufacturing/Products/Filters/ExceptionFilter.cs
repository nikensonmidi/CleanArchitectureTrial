using DodoBed.Manufacturing.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Products.Filters
{
    public class ApplicationExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            ConvertExceptiopn(context);
        }

        public void ConvertExceptiopn(ExceptionContext ex)
        {
       
            string result = string.Empty;
            switch (ex.Exception)
            {
                case ValidationException validationEx:
                    result = JsonConvert.SerializeObject(validationEx.ValidationErrors);
                    ex.Result = new BadRequestObjectResult(result);
                  
                    break;
                case BadRequestException validationEx:
                    ex.Result = new BadRequestObjectResult(400);
                    break;
                case NotFoundException validationEx:
                    ex.Result = new NotFoundObjectResult(404);
                    break;
                default:
                    ex.Result = new StatusCodeResult(500);
                    break;
            }
          
          
        }
    }
}
