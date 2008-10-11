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
    }
}
