using MediatR;

namespace Mark.Gravestock.AccountManagement.Application.Core
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
    }
}