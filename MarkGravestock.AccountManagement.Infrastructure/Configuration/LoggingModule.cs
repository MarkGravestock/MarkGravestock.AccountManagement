using Autofac;
using Mark.Gravestock.AccountManagement.Application.Core;
using MarkGravestock.AccountManagement.Infrastructure.Logging;

namespace MarkGravestock.AccountManagement.Infrastructure.Configuration
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(LoggingCommandHandlerWithResultDecorator<,>), typeof(ICommandHandler<,>), context => context != null);
        }
    }
}