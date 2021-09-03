using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Orders
{
    public class GetOrderQuery:IRequest<OrderDTO>
    {

    }

    public class OrderDTO
    {
    }
}
