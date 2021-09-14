using AutoMapper;
using DodoBed.Manufacturing.Application.Features.Products;
using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DodoBed.Manufacturing.Application.Tests.Features.Product
{
    public class ProductQueriesTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly CreateProductCommandValidation _createValidator;

        public ProductQueriesTest()
        {
            _mediator = new Mock<IMediator>();

            _mapper = new Mock<IMapper>();


            _productRepository = new Mock<IProductRepository>();
            _createValidator = new CreateProductCommandValidation(_productRepository.Object);

        }
        [Fact]
        public async Task Should_Get_Empty_List_Of_Products()
        {
            //Arrange

            var query = new ProductListQuery();
            var handler = new ProductListQueryHandler(_mapper.Object, _productRepository.Object);

            //Act
            var response = await handler.Handle(query, new System.Threading.CancellationToken());
            //Assert
            Assert.Empty(response.ToList());

        }
        [Fact]
        public async Task Should_Return_OK_for_Get()
        {
            //Arrange

            var products = new List<ProductDTO>
            {
               new ProductDTO{ Description ="Product decription", Name ="produc"}
            };

            _mediator.Setup(m => m.Send(It.IsAny<ProductListQuery>(), new CancellationToken())).ReturnsAsync(products);

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task Should_Not_Return_NotFound_On_Get()
        {
            //Arrange

            var products = new List<ProductDTO>
            {
               new ProductDTO{ Description ="Product decription", Name ="produc"}
            };

            _mediator.Setup(m => m.Send(It.IsAny<ProductListQuery>(), new CancellationToken())).ReturnsAsync(products);

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Get();
            //Assert
            Assert.IsNotType<NotFoundObjectResult>(response);

        }
        [Fact]
        public async Task Should_Not_Return_BadRequest_On_Get()
        {
            //Arrange

            var products = new List<ProductDTO>
            {
               new ProductDTO{ Description ="Product decription", Name ="produc"}
            };

            _mediator.Setup(m => m.Send(It.IsAny<ProductListQuery>(), new CancellationToken())).ReturnsAsync(products);

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Get();
            //Assert
            Assert.IsNotType<BadRequestObjectResult>(response);

        }
        [Fact]
        public async Task Should_Return_Ok_With_EmptyList_On_Get()
        {
            //Arrange


            _mediator.Setup(m => m.Send(It.IsAny<ProductListQuery>(), new CancellationToken()));

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task Should_Add_Product_On_Post()
        {
            //Arrange

            _mediator.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), new CancellationToken())).ReturnsAsync(1);

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Post(new CreateProductCommand { Name = "product", Description = "Product description" });
            //Assert
            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task Should_Not_Add_Product_without_Name()
        {
            //Arrange
            var command = new CreateProductCommand
            {
                Description = "product description only"
            };
            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper.Object, _createValidator);
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Not_Add_Product_without_Description()
        {
            //Arrange
            var command = new CreateProductCommand
            {
                Name = "product_name_only"
            };
            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper.Object, _createValidator);


            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Not_Add_Product_with_Existing_NameOrDescription()
        {
            //Arrange
            var command = new CreateProductCommand
            {
                Name = "product1",
                Description = "Product1 description"
            };
            var products = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product{Name ="product1", Description="Product7 description", ItemId=1},
                new Domain.Entities.Product{Name ="product2", Description="product1 descriptiOn", ItemId=2}

            };
            _productRepository.Setup(m => m.GetAll()).Returns(products);
            var mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = new Mapper(mapconfig);
            var handler = new CreateProductCommandHandler(_productRepository.Object, mapper, _createValidator);


            //Act
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Update_Product()
        {
            //Arrange
            var command = new UpdateProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 1
            };
          
            var product = new Domain.Entities.Product { Name = "product1", Description = "Product7 description", ItemId = 1 };

             _productRepository.Setup(m => m.UpdateAsync(It.IsAny<Domain.Entities.Product>()) ).ReturnsAsync(product);
            var mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = new Mapper(mapconfig);
            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, mapper, updateValidator);

            Assert.False(command.Description.Equals(product.Description, System.StringComparison.OrdinalIgnoreCase));
            var respone = await handler.Handle(command, new CancellationToken());
            //Act
            Assert.True(command.Description.Equals(product.Description, System.StringComparison.OrdinalIgnoreCase));
            Assert.True(command.ProductId == product.ItemId);

        }
        [Fact]
        public async Task Should_Not_Update_Product_with_Existing_NameOrDescription()
        {
            //Arrange
            var command = new UpdateProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 1
            };
            var products = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product{Name ="product1", Description="Product7 description", ItemId=1},
                new Domain.Entities.Product{Name ="product2", Description="Product1 description", ItemId=2}
               
            };
            _productRepository.Setup(m => m.GetAll()).Returns(products);
            var mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = new Mapper(mapconfig);
            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, mapper, updateValidator);

            //Act
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));



        }



    }
}
