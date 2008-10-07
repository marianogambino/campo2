using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IAdminService
    {
        IList<User> FindAllUsers();
        User FindUser(long id);
        void UpdateUser(long id, String mail, int[] familias, int[] patentes);
    }
}
