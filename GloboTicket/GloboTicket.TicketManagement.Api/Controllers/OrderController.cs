using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IActionResult Get( )
        {
            return Ok(_mediator.Send(new GetOrdersForMonthQueryHandler()))
        }
    }
}
