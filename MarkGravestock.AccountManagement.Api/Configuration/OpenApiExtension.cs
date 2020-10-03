using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MarkGravestock.AccountManagement.Api.Configuration
{
    internal static class OpenApiExtension
    {
        private const string Name = "v1";
        private const string Title = "Accounts API";
        private const string Version = "v1";

        public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc(Name, new OpenApiInfo {Title = Title, Version = Version}); });

            return services;
        }

        public static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder application)
        {
            application.UseSwagger();

            application.UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/{Name}/swagger.json", $"{Title} {Version}"); });

            return application;
        }
    }
}