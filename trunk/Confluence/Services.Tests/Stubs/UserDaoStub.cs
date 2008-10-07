using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services.Tests.Stubs
{
    public class UserDaoStub : IUserDao
    {
        private IList<User> users;

        public UserDaoStub()
        {
            users = new List<User>();
            users.Add(new User("Stub1","pass1"));
            users.Add(new User("Stub2","pass2"));
        }

        public User GetByName(string userName)
        {
            foreach(User user in users)
                if (user.Name.Equals(userName)) return user;

            return null;
        }
        public IList<User> GetAll()
        {
            return users;
        }

        public User GetById(long id)
        {
            return users[(int)id];
        }

        public void Persist(User entity)
        {
            //Persistido! :)
        }

        public void Delete(User entity)
        {
            //Borrado ;)
        }

        public void Update(User entity)
        {
            //Updateado :D
        }
        public void flush() { }

    }
}
