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

        public IList<User> FindAllUsers()
        {
            return UserDao.GetAll();
        }

        public User FindUser(long id)
        {
            return UserDao.GetById(id);
        }

        public void UpdateUser(long id, String mail, int[] familias, int[] patentes)
        {

        }
    }
}
