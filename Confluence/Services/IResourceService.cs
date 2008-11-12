using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IResourceService
    {
        IList<Client> FindAll();
        Client Find(long id);
        void MakeOffer(string user_name, long resource_id, double amount, string description);
        IList<Proposal> FindAllOffersForEmployer(long employer_id);
        void DeleteOffer(long proposal_id);
    }
}
