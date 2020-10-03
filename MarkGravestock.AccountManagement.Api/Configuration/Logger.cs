using Serilog;
using Serilog.Events;

namespace MarkGravestock.AccountManagement.Api.Configuration
{
    internal static class Logger
    {
        public static LoggerConfiguration CreateLoggerConfiguration()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console();
        }
    }
}