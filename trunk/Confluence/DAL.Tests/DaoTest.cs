using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;

namespace Confluence.DAL.Tests
{
    public abstract class DaoTest : AbstractTransactionalDbProviderSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] { "assembly://Web.Code/Web.Code.Config/Data.xml" };
            }
        }
    }
}
