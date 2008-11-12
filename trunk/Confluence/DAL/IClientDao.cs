using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IClientDao : IDAO<Client>
    {
        Client GetByName(String name);
        IList<Proposal> FindAllOffersFor(long id);
        Proposal GetOffer(long id);
        void DeleteOffer(Proposal offer);
    }
}
