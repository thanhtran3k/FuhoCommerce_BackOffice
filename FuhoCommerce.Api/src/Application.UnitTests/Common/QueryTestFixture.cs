using FuhoCommerce.Persistence.EFDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FuhoDbContext FuhoDbContext { get; set; }
        public QueryTestFixture()
        {
            FuhoDbContext = FuhoContextFactory.Create();
        }
        public void Dispose()
        {
            FuhoContextFactory.Destroy(FuhoDbContext);
        }
    }

    [CollectionDefinition("QueryCollection", DisableParallelization = true)]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
