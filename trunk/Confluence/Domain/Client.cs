using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Client : DomainObject
    {
        #region properties
        private long id;
        private User user_account;
        private String name;
        private String country;
        private String state;
        private long phone;
        private IList<WorkXP> work_xp;
        private IList<Study> study;
        private IList<Proposal> proposals;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        [DV(Property="Id")]
        public virtual User UserAccount
        {
            get { return user_account; }
            set { user_account = value; }
        }
        [DV]
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        [DV]
        public virtual String Country
        {
            get { return country; }
            set { country = value; }
        }
        [DV]
        public virtual String State
        {
            get { return state; }
            set { state = value; }
        }
        [DV]
        public virtual long Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public virtual IList<WorkXP> WorkXP
        {
            set { work_xp = value; }
            get { return work_xp; }
        }
        public virtual IList<Study> Study
        {
            set { study = value; }
            get { return study; }
        }
        public virtual IList<Proposal> Proposals 
        {
            set { proposals = value; }
            get { return proposals; }
        }
        #endregion

        public Client() 
        {
            WorkXP = new List<WorkXP>();
            Study = new List<Study>();
        }

        public Client(String username, String pass, String name, String country):this()
        {
            Name = name;
            Country = country;
            UserAccount = new User(username, pass);
        }

        #region Equals & HashCode
        public override bool Equals(object obj)
        {
            if (obj is Client)
            {
                Client other = (Client)obj;
                return (UserAccount.Name.Equals(other.UserAccount.Name));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return UserAccount.Name.GetHashCode();
        }
        #endregion

        public virtual Offer MakeOffer(Double amount, DateTime date)
        {
            Offer of = new Offer(amount, date);
            of.Bidder = this;
            return of;
        }

        public override String ToString()
        {
            return Name;
        }
        public virtual void AddXP(WorkXP xp)
        {
            xp.Client = this;
            xp.CalculateDV();
            WorkXP.Add(xp);
        }
        public virtual void AddStudy(Study st)
        {
            st.Client = this;
            st.CalculateDV();
            Study.Add(st);
        }
        public virtual void AddProposal(Proposal prop)
        {
            prop.Resource = this;
            prop.CalculateDV();
            Proposals.Add(prop);
        }

        public virtual bool IsHR()
        {
            return UserAccount.Families.Contains(new Family("Ofertante", ""));
        }
        
    }
}
