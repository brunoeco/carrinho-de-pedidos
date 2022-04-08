using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.Migrations;
using TesteSQLServer.Migrations.Interfaces;

namespace TesteSQLServer.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<IDatabase>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabase("sql-db-dev-ymk-carrinho-pedidos");

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch
                {
                    throw;
                }
            }

            return host;
        }
    }
}
