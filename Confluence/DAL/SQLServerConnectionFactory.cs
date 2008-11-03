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

        public override DbCommand GetCommand(String command)
        {
            return new SqlCommand(command, (SqlConnection)GetConnection());
        }
        public override DbConnection GetConnection()
        {
            connection =  new SqlConnection(CONNECTION_STRING);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
