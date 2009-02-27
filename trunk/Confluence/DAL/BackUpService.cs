using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.SqlEnum;
using Microsoft.SqlServer.Management.Common;

namespace Confluence.DAL
{
    public class BackUpService : IBackUpService
    {
        private ConnectionFactory factory = ConnectionFactory.GetProductionFactory();
        private const String BACKUP_PROCEDURE = "Confluence_Backup";
        private const String DIFF_BACKUP_PROCEDURE = "Confluence_Diff_Backup";
        private const String RESTORE_PROCEDURE = @"RESTORE DATABASE Confluence FROM DISK = 'c:\confluence_restore.bak' WITH REPLACE";
        private const String SCHEDULED_BKP = "scheduled_backup";
        private const String SERVER_NAME = "PABLO";
        private const String DB_NAME = "Confluence";

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
            Server server = new Server(SERVER_NAME);
            Database db = server.Databases[DB_NAME];
            Microsoft.SqlServer.Management.Smo.Restore rst = new Restore();

            rst.Devices.AddDevice(@"c:\confluence_restore.bak", DeviceType.File);
            rst.Database = DB_NAME;
            rst.ReplaceDatabase = true;

            if (!rst.SqlVerify(server))  throw new FormatException();

            if (db != null) server.KillAllProcesses(DB_NAME);
            rst.SqlRestore(server);
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
