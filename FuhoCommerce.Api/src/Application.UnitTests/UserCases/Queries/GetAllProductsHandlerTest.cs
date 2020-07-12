using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.ProductsUseCases.Query.GetAllProductss;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Queries
{
    [Collection("QueryCollection")]
    public class GetAllProductsHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public GetAllProductsHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task GetAllProducts_Success_ReturnProductListVm()
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
                    Images = "no-images"
                }
            };

            await _fuhoDbContext.Products.AddRangeAsync(products);
            await _fuhoDbContext.SaveChangesAsync();

            var getAllProductsQuery = new GetAllProductsQuery() { Page = 1, PageSize = 10 };

            //Act
            var sut = new GetAllProductsHandler(_fuhoDbContext);
            var result = await sut.Handle(getAllProductsQuery, CancellationToken.None);

            //Assert

            Assert.Equal(1, result.ProductDtos.Count);
            Assert.NotNull(sut);
            Assert.IsType<ProductListVm>(result);
        }
    }
}
