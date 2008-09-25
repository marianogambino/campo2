using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Confluence.Domain;

namespace Web.Code.Test
{
    [TestFixture]
    public class SecuritySpecTest
    {
        [NUnit.Framework.Test]
        public void canAccessPage()
        {
            User user = new User();
            user.Patentes.Add(new Patente(1,"Google","www.google.com")); //Test Page

            Assert.IsTrue(SecuritySpec.canAccessPage(user,Constants.PageNames.TEST));
            Assert.IsFalse(SecuritySpec.canAccessPage(user, "other")); 

            //La patente 0 la tienen todos.
            //esto se puede llegar a eliminar
            Assert.IsTrue(SecuritySpec.canAccessPage(user,Constants.PageNames.HOME));
        }
        [NUnit.Framework.Test]
        public void isLoggedIn()
        {
            //User is logged in if != null
            User user = null;
            Assert.IsFalse(SecuritySpec.isLoggedIn(user));
            user = new User();
            Assert.IsTrue(SecuritySpec.isLoggedIn(user));
        }
    }
}
