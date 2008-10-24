using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface ILog
    {
        void LogAccess(User user);
        void LogExit(User user);
        void LogAccesFailure(String user_name);

        void LogSave(Object entity);
        void LogDelete( Object entity);
        void LogUpdate(Object entity);
    }
}
