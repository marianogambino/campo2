using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public class ServiceDao : HibernateDaoSupport, IServiceDao
    {
        public Service GetById(long id)
        {
            return (Service)HibernateTemplate.Get(typeof(Service), id);
        }
        public void Persist(Service entity)
        {
            HibernateTemplate.Save(entity);
        }
        public void Delete(Service entity)
        {
            HibernateTemplate.Delete(entity);
        }
        public void Update(Service entity)
        {
            HibernateTemplate.Update(entity);
        }
        public IList<Service> GetAll()
        {
            return FindGeneric<Service>("FROM Service s");
        }
        public IList<Language> GetAllLanguages()
        {
            return FindGeneric<Language>("FROM Language l");
        }
        public IList<ServiceType> GetAllServiceTypes()
        {
            return FindGeneric<ServiceType>("FROM ServiceType st");
        }

        private IList<T> FindGeneric<T>(String query)
        {
            IList found = HibernateTemplate.Find(query);
            IList<T> result = new List<T>();
            foreach (object obj in found)
                result.Add((T)obj);
            return result;
        }

    }
}
