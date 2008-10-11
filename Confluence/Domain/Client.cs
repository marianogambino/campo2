using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Client
    {
        #region properties
        private long id;
        private User user_account;
        private String name;
        private String country;
        private String state;
        private long phone;

        public virtual User UserAccount
        {
            get { return user_account; }
            set { user_account = value; }
        }
        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual String Country
        {
            get { return country; }
            set { country = value; }
        }
        public virtual String State
        {
            get { return state; }
            set { state = value; }
        }
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
        
    }
}
