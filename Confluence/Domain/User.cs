using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class User
    {
        private long id;
        private String name;
        private String password;
        private String mail;
        private IList<Patente> patentes;

        #region Constructors
        public User()
        {
            Patentes = new List<Patente>();
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
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual String Password
        {
            get { return password; }
            set { password = value; }
        }
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
        #endregion

        
    }
}
