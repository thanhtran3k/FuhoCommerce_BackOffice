using FuhoCommerce.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        //THE TOOLS WILL LOOK FOR IDESIGNTIMEDBCONTEXTFACTORY<> IMPLEMENTATION IN EXECUTING PROJECT
        //You will tell the tool how to create DbContext by implementing IDesignTimeDbContextFactory<>. If you go with this way, It will ignore other ways of creating CbContext.
        //IT WILL EXECUTE CREATEDBCONTEXT() IN YOUR FACTORY TO CREATE DBCONTEXT
        //IT WILL CREATE MIGRATION SCRIPTS IN THE MIGRATIONS FOLDER IN THE PROJECT THAT HOLDS YOUR EXECUTION CONTEXT
        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}FuhoCommerce.ApplicationApi", Path.DirectorySeparatorChar);
            return CreateConfigurations(basePath, Environment.GetEnvironmentVariable(DbContextConfiguration.AspNetCoreEnvironment));
        }

        private TContext CreateConfigurations(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(DbContextConfiguration.ConnectionStringName);

            return CreateInstanceFromConfig(connectionString);
        }

        private TContext CreateInstanceFromConfig(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{DbContextConfiguration.ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString, provider => provider.CommandTimeout(60));

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
