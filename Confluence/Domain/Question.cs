using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Question : DomainObject
    {
        private long id;
        private String text;
        private Answer answer;
        private QuestionState state;
        private Project project;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
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
        [DV(Property="Id")]
        public virtual QuestionState State
        {
            set { state = value; }
            get { return state; }
        }
        [DV(Property="Id")]
        public virtual Project Project
        {
            set { project = value; }
            get { return project; }
        }
        public Question() { }
        public Question(String text)
        {
            State = new QuestionState(1);//En Curso
            Text = text;
        }
    }
}
