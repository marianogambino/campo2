using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Confluence.Domain.Tests
{
    [TestFixture]
    public class UserTest : EqualityTest<User>
    {
        [SetUp]
        public void SetUp()
        {
            Original = new User("Pablo", "pass1");
            Copy = new User("Pablo", "pass2");
            Different = new User("Paolo", "el rockero");
        }
    }
}
