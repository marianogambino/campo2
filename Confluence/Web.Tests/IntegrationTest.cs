using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace Web.Tests
{
    public abstract class IntegrationTest
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        private const String SERVER = "localhost";
        private const int PORT = 4444;
        private const String BROWSER = "*iexplore";
        private const String URL = "http://localhost:1745/";

        protected const String TIMEOUT = "30000";

        protected ISelenium Selenium
        {
            get { return selenium; }
        }

        [TestFixtureSetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium(SERVER, PORT, BROWSER, URL);
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TestFixtureTearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception) { }
            
            Assert.AreEqual("", verificationErrors.ToString());
        }

        #region Custom Asserts
        protected void AssertIsTextPresent(String text)
        {
            try
            {
                Assert.That(selenium.IsTextPresent(text));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        protected void AssertIsElementPresent(String locator)
        {
            try
            {
                Assert.That(selenium.IsElementPresent(locator));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        protected void AssertIsElementAbsent(String locator)
        {
            try
            {
                Assert.That(selenium.IsElementPresent(locator));
                verificationErrors.Append("Element: " + locator + " Should not be present");
            }
            catch (AssertionException) {/*Everything OK*/}

        }
        #endregion

    }
}
