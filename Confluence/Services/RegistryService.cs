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
        private IFamilyDao family_dao;
        public IClientDao ClientDao
        {
            set { client_dao = value; }
            get { return client_dao; }
        }
        public IFamilyDao FamilyDao
        {
            set { family_dao = value; }
            get { return family_dao; }
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
            IList<Family> fams = new List<Family>();
            fams.Add(FamilyDao.GetById(2));
            return fams;
        }
        public IList<Family> GetSupplierFams()
        {
            IList<Family> fams = new List<Family>();
            fams.Add(FamilyDao.GetById(1));
            return fams;
        }
    }
}
