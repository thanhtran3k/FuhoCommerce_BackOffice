using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Persistence.Constants;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.DependencyInjection
{
    public static class PersistenceInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContextOptions<FuhoDbContext> options, now you know where options come from :v
            services.AddDbContext<FuhoDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString(DbContextConfiguration.ConnectionStringName)));

            //Use factory method pattern
            //This way you will resolve a new instance of FuhoDbContext (on first call) or return the already instantiated instance of it during a request on conclusive calls.
            //services.AddScoped(typeof(IDbContext), typeof(MyContext)); Error
            services.AddScoped<IFuhoDbContext>(provider => provider.GetService<FuhoDbContext>());

            return services;
        }
    }
}
