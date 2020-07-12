using Application.UnitTests.Common;
using FuhoCommerce.Application.UseCases.CommentUseCases.Command.CreateComment;
using FuhoCommerce.Persistence.EFDbContext;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Commands
{
    [Collection("QueryCollection")]
    public class CreateCommentHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;

        public CreateCommentHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
        }

        [Fact]
        public async Task CreateComment_Success_ReturnUnit()
        {
            // Arrange
            var createProductCommand = new CreateCommentCommand()
            {
                ProductId = Constants.ProductId,
                Content = "Test Comment",
                Rating = 5
            };

            // Act
            var sut = new CreateCommentHandler(_fuhoDbContext);
            var result = await sut.Handle(createProductCommand, CancellationToken.None);

            // Result
            Assert.IsType<Unit>(result);
        }
    }
}
