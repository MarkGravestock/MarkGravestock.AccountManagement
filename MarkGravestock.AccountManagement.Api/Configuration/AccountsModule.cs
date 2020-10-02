using Autofac;
using MarkGravestock.OrderManagement.Api.Accounts;

namespace MarkGravestock.OrderManagement.Api.Configuration
{
    public class AccountsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryAccountRepository>().As<IAccountRepository>().SingleInstance();
        }
    }
}