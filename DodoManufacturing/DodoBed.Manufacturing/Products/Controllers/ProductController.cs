using DodoBed.Manufacturing.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products
{
    [Route("Product")]
    public class ProductController : ODataController
    {
        private readonly IMediator _mediatr;
     
        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

       
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var products = await _mediatr.Send(new ProductListQuery());
            return Ok(products);
        }

      
      
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createCommand)
        {
            return Ok(await _mediatr.Send(createCommand));
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateProductCommand updateCommand)
        {
            return Ok(await _mediatr.Send(updateCommand));
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _mediatr.Send(new DeleteProductCommand { ProductId = id }));
        }
    }
}
