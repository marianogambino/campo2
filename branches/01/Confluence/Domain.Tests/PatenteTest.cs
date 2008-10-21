using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class PatenteTest : EqualityTest<Patente>
    {
        [SetUp]
        public void SetUp()
        {
            Original = new Patente(0, "Nombre", "Pathio");
            Copy = new Patente(0, "Nombresss", "Pathioss");
            Different = new Patente(1, "Nombres", "Pathio2");
        }
 
    }
}
