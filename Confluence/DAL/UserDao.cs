using System;
using System.Collections.Generic;
using System.Text;
using Spring.Data.NHibernate.Support;
using Confluence.Domain;
using System.Collections;

namespace Confluence.DAL
{
    public class UserDao : BaseDao<User>, IUserDao 
    {
        public UserDao() {}

        public override IList<User> GetAll()
        {
            return FindAllGeneric<User>("FROM User u");
        }

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
            message.CalculateDV();
            HibernateTemplate.Save(message);
        }
        public void DeleteAccount(User user_account)
        {
            IList<Client> found = QueryGeneric<Client>("From Client c WHERE c.UserAccount.Name=?", user_account.Name);
            HibernateTemplate.Delete(found[0]);
        }
        
    }
}
