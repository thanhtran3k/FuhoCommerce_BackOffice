using Microsoft.EntityFrameworkCore;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public class FuhoDbContextFactory : DesignTimeDbContextFactoryBase<FuhoDbContext>
    {
        protected override FuhoDbContext CreateNewInstance(DbContextOptions<FuhoDbContext> options)
        {
            //you can resolve easily your DbContext dependencies in a safe way injecting a factory instead of an instance itself, 
            //enabling you to work in multi-thread contexts with Entity Framework Core or just work safest with DbContext following the Microsoft recommendations about the DbContext lifetime.
            return new FuhoDbContext(options);
        }
    }
}
