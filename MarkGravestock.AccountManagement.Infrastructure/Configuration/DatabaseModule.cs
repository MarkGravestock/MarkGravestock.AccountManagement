using Autofac;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using MarkGravestock.AccountManagement.Infrastructure.Accounts;
using MarkGravestock.AccountManagement.Infrastructure.Database;

namespace MarkGravestock.AccountManagement.Infrastructure.Configuration
{
    public class DatabaseModule : Module
    {
        private readonly string connectionString;

        public DatabaseModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new SqlServerConnectionFactory(connectionString)).As<ISqlConnectionFactory>().SingleInstance();
            builder.RegisterType<SqlServerAccountRepository>().As<IAccountRepository>().SingleInstance();
        }
    }
}