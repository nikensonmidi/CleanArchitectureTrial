using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Products.Filters;
using Serilog;
using System;
using System.IO;
using System.Linq;

namespace Products
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlPersistence(Configuration);
            services.AddApplicationServices();

            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", new ProductEntityDataModel().GetEdmModel()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products", Version = "v1" });
            });


            // In order to make swagger work with OData
            services.AddMvcCore(options =>
            {
                // options.Filters.Add(typeof(ApplicationExceptionFilter));
                options.Filters.Add(new ApplicationExceptionFilter(Log.Logger));
                foreach (var outputFormatter in options.OutputFormatters.OfType<OutputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    //Microsoft.AspNetCore.Mvc.Formatters => MediaTypeHeaderValue
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in options.InputFormatters.OfType<InputFormatter>().Where(x => x.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
           // app.UseCustomExceptionHandler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
