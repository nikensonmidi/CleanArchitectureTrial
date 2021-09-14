using DodoBed.Manufacturing.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Products
{
    public static class MiddlewareExtensions
    {

        public static  IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddlewareHandler>();
            return builder;
        }
    }


    public class ExceptionMiddlewareHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewareHandler(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {
               await  ConvertExceptiopn(ex,context);
            }

        }


        public Task ConvertExceptiopn(Exception ex,HttpContext context)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            string result = string.Empty;
            switch (ex)
            {
                case ValidationException validationEx:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationEx.ValidationErrors);
                    break;
                case BadRequestException validationEx:
                    statusCode = HttpStatusCode.BadRequest;                 
                    break;
                case NotFoundException validationEx:
                    statusCode = HttpStatusCode.NotFound;                   
                    break;
                default:
                    result = ex.Message;
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }



    }




}
