using Microsoft.Extensions.DependencyInjection;
using System;
using DodoBed.Manufacturing.Application;
using BenchMarks.Applicatrion;
using BenchmarkDotNet.Running;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;

namespace BenchMarks
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //var serviceProvider = new ServiceCollection()
            //   .AddApplicationServices()
            //   .AddSingleton<IProductRepository, ProductRepoMock>()
            //   .AddMediatR(Assembly.GetExecutingAssembly())
               
            //   .BuildServiceProvider();

          

            var benchProduct = BenchmarkRunner.Run<ProductQuery>();

        }
    }
}
