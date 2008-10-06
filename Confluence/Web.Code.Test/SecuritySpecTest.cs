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
            Assert.IsFalse(SecuritySpec.canAccessPage(user, Constants.PageNames.LIST_USERS)); 

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

        [NUnit.Framework.Test]
        public void canAccessPageWithFamily()
        {
            User user = new User();
            Family fam = new Family("familiy", "one");
            fam.Patentes.Add(new Patente(101,"admin","www.adminUsers.com"));
            user.Families.Add(fam);
            Assert.IsTrue(SecuritySpec.canAccessPage(user, Constants.PageNames.LIST_USERS));
            Assert.IsTrue(SecuritySpec.canAccessPage(user, Constants.PageNames.HOME));
            Assert.IsFalse(SecuritySpec.canAccessPage(user, Constants.PageNames.TEST));
        }
    }
}
