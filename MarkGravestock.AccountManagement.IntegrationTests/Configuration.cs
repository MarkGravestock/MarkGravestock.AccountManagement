using System.IO;
using MarkGravestock.AccountManagement.Api.Configuration;
using Microsoft.Extensions.Configuration;

namespace MarkGravestock.AccountManagement.IntegrationTests
{
    public static class Configuration
    {
        public static string DevelopmentConnectionString()
        {
            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            return configurationRoot.GetConnectionString(ConnectionString.AccountManagement);
        }
    }
}