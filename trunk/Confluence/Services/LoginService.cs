using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;

namespace Confluence.Services
{
    public class LoginService : ILoginService
    {
        private IUserDao userDao;

        public LoginService() { }

        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public bool doLogin(string userName, string password)
        {
            //userDao.SaveUser();
            return false;
        }

    }
}
