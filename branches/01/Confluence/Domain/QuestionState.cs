using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class QuestionState
    {
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
        public QuestionState() { }
        public QuestionState(long id) { Id = id; }
    }
}
