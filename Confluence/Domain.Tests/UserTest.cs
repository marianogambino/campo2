using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void testEquality()
        {
            //Equality is based on User.Name

            User u1 = new User("Pablo", "pass1");
            User u2 = new User("Pablo", "pass2");
            User u3 = new User("Paolo", "el rockero");

            Assert.That(u1, Is.EqualTo(u2));
            Assert.That(u2, Is.EqualTo(u1));
            Assert.That(u1, Is.Not.EqualTo(u3));

            Assert.That(u1, Is.Not.EqualTo("This is not an User!"));
            Assert.That("Neither This!!", Is.Not.EqualTo(u1));
        }
    }
}
