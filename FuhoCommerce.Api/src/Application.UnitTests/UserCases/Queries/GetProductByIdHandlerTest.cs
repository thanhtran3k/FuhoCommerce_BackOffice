using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Queries
{
    [Collection("QueryCollection")]
    public class GetProductByIdHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<ILogger<GetProductByIdHandler>> _logger;

        public GetProductByIdHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _logger = fixture.CreateLoggerMock<GetProductByIdHandler>();
        }

        [Fact]
        public async Task GetProductById_Success_ReturnProductDetail()
        {
            //Arrange
            var category = new Category()
            {
                CategoryId = Constants.CategoryId,
                Name = "Phone",
                Thumbnail = "no-image.jpg"
            };

            var productOption = new List<ProductOption>()
            {
                new ProductOption()
                {
                    ProductOptionId = Guid.NewGuid(),
                    OptionKey = "Color",
                    OptionValues = "Black, Product Red, White"
                },
                new ProductOption()
                {
                    ProductOptionId = Guid.NewGuid(),
                    OptionKey = "Capacity",
                    OptionValues = "64GB, 128GB"
                }
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
                    ProductOptions = productOption,
                    Images = "no-images",
                    CreateDate = DateTime.Now,
                    CreatedBy = Constants.UserId.ToString()
                }
            };

            await _fuhoDbContext.Products.AddRangeAsync(products);
            await _fuhoDbContext.SaveChangesAsync();

            var getProductbyIdQuery = new GetProductByIdQuery() { ProductId = Constants.ProductId};

            //Act
            var sut = new GetProductByIdHandler(_fuhoDbContext, _logger.Object);
            var result = await sut.Handle(getProductbyIdQuery, CancellationToken.None);

            //Assert

            Assert.NotNull(sut);
            Assert.IsType<ProductDetailVm>(result);
        }
    }
}
