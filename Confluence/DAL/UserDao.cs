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
            User exists = GetByName(entity.Name);
            if (exists != null)
                throw new DuplicateEntityException(entity.Name);
            HibernateTemplate.Save(entity);
        }

        public void Delete(User entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public void Update(User entity)
        {
            HibernateTemplate.Update(entity);
        }

        public IList<User> GetAll()
        {
            IList<User> users = new List<User>();
            IList found =  HibernateTemplate.Find("FROM User u");
            foreach(object obj in found)
                users.Add((User)obj);
            return users;
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
        public void flush(){
            HibernateTemplate.Flush();
        }

        public IList<User> FindLike(String name)
        {
            IList found = HibernateTemplate.Find("FROM User u WHERE u.Name like ?", "%" + name + "%");
            IList<User> users = new List<User>();
            foreach (object obj in found)
                users.Add((User)obj);
            return users;
        }

        private IList<T> FindGeneric<T>(String query)
        {
            IList found = HibernateTemplate.Find(query);
            IList<T> result = new List<T>();
            foreach (object obj in found)
                result.Add((T)obj);
            return result;
        }
    }
}
