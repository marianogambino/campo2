using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IUserDao : IDAO<User>
    {
        User GetByName(string userName);
        IList<User> FindLike(String name);
        void SaveUserMessage(Message message);
        void DeleteAccount(User uesr);
    }
}
