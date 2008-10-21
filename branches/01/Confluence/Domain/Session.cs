using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Session
    {
        private long id;
        private User user;
        private DateTime dateAndTime;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual User User
        {
            get { return user; }
            set { user = value; }
        }

        public virtual DateTime DateAndTime
        {
            get { return dateAndTime; }
            set { dateAndTime = value; }
        }
    }
}
