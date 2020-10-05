using System.Net.Security;
using Hellang.Middleware.ProblemDetails;
using Mark.Gravestock.AccountManagement.Domain.Core;
using MarkGravestock.AccountManagement.Api.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MarkGravestock.AccountManagement.Api.Configuration
{
    public static class ProblemDetailsExtension
    {
        public static IServiceCollection AddConfiguredProblemDetails(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddProblemDetails(options => Configure(options));
        }

        private static void Configure(ProblemDetailsOptions options)
        {
            options.Map<BusinessRuleValidationException>(x => new BusinessRuleValidationExceptionProblemDetail(x));
        }
    }
}