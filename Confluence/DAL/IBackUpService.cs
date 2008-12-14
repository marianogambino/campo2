using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public interface IBackUpService
    {
        void BackUp();
        void Restore();
        void DifferentialBackup();
        void ScheduleBackup(DateTime date);
        void CheckSchedule();
    }
}
