using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public abstract class BaseDao<T> : HibernateDaoSupport
    {
        public void Persist(T entity)
        {
            if (GetAll().Contains(entity))
                throw new DuplicateEntityException(entity.ToString());

            HibernateTemplate.Save(entity);
        }
        public T GetById(long id)
        {
            return (T)HibernateTemplate.Get(typeof(T), id);
        }
        public void Save(T entity)
        {
            HibernateTemplate.Save(entity);
        }
        public void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }
        public void Delete(T entity)
        {
            HibernateTemplate.Delete(entity);
        }
        protected IList<T> FindAllGeneric<T>(String query)
        {
            IList found = HibernateTemplate.Find(query);
            IList<T> result = new List<T>();
            foreach (object obj in found)
                result.Add((T)obj);
            return result;
        }
        protected IList<T> QueryGeneric<T>(String query, object parameter)
        {
            IList found = HibernateTemplate.Find(query,parameter);
            IList<T> result = new List<T>();
            foreach (object obj in found)
                result.Add((T)obj);
            return result;
        }
        protected IList<T> QueryNamedParams<T>(String query, String[] names, object[] values)
        {
            IList found = HibernateTemplate.FindByNamedParam(query, names, values);
            IList<T> result = new List<T>();
            foreach (object o in found)
                result.Add((T)o);
            return result;
        }
        public abstract IList<T> GetAll();
    }
}
