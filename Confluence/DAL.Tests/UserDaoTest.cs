using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;
using NUnit.Framework;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class UserDaoTest : AbstractTransactionalDbProviderSpringContextTests
    {
        public void NewUser()
        {

        }
        protected override string[] ConfigLocations
        {
            //Should Refer an assembly!!! :D (Nota: Se podrian sacar los conf del Website)
            //Y crear un nuevo proyecto (donde tambien pueden ir los helpers!) :) x 2 
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
