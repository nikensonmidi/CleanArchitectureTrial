using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
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
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedService : Attribute{}
}