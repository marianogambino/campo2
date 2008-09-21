using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class LoginTest
    {
        private const String TXT_NAME = "ctl00_ContentPlaceHolder_txtName";
        private const String TXT_PASSWORD = "ctl00_ContentPlaceHolder_txtPass";
        private const String LOGIN_BUTTON = "ctl00_ContentPlaceHolder_submit";

        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "http://localhost:1745/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheNewTest()
        {
            selenium.Open("/Web/Default.aspx");
            selenium.Click("link=TO Login!!! :)");
            selenium.WaitForPageToLoad("30000");
            selenium.Click(LOGIN_BUTTON);
            try
            {
                Assert.IsTrue(selenium.IsTextPresent("Nombre es requerido"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(selenium.IsTextPresent("Password es requerido"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            selenium.Type(TXT_NAME, "algo");
            selenium.Click(LOGIN_BUTTON);
            try
            {
                Assert.IsTrue(selenium.IsTextPresent("Password es requerido"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            selenium.Type(TXT_PASSWORD, "nolga");
            selenium.Click(LOGIN_BUTTON);
            selenium.WaitForPageToLoad("30000");
        }
    }
}
