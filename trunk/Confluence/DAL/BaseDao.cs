using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public abstract class BaseDao<T> : HibernateDaoSupport where T : DomainObject
    {
        private ILog log_service = new Log();
        public void Persist(T entity)
        {
            if (GetAll().Contains(entity))
                throw new DuplicateEntityException(entity.ToString());
            entity.CalculateDV();
            HibernateTemplate.Save(entity);
        }
        public T GetById(long id)
        {
            return (T)HibernateTemplate.Get(typeof(T), id);
        }
        public void Update(T entity)
        {
            entity.CalculateDV();
            HibernateTemplate.Update(entity);
        }
        public void Delete(T entity)
        {
            HibernateTemplate.Delete(entity);
        }
        protected IList<X> FindAllGeneric<X>(String query)
        {
            IList found = HibernateTemplate.Find(query);
            IList<X> result = new List<X>();
            foreach (object obj in found)
                result.Add((X)obj);
            return result;
        }
        protected IList<X> QueryGeneric<X>(String query, object parameter)
        {
            IList found = HibernateTemplate.Find(query,parameter);
            IList<X> result = new List<X>();
            foreach (object obj in found)
                result.Add((X)obj);
            return result;
        }
        protected IList<X> QueryNamedParams<X>(String query, String[] names, object[] values)
        {
            IList found = HibernateTemplate.FindByNamedParam(query, names, values);
            IList<X> result = new List<X>();
            foreach (object o in found)
                result.Add((X)o);
            return result;
        }
        public abstract IList<T> GetAll();
    }
}
