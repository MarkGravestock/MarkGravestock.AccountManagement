using Autofac;

namespace MarkGravestock.AccountManagement.Infrastructure.Configuration
{
    public class InfrastructureModule : Module
    {
        private readonly string connectionString;

        public InfrastructureModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DatabaseModule(connectionString));
            builder.RegisterModule<LoggingModule>();
        }
    }
}