using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Question
    {
        private long id;
        private String text;
        private Answer answer;
        private QuestionState state;

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
        public virtual Answer Answer
        {
            set { answer = value; }
            get { return answer; }
        }
        public virtual QuestionState State
        {
            set { state = value; }
            get { return state; }
        }
        public Question() { }

    }
}
