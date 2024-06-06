using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerConnect.Data
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext(DbConnection connection) : base(connection, true)
        {
        }
    }
}
