using DodoBed.Manufacturing.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products
{
    [Route("odata")]
   
    public class ProductController : ODataController
    {
        private readonly IMediator _mediatr;
     
        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediatr.Send(new ProductListQuery());
            return Ok(products);
        }

      
      
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createCommand)
        {
            return Ok(await _mediatr.Send(createCommand));
        }

      
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
