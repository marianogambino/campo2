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
        private const String URL = "http://localhost:3255/";
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
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception) { }
            if (ErrorsExist())
            {
                try
                {
                    foreach (String err in verificationErrors.ToString().Split(SEPARATOR))
                    {
                        Assert.That(false, err);
                    }
                }
                catch (AssertionException e) { throw e; }
                finally
                {
                    verificationErrors = new StringBuilder();
                }
            }
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
        

        private void AddError(String message)
        {
            if (verificationErrors == null) 
                verificationErrors = new StringBuilder();
            verificationErrors.Append(message + SEPARATOR);
        }
        private bool ErrorsExist()
        {
            return (verificationErrors != null && verificationErrors.Length > 0);
        }
        #endregion
    }
}
