using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IServiceService
    {
        IList<Service> FindServicesForUser(String username);
        void Delete(long id);
        IList<Service> FindServicesByName(String username, String name);
        IList<ServiceType> GetAllSTypes();
        IList<Language> GetAllLangs();
        void Save(String user, String name, String desc, long lang_id, long type_id);
    }
}
