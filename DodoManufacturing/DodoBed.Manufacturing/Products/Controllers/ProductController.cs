using DodoBed.Manufacturing.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;
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
            _mediatr = mediatr ;
        }


        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get() => Ok(await _mediatr.Send(new ProductListQuery()));




        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createCommand) => Ok(await _mediatr.Send(createCommand));

        [HttpPost("AddProducts")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProducts([FromBody] CreateProductsCommand createCommand) => Ok(await _mediatr.Send(createCommand));



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateProductCommand updateCommand) => Ok(await _mediatr.Send(updateCommand));
        [HttpPut("UpdateProducts")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProducts( [FromBody] UpdateProductsCommand updateCommand) => Ok(await _mediatr.Send(updateCommand));



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(long id)=> Ok(await _mediatr.Send(new DeleteProductCommand { ProductId = id }));
        [HttpDelete("DeleteProducts")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProducts([FromBody] DeleteProductsCommand deleteProductsCommand) => Ok(await _mediatr.Send(deleteProductsCommand));

    }
}
