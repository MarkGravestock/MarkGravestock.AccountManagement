using MediatR;

namespace Mark.Gravestock.AccountManagement.Application.Core
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}