using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
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
    public class GetAllCategoriesHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public GetAllCategoriesHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task GetAllCategories_Success_ReturnCategoryListVm()
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

            var getAllCategoriesQuery = new GetAllCategoriesQuery();

            //Act
            var sut = new GetAllCategoriesHandler(_fuhoDbContext);
            var result = await sut.Handle(getAllCategoriesQuery, CancellationToken.None);

            //Assert

            Assert.Equal(1, result.CategoryDtos.Count);
            Assert.NotNull(sut);
            Assert.IsType<CategoryListVm>(result);
        }
    }
}
