using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Profiles;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace GloboTicket.TicketManagement.Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);



            services.AddMediatR(Assembly.GetExecutingAssembly());
          
                return services;
        }
    }
}
