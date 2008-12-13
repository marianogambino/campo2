using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Confluence.DAL
{
    public class BackUpService : IBackUpService
    {
        private ConnectionFactory factory = ConnectionFactory.GetProductionFactory();
        private const String BACKUP_PROCEDURE = "Confluence_Backup";
        private const String DIFF_BACKUP_PROCEDURE = "Confluence_Diff_Backup";
        private const String RESTORE_PROCEDURE = @"RESTORE DATABASE Confluence FROM DISK = 'c:\confluence_restore.bak' WITH REPLACE";

        public void BackUp()
        {
           factory.Execute(BACKUP_PROCEDURE);
        }
        public void DifferentialBackup()
        {
            factory.Execute(DIFF_BACKUP_PROCEDURE);
        }
        public void Restore()
        {
            factory.UseMasterCommand(delegate(DbCommand cmd)
            {
                try
                {
                    cmd.CommandText = RESTORE_PROCEDURE;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new BusyDatabaseException();
                }
                
            });
        }
    }
}
