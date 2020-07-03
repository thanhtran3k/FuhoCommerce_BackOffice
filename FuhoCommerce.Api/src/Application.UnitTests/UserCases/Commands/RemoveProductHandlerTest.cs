using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Commands
{
    [Collection("QueryCollection")]
    public class RemoveProductHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public RemoveProductHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task RemoveProduct_Success_ReturnUnit()
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

            _fuhoDbContext.Products.AddRange(products);
            _fuhoDbContext.SaveChanges();

            var removeProductCommand = new RemoveProductCommand()
            {
                ProductId = Constants.ProductId,
                UserId = Constants.UserId.ToString()
            };

            //Act
            var sut = new RemoveProductHandler(_fuhoDbContext);
            var result = await sut.Handle(removeProductCommand, CancellationToken.None);

            //Assert
            Assert.IsType<Unit>(result);
        }

    }
}
