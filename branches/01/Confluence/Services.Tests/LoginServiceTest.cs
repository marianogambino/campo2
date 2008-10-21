using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;
using Confluence.Services;
using NUnit.Framework;

namespace Confluence.Services.Tests
{
    [TestFixture]
    public class LoginServiceTest : ServiceTest
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
    }
}
