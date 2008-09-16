using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Confluence.Services.Tests
{
    [TestFixture]
    [Category("Demo")]
    public class DemoTest : AssertionHelper
    {
        int max;
        int min;
        Object nullObject;

        [SetUp]
        public void setUp()
        {
            max = 10;
            min = 1;
            nullObject = null;
        }
        [Test]
        public void theTruth()
        {
            Expect(true,Is.True,"True Should be True");
        }

        [Test]
        public void theNull()
        {
            Expect(null,Is.Null,"Null must be null");
        }

        [Test]
        public void testMaxAndMin()
        {
            Expect(max,Is.GreaterThan(min));
            Expect(min, Is.LessThan(max));
            Expect(min,Is.EqualTo(1));
            Expect(max,Is.EqualTo(10));
            Expect(min, Is.GreaterThan(0) & Is.LessThan(max));
        }

        [Test] [ExpectedException(typeof(NullReferenceException))]
        public void testExceptional()
        {
            Expect(nullObject.Equals(null),Is.True);
            Assert.Fail("Null pointer should be thrown in the previous line");
        }
    }
}
