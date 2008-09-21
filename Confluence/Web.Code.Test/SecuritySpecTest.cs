using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
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
            user.Patentes.Add(new Patente(1)); //Test Page

            Assert.That(SecuritySpec.canAccessPage(user,Constants.PageNames.TEST));
            Assert.That(SecuritySpec.canAccessPage(user, "other"), Is.False); 

            //La patente 0 la tienen todos.
            //esto se puede llegar a eliminar
            Assert.That(SecuritySpec.canAccessPage(user,Constants.PageNames.HOME));
        }
        [NUnit.Framework.Test]
        public void isLoggedIn()
        {
            //User is logged in if != null
            User user = null;
            Assert.That(SecuritySpec.isLoggedIn(user), Is.False);
            user = new User();
            Assert.That(SecuritySpec.isLoggedIn(user), Is.True);
        }
    }
}
