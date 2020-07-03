using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Queries
{
    [Collection("QueryCollection")]
    public class GetAllProductsSCHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public GetAllProductsSCHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task GetAllProductsSC_Success_ReturnProductListVm()
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

            var getAllProductsSCQuery = new GetAllProductsSCQuery() 
            { 
                Page = 1, 
                PageSize = 10,
                UserId = Constants.UserId.ToString()
            };

            //Act
            var sut = new GetAllProductsSCHandler(_fuhoDbContext);
            var result = await sut.Handle(getAllProductsSCQuery, CancellationToken.None);

            //Assert

            Assert.NotNull(sut);
            Assert.IsType<ProductsSCVm>(result);
        }
    }
}
