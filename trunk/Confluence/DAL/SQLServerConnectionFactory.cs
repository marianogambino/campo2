using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Confluence.DAL
{
    public class SQLServerConnectionFactory : ConnectionFactory
    {
        private SqlConnection connection;
        private const String CONNECTION_STRING = "Data Source=PABLO;Initial Catalog=Confluence;Integrated Security=True";
        private const String RESTORE_STRING = "Data Source=PABLO;Initial Catalog=master;Integrated Security=True;Connect Timeout=2";

        public override DbConnection GetConnection()
        {
            connection =  new SqlConnection(CONNECTION_STRING);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
        public override DbConnection GetMasterConnection()
        {
            connection = new SqlConnection(RESTORE_STRING);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
    }
}
