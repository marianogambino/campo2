using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Message : DomainObject
    {
        #region properties
        private long id;
        private String author;
        private String mail;
        private String message;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Author
        {
            set { author = value; }
            get { return author; }
        }
        [DV]
        public virtual String Mail
        {
            set { mail = value; }
            get { return mail; }
        }
        [DV]
        public virtual String MessageText
        {
            set { message = value; }
            get { return message; }
        }
        #endregion
        public Message() { }

        public Message(string author, string mail, string message)
        {
            Author = author;
            Mail = mail;
            MessageText = message;
        }
        public override bool Equals(object other)
        {
            return (other is Message)?((Message)other).Id.Equals(Id) : false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
