using MediatR;

namespace Mark.Gravestock.AccountManagement.Application.Core
{
    internal interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}