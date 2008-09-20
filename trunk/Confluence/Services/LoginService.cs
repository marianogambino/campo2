using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class LoginService : ILoginService
    {
        private IUserDao userDao;

        public LoginService() { }

        public IUserDao UserDao
        {
            set { userDao = value; }
            get { return userDao; }
        }

        public User doLogin(string userName, string password)
        {
            User found = UserDao.GetByName(userName);

            if (found == null || ! found.Password.Equals(password))
                return null;
            else
                return found;
        }
    }
}
