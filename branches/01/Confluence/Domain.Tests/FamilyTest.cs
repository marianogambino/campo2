using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class FamilyTest : EqualityTest<Family>
    {
        [SetUp]
        public void SetUp()
        {
            Original = new Family("Benvenutto","comen fideos");
            Copy = new Family("Benvenutto","comen pastas");
            Different = new Family("Adams","tiene a Largo (que es lo mas)");
        }

    }

}
