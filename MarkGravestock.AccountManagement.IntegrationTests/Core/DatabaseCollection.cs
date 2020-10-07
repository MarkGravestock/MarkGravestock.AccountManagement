using Xunit;

namespace MarkGravestock.AccountManagement.IntegrationTests.Core
{
    [CollectionDefinition(Collections.Database)]
    public class DatabaseCollection : ICollectionFixture<SqlServerDatabaseFixture>
    {
    }
}