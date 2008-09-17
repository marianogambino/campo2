using System;
using System.Collections.Generic;
using System.Text;
using Selenium;
using NUnit.Framework;

namespace Web.Tests
{
        [TestFixture]
        public class NewTest
        {
            private ISelenium selenium;
            private StringBuilder verificationErrors;

            [SetUp]
            public void SetupTest()
            {
                selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "http://localhost:1745/Web/");
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
            }

            [Test]
            public void TheNewTest()
            {
                selenium.Open("/Default.aspx");
                try
                {
                    Assert.IsTrue(selenium.IsTextPresent("Confluence"));
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
            }
        }
    }

