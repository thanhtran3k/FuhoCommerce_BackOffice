using Application.UnitTests.Common;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class CreateProductHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<IFileSystemService> _fileSystemService;

        public CreateProductHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _fileSystemService = fixture.FileSystemService;
        }

        [Fact]
        public async Task CreateProduct_Success_ReturnUnit()
        {
            // Arrange
            // mock signle upload file
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

            var mockImage = _fileSystemService.Setup(x => x.SingleUpload(fileMock.Object)).ReturnsAsync("test");


            var createProductCommand = new CreateProductCommand()
            {
                BrandName = "Pineapple",
                ProductName = "PinePhone X",
                CategoryId = Constants.CategoryId,
                Price = 1200,
                Stock = 12,
                Sku = "12312",
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        OptionKey = "Color",
                        OptionValues = "Black, Product Red, White"
                    }
                },
                File = fileMock.Object
            };

            // Act
            var sut = new CreateProductHandler(_fuhoDbContext, _fileSystemService.Object);
            var result = await sut.Handle(createProductCommand, CancellationToken.None);

            // Result
            Assert.IsType<Unit>(result);
        }
    }
}
