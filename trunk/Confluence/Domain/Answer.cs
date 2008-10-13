using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Answer
    {
        private long id;
        private String text;
        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        public virtual String Text
        {
            set { text = value; }
            get { return text; }
        }
        public Answer() { }
        public Answer(String text)
        {
            Text = text;
        }
    }
}
