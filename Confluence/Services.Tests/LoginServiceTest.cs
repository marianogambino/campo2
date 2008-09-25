using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;
using Confluence.Services;
using NUnit.Framework;

namespace Confluence.Services.Tests
{
    [TestFixture]
    public class LoginServiceTest : AbstractDependencyInjectionSpringContextTests
    {
        private LoginService loginService;
        public LoginService LoginService
        {
            set { loginService = value; }
            get { return loginService; }
        }

        [Test]
        public void doLogin()
        {
            Assert.IsNull(LoginService.doLogin("NotExistent", "WhoCares"));
            Assert.IsNotNull(LoginService.doLogin("Stub1", "pass1"));
        }

        protected override string[] ConfigLocations
        {
            get { return new String[] { "assembly://Web.Code/Web.Code.Config/StubData.xml",
                                        "assembly://Web.Code/Web.Code.Config/Services.xml"};
            }
        }
    }
}
