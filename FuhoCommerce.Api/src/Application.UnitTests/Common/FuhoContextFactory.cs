using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.CrossCuttingConcern;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace Application.UnitTests.Common
{
    public class FuhoContextFactory
    {
        public static FuhoDbContext Create()
        {
            var _dateTimeProvider = new Mock<IDateTimeProvider>();
            var _currentUserService = new Mock<ICurrentUserService>();

            _dateTimeProvider.Setup(x => x.Now).Returns(DateTime.Now);
            _currentUserService.Setup(x => x.UserId).Returns("a56b856f-e009-4cfa-9f87-58f04f573617");

            var options = new DbContextOptionsBuilder<FuhoDbContext>()
                .UseInMemoryDatabase("FuhoInMemoryDataBase")
                .Options;

            var context = new FuhoDbContext(options, _dateTimeProvider.Object, _currentUserService.Object);

            context.Database.EnsureCreated();

            return context;
        }

        public static void Destroy(FuhoDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}

