using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.Migrations.Interfaces;

namespace TesteSQLServer.Migrations
{
    public class Database : IDatabase
    {
        private readonly IConnection Context;

        public Database(IConnection context)
        {
            Context = context;
        }

        public void CreateDatabase(string dbName)
        {
            var query = $"SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using var connection = Context.GetMasterConnection();
            var records = connection.Query(query, parameters);

            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE [{dbName}]");
            }
        }
    }
}
