using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace Selenium
{
    public class Tests
    {
        private string _baseUrl;

        [SetUp]
        public void Setup()
        {
            var config = Utilities.InitConfiguration();

            _baseUrl = config.GetSection("RunSettings:BaseUrl").Value;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestGetStarted()
        {
            // Chrome Driver was manually downloaded from https://sites.google.com/a/chromium.org/chromedriver/downloads
            // parameter "." will instruct to look for the chromedriver.exe in the current folder
            using (var driver = new ChromeDriver())
            {
                //Navigate to DotNet website
                driver.Navigate().GoToUrl(_baseUrl);
                //Click the Get Started button
                driver.FindElement(By.LinkText("Get Started")).Click();

                // Get Started section is a multi-step wizard
                // The following sections will find the visible next step button until there's no next step button left
                IWebElement nextLink = null;
                do
                {
                    nextLink?.Click();
                    nextLink = driver.FindElements(By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) .step-select")).FirstOrDefault();
                } while (nextLink != null);

                // on the last step, grab the title of the step wich should be equal to "Next steps"
                var lastStepTitle = driver.FindElement(By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) h2")).Text;

                // verify the title is the expected value "Next steps"
                Assert.AreEqual(lastStepTitle, "Next steps");
            }
        }
    }
}