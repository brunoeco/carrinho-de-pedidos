using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;

namespace TesteSQLServer.Context
{
    public class DapperContext : IConnection
    {
        private readonly IConfiguration Configuration;
        public DapperContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(Configuration.GetConnectionString("SQLConnection"));
        }

        public IDbConnection GetMasterConnection()
        {
            return new SqlConnection(Configuration.GetConnectionString("MasterConnection"));
        }
    }
}
