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
        private const char SEPARATOR = '€';

        protected const String TIMEOUT = "30000";

        protected ISelenium Selenium
        {
            get { return selenium; }
        }

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium(SERVER, PORT, BROWSER, URL);
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
            catch (Exception) { }
            if (verificationErrors.ToString().Length > 0)
            {
                foreach (String err in verificationErrors.ToString().Split(SEPARATOR))
                {
                    Assert.That(false,err);
                }
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        #region Custom Asserts
        protected void AssertIsTextPresent(String text)
        {
            try
            {
                Assert.That(selenium.IsTextPresent(text));
            }
            catch (AssertionException)
            {
                AddError("Text: '" + text + "' is not present on page " + selenium.GetLocation());
            }
        }
        protected void AssertIsElementPresent(String locator)
        {
            try
            {
                Assert.That(selenium.IsElementPresent(locator));
            }
            catch (AssertionException)
            {
                AddError("Element: " + locator + " is not present on page " + selenium.GetLocation());
            }
        }
        protected void AssertIsElementAbsent(String locator)
        {
            try
            {
                Assert.That(selenium.IsElementPresent(locator));
                AddError("Element: " + locator + " Should not be present on page " +selenium.GetLocation());
            }
            catch (AssertionException) {/*Everything OK*/}

        }
        #endregion

        private void AddError(String message)
        {
            verificationErrors.Append(message + SEPARATOR);
        }
    }
}
