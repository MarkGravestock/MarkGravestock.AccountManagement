using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace MarkGravestock.AccountManagement.Infrastructure.Database.Migrations
{
    public class Migrator
    {
        [ExcludeFromCodeCoverage]
        public static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=(LocalDb)\\MSSQLLocalDB; Database=AccountManagement; Trusted_connection=true";

            var result = ApplyMigrations(connectionString);

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }

        public static DatabaseUpgradeResult ApplyMigrations(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            return upgrader.PerformUpgrade();
        }
    }
}