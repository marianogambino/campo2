using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Project : DomainObject
    {
        #region properties
        private long id;
        private ProjectState state;
        private Client owner;
        private Client developer;
        private String name;
        private String descripton;
        private Language language;
        private Publication publication;
        private DateTime start;
        private DateTime end;
        private IList<Question> questions;
        private IList<Offer> offers;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Name
        {
            set { name = value; }
            get { return name; }
        }
        [DV]
        public virtual String Description
        {
            set { descripton = value; }
            get { return descripton; }
        }
        [DV]
        public virtual DateTime Start
        {
            set { start = value; }
            get { return start.Date; }
        }
        [DV]
        public virtual DateTime End
        {
            set { end = value; }
            get { return end.Date; }
        }
        [DV(Property = "Id")]
        public virtual Language Language
        {
            set { language = value; }
            get { return language; }
        }
        [DV(Property="Id")]
        public virtual Client Owner
        {
            set { owner = value; }
            get { return owner; }
        }
        [DV(Property="Id")]
        public virtual Client Developer
        {
            set { developer = value; }
            get { return developer; }
        }
        [DV(Property = "Id")]
        public virtual ProjectState State
        {
            set { state = value; }
            get { return state; }
        }
        [DV(Property="Id")]
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
        public virtual IList<Offer> Offers
        {
            set { offers = value; }
            get { return offers; }
        }
        #endregion

        public Project() 
        {
            Questions = new List<Question>();
            Offers = new List<Offer>();
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
            found.CalculateDV();
        }
        public virtual void AddQuestion(Question question)
        {
            question.Project = this;
            question.CalculateDV();
            Questions.Add(question);
        }
        public virtual void AddOffer(Offer offer)
        {
            offer.Project = this;
            offer.CalculateDV();
            Offers.Add(offer);
        }
        public virtual void AcceptedBy(Client developer) 
        {
            Developer = developer;
            State = new ProjectState(2);//En Desarrollo
        }
        public override String ToString()
        {
            return Name;
        }
        public virtual void EndProject()
        {
            State = new ProjectState(3);
        }
        public virtual void CancelProject()
        {
            State = new ProjectState(4);
        }
    }
}
