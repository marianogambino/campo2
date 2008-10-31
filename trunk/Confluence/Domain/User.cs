using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class User : DomainObject
    {
        private long id;
        private String name;
        private String password;
        private String mail;
        private IList<Patente> patentes;
        private IList<Family> families;

        #region Constructors
        public User()
        {
            Patentes = new List<Patente>();
            Families = new List<Family>();
        }
        public User(String name, String password)
            : this()
        {
            Name = name;
            Password = password;
        }
        #endregion

        #region Getters & Setters
        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        [DV]
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        [DV]
        public virtual String Password
        {
            get { return password; }
            set { password = value; }
        }
        [DV]
        public virtual String Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public virtual IList<Patente> Patentes
        {
            get { return patentes; }
            set { patentes = value; }
        }
        public virtual IList<Family> Families
        {
            get { return families; }
            set { families = value; }
        }
        #endregion

        #region Equals & HashCode
        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User other = (User)obj;
                return (Name.Equals(other.Name));
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        #endregion
    }
}
