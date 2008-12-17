using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using NHibernate;
using System.Data.Common;

namespace Confluence.DAL
{
    public class FamilyDao : BaseDao<Family>,IFamilyDao
    {
        private ConnectionFactory factory = ConnectionFactory.GetProductionFactory();
        public override IList<Family> GetAll()
        {
            return FindAllGeneric<Family>("From Family f Where f.Id > 2");
        }
        public IList<Family> GetAllForAssign()
        {
            return FindAllGeneric<Family>("From Family f");
        }

        public IList<Patente> GetAllPatents()
        {
            return FindAllGeneric<Patente>("From Patente p");
        }
        public Family GetByName(String name)
        {
            IList<Family> fams =  QueryGeneric<Family>("From Family f Where f.Name = ?", name);
            return (fams.Count > 0) ? (Family)fams[0] : null;
        }

        public override void Delete(Family entity)
        {
            HibernateTemplate.Delete(entity);
            factory.UseCommand(delegate(DbCommand cmd)
            {
                cmd.CommandText = "Delete from family_patente where family_id = " + entity.Id;
                cmd.ExecuteNonQuery();
            });
        }
    }
}
