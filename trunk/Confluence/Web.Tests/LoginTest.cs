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
        }

        [Test]
        public void BadLogin()
        {
            LogIn("Falso", "User");

            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsTextPresent("Usuario y/o Contraseña Incorrectos");
        }

        [Test]
        public void GoodLogin()
        {
            LogIn("Pablo", "secreto");

            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsTextPresent("Hello,Pablo");
            AssertIsTextPresent("Logout");
        }

        [Test]
        public void RejectLogin()
        {
            Selenium.Open(TEST_URL);
            LogIn("Primer", "Intento");
            LogIn("Segundo", "Intento");
            LogIn("Tercer", "Intento");
            Selenium.WaitForPageToLoad(TIMEOUT);

            AssertIsTextPresent("Ha alcanzado el maximo de intentos fallidos");
        }
        [Test]
        public void TestRejectLoginReset()
        {
            //Debe Borrar la variable cada 3 intentos
            RejectLogin();
            RejectLogin();
            RejectLogin();
        }

        [Test]
        public void TestIsPresentAccordionMenu()
        {
            GoodLogin();
            AssertIsElementPresent("accordion");
        }

        [Test]
        public void LogOut()
        {
            GoodLogin();
            Selenium.Click("link=Logout");
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsElementAbsent("statbar");
        }

        public void LogIn(String User, String Pass)
        {
            Selenium.Open(TEST_URL);

            Selenium.Type(TXT_NAME, User);
            Selenium.Type(TXT_PASSWORD, Pass);
            Selenium.Click(LOGIN_BUTTON);
        }
    }
}