using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Study : DomainObject
    {
        private static Dictionary<int, string> levels;
        static Study()
        {
            levels = new Dictionary<int, string>();
            levels.Add(1, "Primario");
            levels.Add(2, "Secundario");
            levels.Add(3, "Terciario");
            levels.Add(4, "Universitario");
        }

        private long id;

        private String institute;
        private int level;
        private int year_start;
        private int year_end;
        private Client client;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Institute
        {
            set { institute = value; }
            get { return institute; }
        }
        [DV]
        public virtual int YearStart
        {
            set { year_start = value; }
            get { return year_start; }
        }
        [DV]
        public virtual int YearEnd
        {
            set { year_end = value; }
            get { return year_end; }
        }
        [DV]
        public virtual int Level
        {
            set { level = value; }
            get { return level; }
        }
        [DV(Property="Id")]
        public virtual Client Client
        {
            set { client = value; }
            get { return client; }
        }
        public Study() { }
        public Study(String place, int start, int end, int level) 
        {
            Institute = place;
            YearStart = start;
            YearEnd = end;
            Level = level;
        }
        public virtual String StringLevel
        {
            get { return levels[Level]; }
        }
        

    }
}
