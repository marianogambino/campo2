using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace Web.Tests
{
    [TestFixture]
    public class LoginTest : IntegrationTest
    {
        private const String TXT_NAME = "ctl00_ContentPlaceHolder_txtName";
        private const String TXT_PASSWORD = "ctl00_ContentPlaceHolder_txtPass";
        private const String LOGIN_BUTTON = "ctl00_ContentPlaceHolder_submit";
        private const String MENU = "menu";
        private const String TEST_URL = "/Web/Login.aspx";

        [Test]
        public void EmptyLogin()
        {
            LogIn("", "");

            AssertIsTextPresent("Nombre es requerido");
            AssertIsTextPresent("Password es requerido");
            AssertIsElementAbsent(MENU);
        }

        [Test]
        public void BadLogin()
        {
            LogIn("Falso", "User");

            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsTextPresent("Usuario y/o Contraseña Incorrectos");
            AssertIsElementAbsent(MENU);
        }

        [Test]
        public void GoodLogin()
        {
            LogIn("Pablo", "Secreto");

            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsElementPresent(MENU);
            AssertIsTextPresent("Helooou Everybod");
        }

        public void LogIn(String User, String Pass)
        {
            Selenium.Open(TEST_URL);
            Selenium.Click(LOGIN_BUTTON);

            Selenium.Type(TXT_NAME, User);
            Selenium.Type(TXT_PASSWORD, Pass);
            Selenium.Click(LOGIN_BUTTON);
          
        }

        ////TODO:[Test]
        //public void RejectLogin()
        //{
        //    Selenium.Open(TEST_URL);
        //    Selenium.Click

        //}
    }
}