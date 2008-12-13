using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IRegistryService
    {
        bool UserExists(String name);
        void Register(Client client);
        IList<Family> GetDemanderFams();
        IList<Family> GetSupplierFams();
        bool IsHR(String user_name);
        Client GetClientFromAccountName(string name);
        void UpdateProfile(string ac_name, string name, string mail, string country, string state, string phone);
    }
}
