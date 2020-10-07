using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Mark.Gravestock.AccountManagement.Application.Configuration;
using MarkGravestock.AccountManagement.Api.Configuration;
using MarkGravestock.AccountManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MarkGravestock.AccountManagement.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private ILifetimeScope AutofacContainer { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguredProblemDetails();
            
            services.AddControllers();

            services.AddOpenApiDocumentation();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule(new InfrastructureModule(configuration.GetConnectionString(ConnectionString.AccountManagement)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseProblemDetails();
                app.UseHsts();
            }

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseOpenApiDocumentation();
        }
    }
}