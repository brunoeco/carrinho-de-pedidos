using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Database.Interfaces;

namespace TesteSQLServer.Database
{
    public class Connection : IConnection
    {
        private readonly string ConnectionString;
        public Connection(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Default");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
