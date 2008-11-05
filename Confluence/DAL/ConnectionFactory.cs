using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Confluence.DAL
{
    public abstract class ConnectionFactory
    {
        public static ConnectionFactory GetProductionFactory() { return new SQLServerConnectionFactory(); }

        public abstract DbConnection GetConnection();
        public abstract DbConnection GetMasterConnection();

        public void UseCommand(CommandHandler del)
        {
            using (DbConnection connection = GetConnection())
            {
                DbCommand cmd = connection.CreateCommand();
                del.Invoke(cmd);
            }
        }
        public void UseMasterCommand(CommandHandler del)
        {
            using (DbConnection connection = GetMasterConnection())
            {
                DbCommand cmd = connection.CreateCommand();
                del.Invoke(cmd);
            }
        }

        public void Execute(String command)
        {
            using (DbConnection cn = GetConnection())
            {
                DbCommand cmd = cn.CreateCommand();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
        }
        public delegate void CommandHandler(DbCommand command);
    }
}
