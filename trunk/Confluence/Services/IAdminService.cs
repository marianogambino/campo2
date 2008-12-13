using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IAdminService
    {
        IList<User> FindAllUsers();
        IList<Family> FindAllFamilies();
        User FindUser(long id);
        void UpdateUser(long id, String mail, IList<int> familias, IList<int> patentes, String username);
        IList<Patente> FindPatAvailableForUser(long userId);
        IList<Patente> FindAllPatentes();
        IList<Family> FindFamAvailableForUser(long userId);
        IList<User> FindUsersLike(String name);
        void DeleteUser(long id,String username);
        void BlockUser(long id,String username);
        void DeleteFamily(long id, String username);
        void CreateFamily(String name, String description, IList<int> patentes, String username);
        bool FamilyExist(String name);
        IList<Patente> FindPatAvailableForFamily(long family_id);
        void UpdateFamily(long id,String description,IList<int> patentes, String username);
        Family FindFamilyById(long id);
        void BackUpDatabase(String username,bool complete);
        void RestoreDatabase(String username);
    }
}
