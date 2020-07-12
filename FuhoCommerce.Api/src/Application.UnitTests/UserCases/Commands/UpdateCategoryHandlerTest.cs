using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.UpdateCategory;
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
    public class UpdateCategoryHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<ILogger<UpdateCategoryHandler>> _logger;

        public UpdateCategoryHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _logger = fixture.CreateLoggerMock<UpdateCategoryHandler>();
        }

        [Fact]
        public async Task UpdateCategory_Success_ReturnUnit()
        {
            // Arrange
            // Mock data for product
            var category = new Category()
            {
                CategoryId = Constants.CategoryId,
                Name = "Phone",
                Thumbnail = "no-image.jpg"
            };

            _fuhoDbContext.Categories.AddRange(category);
            _fuhoDbContext.SaveChanges();

            var updateCategoryCommand = new UpdateCategoryCommand()
            {
                CategoryId = Constants.CategoryId,
                Name = "Phone XXX",
                Thumbnail = "image.jpg"
            };

            // Act
            var sut = new UpdateCategoryHandler(_fuhoDbContext,  _logger.Object);
            var result = await sut.Handle(updateCategoryCommand, CancellationToken.None);

            // Result
            Assert.IsType<Unit>(result);
        }
    }
}
