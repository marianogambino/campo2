using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Project
    {
        #region properties
        private long id;
        private ProjectState state;
        private Client owner;
        private String name;
        private String descripton;
        private Language language;
        private Publication publication;
        private DateTime start;
        private DateTime end;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        public virtual ProjectState State
        {
            set { state = value; }
            get { return state; }
        }
        public virtual Client Owner
        {
            set { owner = value; }
            get { return owner; }
        }
        public virtual String Name
        {
            set { name = value; }
            get { return name; }
        }
        public virtual String Description
        {
            set { descripton = value; }
            get { return descripton; }
        }
        public virtual Language Language
        {
            set { language = value; }
            get { return language; }
        }
        public virtual DateTime Start
        {
            set { start = value; }
            get { return start.Date; }
        }
        public virtual DateTime End
        {
            set { end = value; }
            get { return end.Date; }
        }
        public virtual Publication Publication
        {
            set { publication = value; }
            get { return publication; }
        }
        #endregion

        public Project() { }
    }
}
