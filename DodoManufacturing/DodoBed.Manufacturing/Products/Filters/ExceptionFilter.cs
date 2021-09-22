using DodoBed.Manufacturing.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;
using Serilog;
using System;

namespace Products.Filters
{
    public class ApplicationExceptionFilter :  IExceptionFilter
    {
        private readonly ILogger _loogger;

        public ApplicationExceptionFilter(ILogger logger)
        {
            _loogger = logger;
        }

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
                    _loogger.Error(validationEx, result);
                    break;
                case BadRequestException validationEx:
                    _loogger.Error(validationEx, "Bad Request");
                    ex.Result = new BadRequestObjectResult(400);
                    break;
                case NotFoundException validationEx:
                    ex.Result = new NotFoundObjectResult(404);
                    _loogger.Error(validationEx, "Not found");
                    break;
                default:
                    _loogger.Error(ex.Exception, "Server Error");
                    ex.Result = new StatusCodeResult(500);
                    break;
            }
          


        }
    }
}
