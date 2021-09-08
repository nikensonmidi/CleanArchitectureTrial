using DodoBed.Manufacturing.Application.Features.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Applicationregistration
    {

     
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var attributeType = typeof(ScopedService);
            var assembly = attributeType.Assembly;
            var definedTypes = assembly.DefinedTypes;
            var scopedServices = definedTypes.Where(s => s.GetTypeInfo().GetCustomAttribute<ScopedService>() != null);
            foreach (var scopedService in scopedServices)
            {
                services.AddScoped(scopedService);
            }

            return services;
        }
    }

    public class ScopedService:Attribute
    {

    }


}
