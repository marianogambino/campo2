using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public class FamilyDao : HibernateDaoSupport,IFamilyDao
    {
        #region CRUD
        public Family GetById(long id)
        {
            return  (Family) HibernateTemplate.Load(typeof(Family), id);
        }

        public void Persist(Family entity)
        {
            Family exists = GetByName(entity.Name);
            if (exists != null)
                throw new DuplicateEntityException(entity.Name);
            HibernateTemplate.Save(entity);
        }

        public void Delete(Family entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public void Update(Family entity)
        {
            HibernateTemplate.Update(entity);
        }

        public IList<Family> GetAll()
        {
            return (IList<Family>) HibernateTemplate.Find("FROM Family f");
        }
        #endregion
        public Family GetByName(string name)
        {
            IList families = (IList)HibernateTemplate.Find("FROM Family f WHERE f.Name = ?", name);

            Family family = null;

            if (families.Count > 0)
                family = (Family)families[0];

            return family;
        }
    }
}
