using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Log
    {
        private long id;
        private Session session;
        private Operation operation;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual Session Session
        {
            get { return session; }
            set { session = value; }
        }
        public virtual Operation Operation
        {
            get { return operation; }
            set { operation = value; }
        }
    }
}
