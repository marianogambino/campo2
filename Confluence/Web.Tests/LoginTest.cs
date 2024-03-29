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
        private const String MENU = "menu";

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
            AssertIsTextPresent("Usuario y/o Contraseņa Incorrectos");
        }

        [Test]
        public void GoodLogin()
        {
            LogIn("Pablo", "123");

            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsTextPresent("Hola, Pablo.");
            AssertIsTextPresent("Salir");
        }

        [Test]
        public void RejectLogin()
        {
            Selenium.Open(LOGIN_URL);
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
            Selenium.Click("link=Salir");
            Selenium.WaitForPageToLoad(TIMEOUT);
            AssertIsElementAbsent("statbar");
        }
    }
}