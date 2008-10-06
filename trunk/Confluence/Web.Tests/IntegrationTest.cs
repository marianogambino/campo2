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
        private const String URL = "http://localhost:3255";
        private const char SEPARATOR = '€';

        public const String LOGIN_URL = "/Web/Login.aspx";
        private const String LOGIN_NAME = "ctl00_ContentPlaceHolder_txtName";
        private const String LOGIN_PASSWORD = "ctl00_ContentPlaceHolder_txtPass";
        private const String LOGIN_BUTTON = "ctl00_ContentPlaceHolder_submit";

        protected const String TIMEOUT = "30000";

        protected ISelenium Selenium
        {
            get { return selenium; }
        }

        public void LogIn(String user, String pass)
        {
            Selenium.Open(LOGIN_URL);

            Selenium.Type(LOGIN_NAME, user);
            Selenium.Type(LOGIN_PASSWORD, pass);
            Selenium.Click(LOGIN_BUTTON);
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
                        Assert.IsTrue(false, err);
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
                Assert.IsTrue(selenium.IsTextPresent(text));
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
                Assert.IsTrue(selenium.IsElementPresent(locator));
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
                Assert.IsTrue(selenium.IsElementPresent(locator));
                AddError("Element: " + locator + " Should not be present on page " +selenium.GetLocation());
            }
            catch (AssertionException) {/*Everything OK*/}

        }
        protected void AssertURL(String url)
        {
            try
            {
                Assert.AreEqual(URL + url , Selenium.GetLocation());
            }
            catch (AssertionException)
            {
                AddError("URL must have been " + url + ", but was " + selenium.GetLocation());
            }
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
