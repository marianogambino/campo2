using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public class ClientDao : BaseDao, IClientDao
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
            return FindAllGeneric<Client>("From Client c");
        }
        public Client GetByName(String name)
        {
            IList<Client> found = QueryGeneric<Client>("From Client c WHERE c.UserAccount.Name=?", name);
            return (found.Count > 0) ? found[0] : null;
        }
    }
}
