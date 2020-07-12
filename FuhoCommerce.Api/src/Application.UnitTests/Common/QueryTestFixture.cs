using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FuhoDbContext FuhoDbContext { get; set; }
        public Mock<IFileSystemService> FileSystemService { get; set; }
        public Mock<IMapper> Mapper { get; set; }

        public QueryTestFixture()
        {
            FuhoDbContext = FuhoContextFactory.Create();
            FileSystemService = new Mock<IFileSystemService>();
            Mapper = new Mock<IMapper>();
        }
        public void Dispose()
        {
            FuhoContextFactory.Destroy(FuhoDbContext);
        }

        public Mock<ILogger<T>> CreateLoggerMock<T>() where T : class
        {
            return new Mock<ILogger<T>>();
        }

        public Mock<T> CreateServiceMock<T>() where T : class
        {
            return new Mock<T>();
        }
    }

    [CollectionDefinition("QueryCollection", DisableParallelization = true)]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
