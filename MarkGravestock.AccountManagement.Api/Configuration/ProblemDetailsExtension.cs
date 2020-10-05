using Hellang.Middleware.ProblemDetails;
using Mark.Gravestock.AccountManagement.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MarkGravestock.AccountManagement.Api.Configuration
{
    public static class ProblemDetailsExtension
    {
        public static IServiceCollection AddConfiguredProblemDetails(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddProblemDetails(Configure);
        }

        private static void Configure(ProblemDetailsOptions options)
        {
            options.MapToStatusCode<BusinessRuleValidationException>(StatusCodes.Status400BadRequest);
        }
    }
}