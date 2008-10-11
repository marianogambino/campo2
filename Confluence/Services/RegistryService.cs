using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class RegistryService : IRegistryService
    {
        private IClientDao client_dao;
        public IClientDao ClientDao
        {
            set { client_dao = value; }
            get { return client_dao; }
        }
        public bool UserExists(String name)
        {
            return ClientDao.GetByName(name) != null;
        }
        public void Register(Client client)
        {
            ClientDao.Persist(client);
        }
        public IList<Family> GetDemanderFams()
        {
            return new List<Family>();
        }
        public IList<Family> GetSupplierFams()
        {
            return new List<Family>();
        }
    }
}
