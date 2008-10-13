using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public class FamilyDao : BaseDao<Family>,IFamilyDao
    {
        public override IList<Family> GetAll()
        {
            return FindAllGeneric<Family>("From Family f");
        }

        public IList<Patente> GetAllPatents()
        {
            return FindAllGeneric<Patente>("From Patente p");
        }
    }
}
