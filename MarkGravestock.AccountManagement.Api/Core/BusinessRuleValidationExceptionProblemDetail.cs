using Mark.Gravestock.AccountManagement.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkGravestock.AccountManagement.Api.Core
{
    internal class BusinessRuleValidationExceptionProblemDetail : ProblemDetails
    {
        internal BusinessRuleValidationExceptionProblemDetail(BusinessRuleValidationException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Detail = ex.Message;
        }
    }
}