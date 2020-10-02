using Autofac;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using Mark.Gravestock.AccountManagement.Infrastructure.Accounts;

namespace Mark.Gravestock.AccountManagement.Infrastructure.Configuration
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryAccountRepository>().As<IAccountRepository>().SingleInstance();
        }
    }
}