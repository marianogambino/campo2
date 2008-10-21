using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class ContactService : IContactService
    {
        private IUserDao user_dao;
        public IUserDao UserDao
        {
            set { user_dao = value; }
            get { return user_dao; }
        }
        public void SaveMessage(String author, String mail, String message)
        {
            UserDao.SaveUserMessage(new Message(author, mail, message));
        }
    }
}
