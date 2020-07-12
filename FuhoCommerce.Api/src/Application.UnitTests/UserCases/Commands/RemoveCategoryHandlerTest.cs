using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.RemoveCategory;
using FuhoCommerce.Domain.Entities;
using FuhoCommerce.Persistence.EFDbContext;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Commands
{
    [Collection("QueryCollection")]
    public class RemoveCategoryHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public RemoveCategoryHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task RemoveCategory_Success_ReturnUnit()
        {
            //Arrange
            var category = new Category()
            {
                CategoryId = Constants.CategoryId,
                Name = "Phone",
                Thumbnail = "no-image.jpg"
            };

            _fuhoDbContext.Categories.AddRange(category);
            _fuhoDbContext.SaveChanges();

            var removeCategoryCommand = new RemoveCategoryCommand()
            {
               CategoryId = Constants.CategoryId
            };

            //Act
            var sut = new RemoveCategoryHandler(_fuhoDbContext);
            var result = await sut.Handle(removeCategoryCommand, CancellationToken.None);

            //Assert
            Assert.IsType<Unit>(result);
        }

    }
}
