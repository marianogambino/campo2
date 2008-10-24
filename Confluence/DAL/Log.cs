using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using System.Data.Common;

namespace Confluence.DAL
{
    public class Log : ILog
    {
        private ConnectionFactory factory = new SQLServerConnectionFactory();

        public Log() { }
        public void LogAccess(User user)
        {
            DbCommand cmd = factory.GetCommand(AccessCommand(user.Id,user.Name,AccessType.LOGIN));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public void LogExit(User user)
        {
            DbCommand cmd = factory.GetCommand(AccessCommand(user.Id,user.Name, AccessType.LOGOUT));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public void LogAccesFailure(String user_name)
        {
            DbCommand cmd = factory.GetCommand(AccessCommand(00,user_name, AccessType.FAIL));
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public void LogSave(object obj)
        {

        }
        public void LogUpdate(object obj)
        {

        }
        public void LogDelete(object obj)
        {

        }
        private String AccessCommand(long user_id,String user_name, AccessType type)
        {
            return "INSERT INTO access_log (user_id, user_name, time, action) VALUES (" + user_id.ToString() + ",'" + user_name + "','"
                                                                                        + DateTime.Now.ToString() + "','" + type.ToString() + "')";
        }
    }
    enum AccessType
    {
        LOGIN = 1,
        LOGOUT = 2,
        FAIL = 3
    }
}
