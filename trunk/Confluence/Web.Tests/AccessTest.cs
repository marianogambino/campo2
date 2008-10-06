using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace Web.Tests
{
    [TestFixture]
    public class AccessTest : IntegrationTest
    {
        private const String LIST_USER_PAGE = "/Web/ListUsers.aspx";
        [Test]
        public void UnloggedUserToLogin()
        {
            Selenium.Open(LIST_USER_PAGE);
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertURL(LOGIN_URL + "?invalid=true");
        }
        [Test]
        public void UserWithoutPatents()
        {
            LogIn("not", "admin");
            Selenium.Open(LIST_USER_PAGE);
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertURL("/Web/Default.aspx");
        }
        [Test]
        public void GoodAccess()
        {
            LogIn("Pablo", "secreto");
            Selenium.Open(LIST_USER_PAGE);
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertURL("/Web/ListUsers.aspx");
        }
    }
}
