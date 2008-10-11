using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public class ClientDao : HibernateDaoSupport, IClientDao
    {
        public Client GetById(long id) 
        {
            return (Client)HibernateTemplate.Get(typeof(Client), id);
        }
        public void Persist(Client entity)
        {
            if (GetAll().Contains(entity)) 
                throw new DuplicateEntityException(entity.Name);

            HibernateTemplate.Save(entity);
        }
        public void Delete(Client entity)
        {
            HibernateTemplate.Delete(entity);
        }
        public void Update(Client entity)
        {
            HibernateTemplate.Update(entity);
        }
        public IList<Client> GetAll()
        {
            IList found = HibernateTemplate.Find("FROM Client c");
            IList<Client> clients = new List<Client>();
            foreach (object obj in found)
                clients.Add((Client)obj);
            return clients;

        }
        public Client GetByName(String name)
        {
            IList found = HibernateTemplate.Find("FROM Client c WHERE c.UserAccount.Name = ?", name);
            return (found.Count > 0) ? (Client)found[0] : null;
        }
    }
}
