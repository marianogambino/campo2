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
        private ISecurityService security_service;
        public ISecurityService SecurityService
        {
            set { security_service = value; }
            get { return security_service; }
        }

        public LoginService() { }

        public IUserDao UserDao
        {
            set { userDao = value; }
            get { return userDao; }
        }

        public User doLogin(string userName, string pass)
        {
            User found = UserDao.GetByName(userName);
            String password = SecurityService.GetHash(pass);

            if (found == null || ! found.Password.Equals(password))
                return null;
            else
                return found;
        }
    }
}
