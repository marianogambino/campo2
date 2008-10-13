using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public class ClientDao : BaseDao<Client>, IClientDao
    {
        public override IList<Client> GetAll()
        {
            return FindAllGeneric<Client>("From Client c");
        }
        public Client GetByName(String name)
        {
            IList<Client> found = QueryGeneric<Client>("From Client c WHERE c.UserAccount.Name=?", name);
            return (found.Count > 0) ? found[0] : null;
        }
    }
}
