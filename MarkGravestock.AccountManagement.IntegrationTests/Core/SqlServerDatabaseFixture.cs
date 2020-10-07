using FluentAssertions;
using MarkGravestock.AccountManagement.Infrastructure.Database.Migrations;

namespace MarkGravestock.AccountManagement.IntegrationTests.Core
{
    public class SqlServerDatabaseFixture
    {
        public SqlServerDatabaseFixture()
        {
            SetupDatabase(Configuration.DevelopmentConnectionString());
        }
        
        private void SetupDatabase(string connectionString)
        {
            SqlServerMigrator.DropDatabase(Configuration.DevelopmentConnectionString());

            var migrationResult = SqlServerMigrator.ApplyMigrations(connectionString);

            migrationResult.Error.Should().BeNull();
        }
    }
}