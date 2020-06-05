using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.CrossCuttingConcern;
using FuhoCommerce.Infrastructure.ExternalResource.Clock;
using FuhoCommerce.Infrastructure.ExternalResource.FileSystem;
using FuhoCommerce.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FuhoCommerce.Infrastructure.DependencyInjection
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IFileSystemService, FileSystemService>();

            return services;
        }
    }
}
