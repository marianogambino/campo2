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
        private const String LIST_USER_PAGE = "/Web/ListarUsuarios.aspx";
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
            LogIn("PabloDos", "Secret");
            Selenium.Open(LIST_USER_PAGE);
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertURL("http://localhost:1206/Web/Default.aspx?info=No%20posee%20los%20permisos%20necesarios");
        }
        [Test]
        public void GoodAccess()
        {
            LogIn("Pablo", "123");
            Selenium.Open(LIST_USER_PAGE);
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertURL("/Web/ListarUsuarios.aspx");
        }
    }
}
