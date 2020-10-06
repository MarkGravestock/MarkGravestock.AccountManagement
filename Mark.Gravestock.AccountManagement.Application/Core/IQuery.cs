using MediatR;

namespace Mark.Gravestock.AccountManagement.Application.Core
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}