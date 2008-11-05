using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using System.Data.Common;

namespace Confluence.DAL
{
    public class Log : ILog
    {
        private ConnectionFactory factory = ConnectionFactory.GetProductionFactory();

        public Log() { }
        public void LogAccess(User user)
        {
            factory.Execute(AccessCommand(user.Id, user.Name, AccessType.LOGIN));
        }
        public void LogExit(User user)
        {
            factory.Execute(AccessCommand(user.Id, user.Name, AccessType.LOGOUT));
        }
        public void LogAccesFailure(String user_name)
        {
            factory.Execute(AccessCommand(00, user_name, AccessType.FAIL));
        }
        public void LogOperation(String user_name, String message)
        {
            factory.Execute("INSERT INTO operation_log (user_name, operation, time) VALUES ('" + user_name + "','" + message + "','" + DateTime.Now.ToString() + "')");
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
