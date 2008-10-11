using System;
using System.Collections.Generic;
using System.Text;
using Spring.Data.NHibernate.Support;
using Confluence.Domain;
using System.Collections;

namespace Confluence.DAL
{
    public class UserDao : BaseDao, IUserDao 
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
            return FindAllGeneric<User>("FROM User u");
        }

        #endregion

        public User GetByName(string name)
        {
            IList users = (IList) HibernateTemplate.Find("FROM User u WHERE u.Name = ?",name);
            return (users.Count > 0) ? (User)users[0] : null;
        }

        public IList<User> FindLike(String name)
        {
            return QueryGeneric<User>("FROM User u WHERE u.Name like ?", "%" + name + "%");
        }
        public void SaveUserMessage(Message message)
        {
            HibernateTemplate.Save(message);
        }
    }
}
