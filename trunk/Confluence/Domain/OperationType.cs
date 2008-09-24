using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class OperationType
    {
        private long id;
        private String name;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
