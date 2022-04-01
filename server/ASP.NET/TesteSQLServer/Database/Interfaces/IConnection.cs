using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.Database.Interfaces
{
    public interface IConnection
    {
        public IDbConnection GetConnection();
    }
}
