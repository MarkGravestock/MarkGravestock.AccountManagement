﻿using Autofac;
using Mark.Gravestock.AccountManagement.Domain.Accounts;
using MarkGravestock.AccountManagement.Infrastructure.Accounts;
using MarkGravestock.AccountManagement.Infrastructure.Database;

namespace MarkGravestock.AccountManagement.Infrastructure.Configuration
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //TODO: Move to caller. Use configuration type?
            builder.RegisterInstance("Server=(LocalDb)\\MSSQLLocalDB; Database=AccountManagement; Trusted_connection=true").As<string>();
            builder.RegisterType<SqlServerConnectionFactory>().As<ISqlConnectionFactory>().SingleInstance();
            builder.RegisterType<SqlServerAccountRepository>().As<IAccountRepository>().SingleInstance();
        }
    }
}