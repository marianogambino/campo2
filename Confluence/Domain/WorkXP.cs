using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class WorkXP : DomainObject
    {
        private long id;
        private String place;
        private int year_start;
        private int year_end;
        private Client client;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Place
        {
            set { place = value; }
            get { return place; }
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
        [DV(Property="Id")]
        public virtual Client Client
        {
            set { client = value; }
            get { return client; }
        }
        public WorkXP() { }
        public WorkXP(String place, int start, int end)
        {
            Place = place;
            YearStart = start;
            YearEnd = end;
        }
    }
}
