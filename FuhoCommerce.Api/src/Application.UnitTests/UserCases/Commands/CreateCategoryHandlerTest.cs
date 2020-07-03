using Application.UnitTests.Common;
using AutoMapper;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory;
using FuhoCommerce.Persistence.EFDbContext;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.UserCases.Commands
{
    [Collection("QueryCollection")]
    public class CreateCategoryHandlerTest
    {
        private readonly FuhoDbContext _fuhoDbContext;
        private readonly Mock<IMapper> _mapper;

        public CreateCategoryHandlerTest(QueryTestFixture fixture)
        {
            _fuhoDbContext = fixture.FuhoDbContext;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task CreateCategory_Success_ReturnUnit()
        {
            // Arrange
            var createCategoryCommand = new CreateCategoryCommand()
            {
                Name = "Phone",
                Thumbnail = "no-image.jpg"
            };

            // Act
            var sut = new CreateCategoryHandler(_fuhoDbContext, _mapper.Object);
            var result = await sut.Handle(createCategoryCommand, CancellationToken.None);

            // Result
            Assert.IsType<CreateCategoryResponse>(result);
        }
    }
}
