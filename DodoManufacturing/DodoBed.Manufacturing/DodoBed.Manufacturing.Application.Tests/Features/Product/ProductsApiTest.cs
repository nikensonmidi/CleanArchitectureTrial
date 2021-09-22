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
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly CreateProductCommandValidation _createValidator;

        public ProductQueriesTest()
        {
            _mediator = new Mock<IMediator>();
            var mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapconfig);


            _productRepository = new Mock<IProductRepository>();
            _createValidator = new CreateProductCommandValidation(_productRepository.Object);

        }
        [Fact]
        public async Task Should_Get_Empty_List_Of_Products()
        {
            //Arrange

            var query = new ProductListQuery();
            var handler = new ProductListQueryHandler(_mapper, _productRepository.Object);

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
            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper, _createValidator);
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
            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper, _createValidator);


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

            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper, _createValidator);


            //Act
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Not_Add_Product_with_Existing_NameOrDescription_Regardless_Space()
        {
            //Arrange
            var command = new CreateProductCommand
            {
                Name = " product1",
                Description = "Product1 description"
            };
            var products = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product{Name ="product1      ", Description="Product7 description", ItemId=1},
                new Domain.Entities.Product{Name ="product2", Description="product1 descriptiOn", ItemId=2},

            };
            _productRepository.Setup(m => m.GetAll()).Returns(products);

            var handler = new CreateProductCommandHandler(_productRepository.Object, _mapper, _createValidator);


            //Act
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Return_Ok_When_Updating_Product()
        {
            //Arrange


            _mediator.Setup(m => m.Send(It.IsAny<ProductListQuery>(), new CancellationToken()));
            var command = new UpdateProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 1
            };
            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Put(command.ProductId, command);
            //Assert
            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task Should_Return_Badrequest_When_Updating_NullProduct()
        {
            //Arrange
            var product = new Domain.Entities.Product { Name = "product1", Description = "Product1 description", ItemId = 0 };

            _productRepository.Setup(m => m.UpdateAsync(It.IsAny<Domain.Entities.Product>())).ReturnsAsync(product);

            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, _mapper, updateValidator);
            //Act

            await Assert.ThrowsAnyAsync<ValidationException>(async () => await handler.Handle(null, new CancellationToken()));

        }
        [Fact]
        public async Task Should_Return_Badrequest_When_Updating_Product_Id_Zero()
        {
            //Arrange



            var command = new UpdateProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 0
            };
            var product = new Domain.Entities.Product { Name = "product1", Description = "Product1 description", ItemId = 0 };

            _productRepository.Setup(m => m.UpdateAsync(It.IsAny<Domain.Entities.Product>())).ReturnsAsync(product);

            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, _mapper, updateValidator);
            //Act

            await Assert.ThrowsAnyAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));

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

            _productRepository.Setup(m => m.UpdateAsync(It.IsAny<Domain.Entities.Product>())).ReturnsAsync(product);

            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, _mapper, updateValidator);

            Assert.False(command.Description.Equals(product.Description, System.StringComparison.OrdinalIgnoreCase));
            var response = await handler.Handle(command, new CancellationToken());
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

            var updateValidator = new UpdateProductCommandValidation(_productRepository.Object);
            var handler = new UpdateProductCommandHandler(_productRepository.Object, _mapper, updateValidator);

            //Act
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));
        }
        [Fact]
        public async Task Should_Delete_Product()
        {
            //Arrange
            var command = new DeleteProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 1
            };
            var query = new ProductListQuery();


            var products = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product{Name ="product1", Description="Product1 description", ItemId=1},
                new Domain.Entities.Product{Name ="product2", Description="Product2 description", ItemId=2}

            };
            var addedProduct = products.First();
            

            _productRepository.Setup(m => m.GetAll()).Returns(products);

            _productRepository.Setup(m => m.DeleteAsync(It.Is<Domain.Entities.Product>(p => p.ItemId > 0)))
                .Callback<Domain.Entities.Product>((p) => products.Remove(p));

            var deleteValidator = new DeleteProductCommandValidation(_productRepository.Object);
            var handler = new DeleteProductCommandHandler(_mapper, _productRepository.Object, deleteValidator);

            var queryHandler = new ProductListQueryHandler(_mapper, _productRepository.Object);

            //Act
            await handler.Handle(command, new CancellationToken());
            _productRepository.Verify(e => e.DeleteAsync(It.IsAny<Domain.Entities.Product>()), Times.Once);

            var newList = await queryHandler.Handle(query, new CancellationToken());
            //Assert
            Assert.DoesNotContain(newList, e => e.ProductId == addedProduct.ItemId);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_Deleting_Non_Existing_Product()
        {
            //Arrange
            var command = new DeleteProductCommand
            {
                Name = "product1",
                Description = "Product1 description",
                ProductId = 1
            };
            var query = new ProductListQuery();


            var products = new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product{Name ="product3", Description="Product3 description", ItemId=3},
                new Domain.Entities.Product{Name ="product2", Description="Product2 description", ItemId=2}

            };
            var addedProduct = products.First();

            _productRepository.Setup(m => m.GetAll()).Returns(products);

            _productRepository.Setup(m => m.DeleteAsync(It.Is<Domain.Entities.Product>(p => p.ItemId > 0)))
                .Callback<Domain.Entities.Product>((p) => products.Remove(p));

            var deleteValidator = new DeleteProductCommandValidation(_productRepository.Object);
            var handler = new DeleteProductCommandHandler(_mapper, _productRepository.Object, deleteValidator);



            //Assert
            await Assert.ThrowsAnyAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));
        }


        [Fact]
        public async Task Should_Return_OK_For_Adding_Multiple_Products( )
        {
            //Arrange

            ICollection<CreateProductCommand> commands = new List<CreateProductCommand>
            {
              new CreateProductCommand{ Name = "Product1", Description="Product 1 description"},
              new CreateProductCommand{ Name = "Product2", Description="Product 2 description"},
            };
            var createCommand = new CreateProductsCommand
            {
                ProductCommands = commands
            };
           
            _mediator.Setup(m => m.Send(It.IsAny<CreateProductsCommand>(), new CancellationToken())).ReturnsAsync(new List<long> {1,2 });

            var controller = new ProductController(_mediator.Object);
            //Act
            var response = await controller.Post(createCommand);
            //Assert
            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task Should_Add_Multiple_Products()
        {
            //Arrange
            var command = new CreateProductsCommand
            {
                ProductCommands = new List<CreateProductCommand>
                {
                    new CreateProductCommand{Name = "product3", Description = "Product3 description" },
                    new CreateProductCommand{Name = "product4", Description = "Product4 description" }
                }
            };
           
            _mediator.SetupSequence(e => e.Send(It.IsAny<CreateProductCommand>(), new CancellationToken())).ReturnsAsync(1).ReturnsAsync(2);
            var handler = new CreateProductsCommandHandler(_mediator.Object);

            var repsonse = await handler.Handle(command, new CancellationToken());
            Assert.Collection(repsonse, p => Assert.Equal(1, p),
                                          p => Assert.Equal(2, p));

        }
        [Fact]
        public async Task Should_Throw_ValidationException_When_Adding_Multiple_Products()
        {
            //Arrange
            var command = new CreateProductsCommand
            {
                ProductCommands = new List<CreateProductCommand>
                {
                    new CreateProductCommand{Name = "", Description = "Product3 description" },
                    new CreateProductCommand{Name = "product4", Description = "Product4 description" }
                }
            };

            _mediator.SetupSequence(e => e.Send(It.IsAny<CreateProductCommand>(), new CancellationToken())).ThrowsAsync(new ValidationException("Name cannot be emptied")).ReturnsAsync(2);
            var handler = new CreateProductsCommandHandler(_mediator.Object);

            //Assert 
            await Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, new CancellationToken()));
           
        }

        [Fact]
        public async Task Should_Update_Multiple_Products()
        {
            //Arrange
            var first = new UpdateProductCommand { Name = "product3", Description = "Product3 description", ProductId = 1 };
            var second = new UpdateProductCommand { Name = "product4", Description = "Product4 description", ProductId = 2 };

            var command = new UpdateProductsCommand
            {
                UpdateCommands = new List<UpdateProductCommand>
                {
                    first,
                     second
                }
            };
            var updatedProduct1 = new UpdateProductCommand { Name = "productchanged", Description = "Product3 description", ProductId = 1 };
            var updatedProduct2 = new UpdateProductCommand { Name = "product4", Description = "Product4 description changed", ProductId = 2 };

            _mediator.SetupSequence(e => e.Send(It.IsAny<UpdateProductCommand>(), new CancellationToken())).ReturnsAsync(updatedProduct1).ReturnsAsync(updatedProduct2);
            var handler = new UpdateProductsCommandHandler(_mediator.Object);

            var repsonse = await handler.Handle(command, new CancellationToken());
            Assert.Collection(repsonse, p => Assert.NotEqual(first.Name, p.Name) ,
                                          p => Assert.NotEqual(second.Description, p.Description));
            Assert.Collection(repsonse, p => Assert.Equal(first.ProductId, p.ProductId),
                                       p => Assert.Equal(second.ProductId, p.ProductId));

        }

       


    }
}
