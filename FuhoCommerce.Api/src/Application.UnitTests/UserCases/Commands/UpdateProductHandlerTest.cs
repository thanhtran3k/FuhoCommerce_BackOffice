using Application.UnitTests.Common;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Commands
{
    [Collection("QueryCollection")]
    public class UpdateProductHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<IFileSystemService> _fileSystemService;
        private readonly Mock<ILogger<UpdateProductHandler>> _logger;

        public UpdateProductHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _fileSystemService = fixture.FileSystemService;
            _logger = fixture.CreateLoggerMock<UpdateProductHandler>();
        }

        [Fact]
        public async Task UpdateProduct_Success_ReturnUnit()
        {
            // Arrange
            // Mock data for product
            var category = new Category()
            {
                CategoryId = Constants.CategoryId,
                Name = "Phone",
                Thumbnail = "no-image.jpg"
            };

            var products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Constants.ProductId,
                    BrandName = "Pineapple",
                    ProductName = "PinePhone X",
                    CategoryId = category.CategoryId,
                    Price = 1200,
                    Stock = 12,
                    Sku = "12312",
                    Category = category,
                    ProductOptions = new List<ProductOption>()
                    {
                        new ProductOption()
                        {
                            ProductOptionId = Guid.NewGuid(),
                            OptionKey = "Color",
                            OptionValues = "Black, Product Red, White"
                        }
                    },
                    Images = "no-images",
                    CreateDate = DateTime.Now,
                    CreatedBy = Constants.UserId.ToString()
                }
            };

            _fuhoDbContext.Products.AddRange(products);
            _fuhoDbContext.SaveChanges();

            // Mock signle upload file
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.png";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var mockImage = _fileSystemService.Setup(x => x.SingleUpdate(fileMock.Object, fileName)).ReturnsAsync(fileName);


            var updateProductCommand = new UpdateProductCommand()
            {
                BrandName = "Test",
                ProductName = "Test",
                CategoryId = Constants.CategoryId,
                ProductId = Constants.ProductId,
                Price = 1000,
                Stock = 10,
                Sku = "123123",
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        OptionKey = "Color",
                        OptionValues = "Black, Product Red, White"
                    }
                },
                File = fileMock.Object,
                UserId = Constants.UserId.ToString()
            };

            // Act
            var sut = new UpdateProductHandler(_fuhoDbContext, _fileSystemService.Object, _logger.Object);
            var result = await sut.Handle(updateProductCommand, CancellationToken.None);

            // Result
            Assert.IsType<Unit>(result);
        }
    }
}
