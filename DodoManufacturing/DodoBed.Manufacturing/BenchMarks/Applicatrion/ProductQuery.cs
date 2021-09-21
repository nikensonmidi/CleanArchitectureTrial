using AutoMapper;
using BenchmarkDotNet.Attributes;
using DodoBed.Manufacturing.Application.Features.Products;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarks.Applicatrion
{
    [MemoryDiagnoser]
    public class ProductQuery
    {
        private readonly Mock<IProductRepository> _productRepo;
        public ProductQuery( )
        {
            _productRepo = new Mock<IProductRepository>();
            _productRepo.Setup(e => e.GetAll()).Returns(GenerateProducts(100));
        }
        [Benchmark(Baseline =true)]
        public async Task GetProductQueryStats( )
        {
            var products = _productRepo.Object.GetAll();
        }

        [Benchmark]
        public async Task GetProductsLambda()
        {
      
            var products = _productRepo.Object.GetAll();
            products= products.Where(e => e.ItemId > 1);
        }
        [Benchmark]
        public async Task GetProductsQuery()
        {
            var products = from p in _productRepo.Object.GetAll()
                           where p.ItemId > 1
                           select p;
                           


        }

        private IEnumerable<Product> GenerateProducts(int iteration)
        {
            List<Product> p = new List<Product>();
            for (int i = 0; i < iteration; i++)
            {

                p.Add(new Product
                {
                    Name="product "+i,
                    Description ="Product despcription "+i,
                    ItemId = i
                });
            }
            return p;
        }




    }


}
