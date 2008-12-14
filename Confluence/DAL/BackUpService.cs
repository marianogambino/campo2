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
        private const String SCHEDULED_BKP = "scheduled_backup";

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
        public void ScheduleBackup(DateTime date)
        {
            factory.UseCommand(delegate(DbCommand cmd)
            {
                cmd.CommandText = "Insert Into scheduled_backups (date, done) VALUES ('" + date.ToShortDateString() + "',0)";
                cmd.ExecuteNonQuery();
            });
        }
        public void CheckSchedule()
        {
            bool do_it = false;
            factory.UseCommand(delegate(DbCommand cmd)
            {
                cmd.CommandText = "Select id, date From scheduled_backups where done = 0";
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read() && !do_it)
                {
                    DateTime date = DateTime.Parse(reader[1].ToString());
                    do_it = (date < DateTime.Today);
                    if (do_it) RemoveFromSchedule(int.Parse(reader[0].ToString()));
                }
            });
            if (do_it) PerformScheduledBackup();
        }
        private void RemoveFromSchedule(int id)
        {
            factory.UseCommand(delegate(DbCommand cmd)
            {
                cmd.CommandText = "Update scheduled_backups Set done = 1 Where id = " + id;
                cmd.ExecuteNonQuery();
            });
        }
        private void PerformScheduledBackup()
        {
            factory.Execute(SCHEDULED_BKP);
        }
    }
}
