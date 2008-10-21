using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using NHibernate;

namespace Confluence.DAL
{
    public class FamilyDao : BaseDao<Family>,IFamilyDao
    {
        public override IList<Family> GetAll()
        {
            return FindAllGeneric<Family>("From Family f Where f.Id > 2");
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
    }
}
