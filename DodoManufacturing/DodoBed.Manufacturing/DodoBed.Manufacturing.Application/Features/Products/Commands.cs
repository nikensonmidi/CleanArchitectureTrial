using AutoMapper;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace DodoBed.Manufacturing.Application.Features.Products
{
    public class CreateProductCommand : ProductDTO, IRequest<long>
    {
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductCommandValidation _validator;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, CreateProductCommandValidation validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            request = await request.AsValid(_validator);
            var product = _mapper.Map<Product>(request);

            var response = await _productRepository.AddAsync(product);
            return response.ItemId;
        }
    }
    public class CreateProductsCommand:IRequest<IEnumerable<long>>
    {
        public ICollection<CreateProductCommand> ProductCommands { get; set; }
    }
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, IEnumerable<long>>
    {
      
        private readonly IMediator _mediator;

        public CreateProductsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async  Task<IEnumerable<long>> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            List<long> newIds = new List<long>();

            foreach (var command in request.ProductCommands)
            {
                var newId = await _mediator.Send(command);
                newIds.Add(newId);
            }
            return newIds;

        }
    }


    public class UpdateProductCommand : ProductDTO, IRequest<UpdateProductCommand>
    {

    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly UpdateProductCommandValidation _validator;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, UpdateProductCommandValidation validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateProductCommand> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            request = await request.AsValid(_validator);
            var updatedProduct = _mapper.Map<Product>(request);

            var product = await _productRepository.UpdateAsync(updatedProduct);
            _mapper.Map(product, request, typeof(Product), typeof(UpdateProductCommand));
            return request;
        }
    }
    public class UpdateProductsCommand:IRequest<IEnumerable<UpdateProductCommand>>
    {
        public IEnumerable<UpdateProductCommand> UpdateCommands { get; set; }
    }
    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, IEnumerable<UpdateProductCommand>>
    {
        private readonly IMediator _mediator;

        public UpdateProductsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async  Task<IEnumerable<UpdateProductCommand>> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            List<UpdateProductCommand> commands = new List<UpdateProductCommand>();
            foreach (var command in request.UpdateCommands)
            {
                var updatedProduct = await _mediator.Send(command);
                commands.Add(updatedProduct);

            }
            return commands;
        }
    }
    public class DeleteProductCommand : ProductDTO, IRequest
    {

    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly DeleteProductCommandValidation _validator;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository, DeleteProductCommandValidation validator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _validator = validator;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            request = await request.AsValid(_validator);
            var deletedProduct = _productRepository.GetAll().FirstOrDefault(e => e.ItemId == request.ProductId);
            await _productRepository.DeleteAsync(deletedProduct);
            return Unit.Value;
        }
    }

    public class DeleteProductsCommand:IRequest
    {
        public IEnumerable<DeleteProductCommand> DeleteProductCommands { get; set; }
    }
    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand>
    {
        private readonly IMediator _mediator;

        public DeleteProductsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ValidationException("request cannot be null"); }
            foreach (var deleteCommand in request.DeleteProductCommands)
            {
                await _mediator.Send(deleteCommand);
            }
            return Unit.Value;
        }
    }




}
