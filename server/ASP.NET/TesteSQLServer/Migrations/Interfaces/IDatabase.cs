using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSQLServer.Migrations.Interfaces
{
    public interface IDatabase
    {
        public void CreateDatabase(string dbName);
    }
}
