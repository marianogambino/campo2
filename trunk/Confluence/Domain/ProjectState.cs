using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class ProjectState
    {
        #region properties
        private long id;
        private String name;
        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        public virtual String Name
        {
            set { name = value; }
            get { return name; }
        }
        #endregion

        public ProjectState() { }
        public ProjectState(long id)
        {
            Id = id;
        }

        public override String ToString()
        {
            return Name;
        }
        public virtual bool IsFree()
        {
            return (Id == 1);
        }

    }
}
