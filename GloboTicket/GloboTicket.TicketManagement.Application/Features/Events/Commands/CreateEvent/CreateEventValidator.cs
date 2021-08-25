using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventValidator:AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);
            //custom validation
            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name already exists");
        }


        public async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)=> !await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date);



    }
}
