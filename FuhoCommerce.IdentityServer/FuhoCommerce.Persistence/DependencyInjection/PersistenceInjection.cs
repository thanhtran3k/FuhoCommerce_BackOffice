using FuhoCommerce.Persistence.Constants;
using FuhoCommerce.Persistence.CustomIdentityUser;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FuhoCommerce.Persistence.DependencyInjection
{
    public static class PersistenceInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<FuhoIdentityDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString(DbConfiguration.ConnectionStringName)));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<FuhoIdentityDbContext>()
                .AddDefaultTokenProviders();

            var identityServiceBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            });

            identityServiceBuilder.AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(configuration.GetConnectionString(DbConfiguration.ConnectionStringName));
                // Clean unuse token from Db
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30; // interval in seconds
            });

            identityServiceBuilder.AddInMemoryPersistedGrants();
            identityServiceBuilder.AddInMemoryIdentityResources(IdentityConfigurations.GetIdentityResources());
            identityServiceBuilder.AddInMemoryApiResources(IdentityConfigurations.GetApiResources());
            identityServiceBuilder.AddInMemoryClients(IdentityConfigurations.GetClients());
            identityServiceBuilder.AddAspNetIdentity<AppUser>();

            if (environment.IsDevelopment())
            {
                identityServiceBuilder.AddDeveloperSigningCredential();
            }
            else
            {
                //path: Root/certificates/.pfx
                var certificatePath = Path.GetFullPath(Path.Combine(environment.ContentRootPath, configuration["Certificate:CertFolder"], configuration["Certificate:FileName"]));
                services.AddIdentityServer()
                    .AddSigningCredential(new X509Certificate2(certificatePath), configuration["Certificate:Password"]);
            }

            return services;
        }
    }
}
