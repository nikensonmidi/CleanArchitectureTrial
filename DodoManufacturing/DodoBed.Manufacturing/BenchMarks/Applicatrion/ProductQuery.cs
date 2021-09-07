using AutoMapper;
using BenchmarkDotNet.Attributes;
using DodoBed.Manufacturing.Application.Features.Products;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.Domain.Entities;
using MediatR;
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
        private readonly ProductRepoMock _productRepo;
        public ProductQuery( )
        {
            _productRepo = new ProductRepoMock(10000);
        }
        [Benchmark(Baseline =true)]
        public async Task GetProductQueryStats( )
        {
            var products = _productRepo.GetAll();
        }

        [Benchmark]
        public async Task GetProductsLambda()
        {
      
            var products =_productRepo.GetAll();
            products= products.Where(e => e.ItemId > 1);
        }
        [Benchmark]
        public async Task GetProductsQuery()
        {
            var products = from p in _productRepo.GetAll()
                           where p.ItemId > 1
                           select p;
                           


        }
    }

    public class ProductRepoMock : IProductRepository
    {
        private IEnumerable<Product> _products;
        private IQueryable<Product> _queriedProducts;
        public ProductRepoMock()
        {
            SetMockdata();
        }
        public ProductRepoMock(int iterations)
        {
            SetMockdata(iterations);
        }
        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
            => _products;
        public IQueryable<Product> GetAllQueryable()
           => _queriedProducts;



        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }


        public void SetMockdata(int length = 100 )
        {
            var tempList = new List<Product>();
            for (int i = 0; i < length; i++)
            {
                tempList.Add(new Product { ItemId = i, Name = $"item{1}", Description = $"descrtion item{i}" });
            }
            _products = tempList;
            _queriedProducts = tempList.AsQueryable();
        }
    }




}
