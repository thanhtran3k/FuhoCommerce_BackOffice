using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetCategoryById;
using FuhoCommerce.Application.UseCases.CommentsUseCases.Query.GetCommentByProductId;
using FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId;
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
    public class GetCommentByProductIdHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<ILogger<GetCategoryByIdHandler>> _logger;

        public GetCommentByProductIdHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _logger = fixture.CreateLoggerMock<GetCategoryByIdHandler>();
        }

        [Fact]
        public async Task GetCommentByProductId_Success_ReturnCategoryDto()
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
                    Images = "no-images",
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Content = "good",
                            Rating = 5,
                            IsEdit = false
                        }
                    }
                }
            };

            await _fuhoDbContext.Products.AddRangeAsync(products);
            await _fuhoDbContext.SaveChangesAsync();

            var getCommentByProductIdQuery = new GetCommentByProductIdQuery() 
            { 
                Page = 1,
                PageSize = 10,
                ProductId = Constants.ProductId 
            };

            //Act
            var sut = new GetCommentByProductIdHandler(_fuhoDbContext);
            var result = await sut.Handle(getCommentByProductIdQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(sut);
            Assert.IsType<CommentListVm>(result);
        }
    }
}
