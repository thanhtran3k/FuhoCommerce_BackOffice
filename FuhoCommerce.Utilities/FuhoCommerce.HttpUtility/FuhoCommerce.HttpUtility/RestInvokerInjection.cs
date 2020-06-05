using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace FuhoCommerce.HttpUtility
{
    public static class RestInvokerInjection
    {
        public static IServiceCollection AddRestInvoker(this IServiceCollection services, IConfiguration configuration)
        {
            bool ignoreSelfSignedCertificateCheck = configuration.GetValue("ignoreSelfSignedCertificateCheck", false);

            if (ignoreSelfSignedCertificateCheck)
            {
                var createHttpClient = SelfSignedCertificateHandler.CreateHttpClient();
                services.AddScoped((provider) => new RestInvoker(createHttpClient, new LoggerFactory().CreateLogger<RestInvoker>()));
            }
            else
            {
                services.AddScoped<RestInvoker>();
            }

            services.AddSingleton(provider => new HttpClient());

            return services;
        }
    }
}
