using GloboTicket.TicketManagement.Application.Responses;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandResponse:BaseResponse
    {
        public CreateCategoryDto Category { get; set; }
        public CreateCategoryCommandResponse():base()
        {

        }
    }
}