using FuhoCommerce.Persistence.Constants;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}FuhoCommerce.IdentityServer", Path.DirectorySeparatorChar);
            return CreateConfigurations(basePath, Environment.GetEnvironmentVariable(DbConfiguration.AspNetCoreEnvironment));
        }

        private TContext CreateConfigurations(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(DbConfiguration.ConnectionStringName);

            return CreateInstanceFromConfig(connectionString);
        }

        private TContext CreateInstanceFromConfig(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{DbConfiguration.ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            var isPersistedDbContext = typeof(TContext).Name.Equals(typeof(PersistedGrantDbContext).Name);            
            if (isPersistedDbContext)
            {
                var migrationsAssembly = typeof(PersistedGrantDbContextFactory).GetTypeInfo().Assembly.GetName().Name;

                optionsBuilder.UseSqlServer(connectionString, 
                    provider => provider.MigrationsAssembly(migrationsAssembly));
            } else
            {
                optionsBuilder.UseSqlServer(connectionString, provider => provider.CommandTimeout(60));
            }

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
