using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IUserDao : IDAO<User>
    {
        User GetByName(string userName);
        void flush();
        IList<User> FindLike(String name);
    }
}
