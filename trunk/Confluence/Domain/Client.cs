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
        #endregion

        public Client() { }

        public Client(String username, String pass, String name, String country)
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
        
    }
}
