using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.SqlPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class PersistenceRegistration
    {

        public static IServiceCollection AddSqlPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DodoBedManufacturingContext>(options => options.UseSqlServer(configuration["connectionStrings:dodobed_manufacturing"]));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
