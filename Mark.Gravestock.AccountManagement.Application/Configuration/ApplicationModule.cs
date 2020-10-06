using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace Mark.Gravestock.AccountManagement.Application.Configuration
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(Assembly.GetExecutingAssembly());
        }
    }
}