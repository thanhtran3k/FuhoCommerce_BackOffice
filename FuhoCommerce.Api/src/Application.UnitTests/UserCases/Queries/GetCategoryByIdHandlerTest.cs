using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetCategoryById;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Queries
{
    [Collection("QueryCollection")]
    public class GetCategoryByIdHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<ILogger<GetCategoryByIdHandler>> _logger;

        public GetCategoryByIdHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _logger = fixture.CreateLoggerMock<GetCategoryByIdHandler>();
        }

        [Fact]
        public async Task GetCategoryById_Success_ReturnCategoryDto()
        {
            //Arrange
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
                    Images = "no-images"
                }
            };

            await _fuhoDbContext.Categories.AddRangeAsync(category);
            await _fuhoDbContext.Products.AddRangeAsync(products);
            await _fuhoDbContext.SaveChangesAsync();

            var getCategoryByIdQuery = new GetCategoryByIdQuery() { CategoryId = Constants.CategoryId };

            //Act
            var sut = new GetCategoryByIdHandler(_fuhoDbContext, _logger.Object);
            var result = await sut.Handle(getCategoryByIdQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(sut);
            Assert.IsType<CategoryDto>(result);
        }
    }
}
