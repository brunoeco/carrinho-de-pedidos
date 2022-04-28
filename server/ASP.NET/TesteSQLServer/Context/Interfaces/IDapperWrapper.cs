using System.Collections.Generic;
using System.Data;

namespace TesteSQLServer.Context.Interfaces
{
    public interface IDapperWrapper
    {
        public IEnumerable<T> Query<T>(IDbConnection connection, string sql, object parameters);
    }
}
