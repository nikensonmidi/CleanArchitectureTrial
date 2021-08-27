using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    //This is where the registrations of all depencies happen.
    //The clients that uses this library would need the help of this extension to register this assembly's registration
    public static class PersistenceServiceregistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<GloboTicketDBcontext>(options => options.UseSqlServer("GloboTicketTicketManagementConnectionString"));
            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
