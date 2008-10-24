using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Confluence.DAL
{
    public abstract class ConnectionFactory
    {
        public abstract DbConnection GetConnection();
        public abstract DbCommand GetCommand(String command);
    }
}
