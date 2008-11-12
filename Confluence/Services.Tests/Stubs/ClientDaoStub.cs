using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services.Tests.Stubs
{
    public class ClientDaoStub : IClientDao
    {
        public void Persist(Client s) { }
        public void Update(Client s) { }
        public void Delete(Client s) { }
        public IList<Client> GetAll() { return null; }
        public Client GetById(long id) { return null; }
        public Client GetByName(String name) { return null; }
        public bool IsHR(String name) { return true; }
        public IList<Proposal> FindAllOffersFor(long id) { return null; }
        public void DeleteOffer(Proposal id) { }
        public Proposal GetOffer(long id) { return null; }

    }
}
