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
        private ISecurityService security_service;
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
        public ISecurityService SecurityService
        {
            set { security_service = value; }
            get { return security_service; }
        }
        private ILog log_service;
        public ILog LogService
        {
            set { log_service = value; }
            get { return log_service; }
        }
        public bool UserExists(String name)
        {
            return ClientDao.GetByName(name) != null;
        }
        public void Register(Client client)
        {
            client.UserAccount.Password = SecurityService.GetHash(client.UserAccount.Password);
            ClientDao.Persist(client);
            LogService.LogOperation(client.UserAccount.Name, "Se registró el Usuario: " + client.UserAccount.Name);
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
        public bool IsHR(String username)
        {
            return ClientDao.IsHR(username);
        }
    }
}
