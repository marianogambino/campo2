using System;
using System.Collections.Generic;
using System.Text;
using Spring.Data.NHibernate.Support;
using Confluence.Domain;
using System.Collections;

namespace Confluence.DAL
{
    public class UserDao : HibernateDaoSupport, IUserDao 
    {
        public UserDao() {}

        #region CRUD

        public User GetById(long id)
        {
            return (User) HibernateTemplate.Get(typeof(User), id);
        }

        public void Persist(User entity)
        {
            HibernateTemplate.Save(entity);
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        public User GetByName(string name)
        {
            IList users = (IList) HibernateTemplate.Find("FROM User u WHERE u.Name = ?",name);

            User user = null;

            if(users.Count>0)
                user = (User)users[0];

            return user;
        }

    }
}