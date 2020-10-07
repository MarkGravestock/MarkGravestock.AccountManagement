using MediatR;

namespace Mark.Gravestock.AccountManagement.Application.Core
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}