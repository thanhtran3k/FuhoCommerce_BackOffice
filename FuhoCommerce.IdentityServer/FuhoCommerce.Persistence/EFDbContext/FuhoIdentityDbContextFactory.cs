using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public class FuhoIdentityDbContextFactory : DesignTimeDbContextFactoryBase<FuhoIdentityDbContext>
    {
        protected override FuhoIdentityDbContext CreateNewInstance(DbContextOptions<FuhoIdentityDbContext> options)
        {
            return new FuhoIdentityDbContext(options);
        }
    }
}
