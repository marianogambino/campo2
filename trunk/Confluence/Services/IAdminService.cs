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
        void UpdateUser(long id, String mail, IList<int> familias, IList<int> patentes);
        IList<Patente> FindPatAvailableForUser(long userId);
        IList<Family> FindFamAvailableForUser(long userId);
    }
}
