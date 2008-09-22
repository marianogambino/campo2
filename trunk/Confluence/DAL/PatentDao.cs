using System;
using System.Collections.Generic;
using System.Text;
using Spring.Data.NHibernate.Support;
using Confluence.Domain;
using System.Collections;

namespace Confluence.DAL
{
    public class PatentDao : HibernateDaoSupport, IPatentDao
    {
        public PatentDao() { }

        #region Crud
        public Patente GetById(long id)
        {
            return (Patente) HibernateTemplate.Get(typeof(Patente), id);
        }

        public void Persist(Patente entity)
        {
            HibernateTemplate.Save(entity);
        }

        public void Delete(Patente entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public void Update(Patente entity)
        {
            HibernateTemplate.Update(entity);
        }
        #endregion

    }
}
