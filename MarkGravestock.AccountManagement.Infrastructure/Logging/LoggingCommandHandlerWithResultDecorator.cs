using System;
using System.Threading;
using System.Threading.Tasks;
using Mark.Gravestock.AccountManagement.Application.Core;
using Serilog;

namespace MarkGravestock.AccountManagement.Infrastructure.Logging
{
    public class LoggingCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ILogger logger;
        private readonly ICommandHandler<T, TResult> decorated;

        public LoggingCommandHandlerWithResultDecorator(
            ILogger logger,
            ICommandHandler<T, TResult> decorated)
        {
            this.logger = logger;
            this.decorated = decorated;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            try
            {
                logger.Information( "Executing command {@Command}", command);

                var result = await decorated.Handle(command, cancellationToken);

                logger.Information("Command processed successful, result {Result}", result);

                return result;
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Command processing failed");
                throw;
            }
        }
    }
}