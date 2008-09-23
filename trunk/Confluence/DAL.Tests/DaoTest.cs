using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;

namespace Confluence.DAL.Tests
{
    public abstract class DaoTest : AbstractTransactionalDbProviderSpringContextTests
    {
        protected const String OBJECT_DELETED = "Spring.Data.NHibernate.HibernateObjectRetrievalFailureException";

        public abstract void Create();
        public abstract void Update();
        public abstract void Delete();

        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://Web.Code/Web.Code.Config/Data.xml" };
            }
        }
    }
}
