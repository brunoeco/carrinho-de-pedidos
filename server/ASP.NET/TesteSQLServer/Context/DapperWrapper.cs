using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Context.Interfaces;

namespace TesteSQLServer.Context
{
    public class DapperWrapper : IDapperWrapper
    {
        public IEnumerable<T> Query<T>(IDbConnection connection, string sql, object parameters)
        {
            return connection.Query<T>(sql, parameters);
        }
    }
}
