using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using Confluence.DAL;

namespace Confluence.Services
{
    public class AdminService : IAdminService
    {
        private IUserDao userDao;
        public IUserDao UserDao
        {
            get { return userDao; }
            set { userDao = value; }
        }

        public IList<User> FindAll()
        {
            return UserDao.GetAll();
        }
    }
}
