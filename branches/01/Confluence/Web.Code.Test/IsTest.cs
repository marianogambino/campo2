using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Web.Code.Helpers;

namespace Web.Code.Test
{
    [TestFixture]
    public class IsTest
    {
        [NUnit.Framework.Test]
        public void EmptyString()
        {
            Assert.IsTrue(Is.EmptyString(""));
            Assert.IsTrue(Is.EmptyString("        "));
            Assert.IsFalse(Is.EmptyString("algo hay!"));
        }
    }
}
