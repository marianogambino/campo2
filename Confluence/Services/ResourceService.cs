using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using Confluence.DAL;

namespace Confluence.Services
{
    public class ResourceService : IResourceService
    {
        private IClientDao client_dao;
        public IClientDao ClientDao
        {
            set { client_dao = value; }
            get { return client_dao; }
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

        public IList<Client> FindAll()
        {
            IList<Client> clients = new List<Client>();
            
            foreach(Client c in ClientDao.GetAll())
            {
                if(c.IsHR())
                    clients.Add(c);
            }
            return clients;
        }
        public Client Find(long id)
        {
            return ClientDao.GetById(id);
        }

        public void MakeOffer(string user_name, long resource_id, double amount, string description)
        {
            Client resource = ClientDao.GetById(resource_id);
            Proposal offer = new Proposal(amount, description);
            resource.AddProposal(offer);
            ClientDao.Update(resource);

            HashService.RepairDV();
            LogService.LogOperation(user_name, "Se Realizó una oferta por el recurso: " + resource.Name);
        }
    }
}
