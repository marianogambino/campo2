using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IServiceDao : IDAO<Service>
    {
        IList<Language> GetAllLanguages();
        IList<ServiceType> GetAllServiceTypes();
        IList<Service> FindForUser(String username);
        IList<Service> GetAllByName(String username, String name);
        Language GetLanguageById(long id);
        ServiceType GetServiceTypeById(long id);
    }
}
