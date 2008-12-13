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
        private IHashService hash_service;
        public IHashService HashService
        {
            set { hash_service = value; }
            get { return hash_service; }
        }
        public bool UserExists(String name)
        {
            return ClientDao.GetByName(name) != null;
        }
        public void Register(Client client)
        {
            client.UserAccount.Password = SecurityService.GetHash(client.UserAccount.Password);
            client.UserAccount.CalculateDV();
            ClientDao.Persist(client);

            HashService.RepairDV();
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
        public bool IsHR(String user_name)
        {
            return ClientDao.GetByName(user_name).IsHR();
        }
        public Client GetClientFromAccountName(string name)
        {
            return ClientDao.GetByName(name);
        }
        public void UpdateProfile(string ac_name, string name, string mail, string country, string state, string phone)
        {
            Client client = ClientDao.GetByName(ac_name);
            client.Name = name;
            client.UserAccount.Mail = mail;
            client.Country = country;
            client.State = state;
            client.Phone = long.Parse(phone);
            ClientDao.Update(client);
        }
    }
}
