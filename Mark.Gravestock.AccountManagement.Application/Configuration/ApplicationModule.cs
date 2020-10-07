using System.Reflection;
using Autofac;
using Mark.Gravestock.AccountManagement.Application.Accounts;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace Mark.Gravestock.AccountManagement.Application.Configuration
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(Assembly.GetExecutingAssembly());
            builder.RegisterType<OpenAccountCommandHandler>().AsImplementedInterfaces();
        }
    }
}