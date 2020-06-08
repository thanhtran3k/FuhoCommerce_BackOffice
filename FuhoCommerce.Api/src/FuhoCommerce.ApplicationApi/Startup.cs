using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.DependencyInjection;
using FuhoCommerce.ApplicationApi.Services;
using FuhoCommerce.HttpUtility;
using FuhoCommerce.Infrastructure.DependencyInjection;
using FuhoCommerce.Persistence.DependencyInjection;
using FuhoCommerce.Persistence.EFDbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace FuhoCommerce.ApplicationApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private IServiceCollection _services;

        //In case needed
        //public IWebHostEnvironment Environment { get; }


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //My DI collections
            #region Dependency Injection Collections

            services.AddInfrastructure();
            services.AddPersistence(_configuration);
            services.AddApplication();

            #endregion
            //End DI Collections

            #region Register RestInvoker

            services.AddRestInvoker(_configuration);

            #endregion

            services.AddHealthChecks().AddDbContextCheck<FuhoDbContext>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddControllers();

            #region Authentication & Authorization

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;                
            }).AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:5000";
                o.Audience = "fuhocommerceapi";
                o.RequireHttpsMetadata = false;
                o.MetadataAddress = "https://localhost:5000/.well-known/openid-configuration";
            });

            services.AddAuthorization(options =>
            {
                //scope
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("ApiMutator", policy => policy.RequireClaim("scope", "api.write"));

                //claim
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
                options.AddPolicy("Buyer", policy => policy.RequireClaim(ClaimTypes.Role, "buyer"));
                options.AddPolicy("Supplier", policy => policy.RequireClaim(ClaimTypes.Role, "supplier"));
            });

            #endregion

            services.AddHttpContextAccessor();

            //Gets or sets a value that determines if the filter that returns an BadRequestObjectResult when 'ModelState is invalid' is suppressed. 
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                RegisteredServicesPage(app);
            } else
            {
                //Production Purpose
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //Remember to enable CORS or UseProxyToSpaDevelopmentServer

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllers();
                //endpoints.MapRazorPages();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        private void RegisteredServicesPage(IApplicationBuilder app)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
