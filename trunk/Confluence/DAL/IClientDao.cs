using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IClientDao : IDAO<Client>
    {
        Client GetByName(String name);
        bool IsHR(String name);
    }
}
