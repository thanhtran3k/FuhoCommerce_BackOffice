using FuhoCommerce.Persistence.EFDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly FuhoDbContext _fuhoDbContext;

        public CommandTestBase()
        {
            _fuhoDbContext = FuhoContextFactory.Create();
        }

        public void Dispose()
        {
            FuhoContextFactory.Destroy(_fuhoDbContext);
        }
    }

    [CollectionDefinition("CommandCollection", DisableParallelization = true)]
    public class CommandCollection { }
}
