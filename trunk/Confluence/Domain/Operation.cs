using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Operation
    {
        private long id;
        private String name;
        private String description;
        private OperationType operationType;

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
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }
        public virtual OperationType OperationType
        {
            set { operationType = value; }
            get { return operationType; }
        }
    }
}
