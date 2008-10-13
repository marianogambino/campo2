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
        private IList<Question> questions;

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
        public virtual IList<Question> Questions
        {
            set { questions = value; }
            get { return questions; }
        }
        #endregion

        public Project() 
        {
            Questions = new List<Question>();
        }
        public virtual IList<Question> UnansweredQuestions
        {
            get
            {
                List<Question> result = new List<Question>();
                foreach (Question q in Questions)
                    if (q.State.Id != 2) result.Add(q);
                return result;
            }
        }
        public virtual void AnswerQuestion(Question question, String answer)
        {
            Question found = null;
            foreach (Question q in Questions)
                if (q.Id == question.Id) found = q;

            found.Answer = new Answer(answer);
            found.State = new QuestionState(2);//Answered!
        }
    }
}
