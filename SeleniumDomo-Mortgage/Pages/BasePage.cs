using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions; //So that it knows to take expected condtions from here rather than deprecated OpenQA.Selenium

namespace SeleniumDomo_Mortgage.Pages
{
    public class BasePage
    {
        private IWebDriver BaseDriver;
        private int BaseTimeout;

        //Constructor
        public BasePage()
        {
            BaseDriver = Driver.TheDriver;
            BaseTimeout = Driver.DefaultTimeout;
        }

        //Methods
        public void CheckPageTitle(string expectedTitle)
        {
            WebDriverWait wait = new WebDriverWait(BaseDriver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.TitleIs(expectedTitle));
            }
            catch (Exception e)
            {
                throw new Exception($"Expected title " + expectedTitle + "  not found. " + BaseDriver.Title + "found instead" + e);
            }
        }


        /// <summary>
        /// Waits for, then retuns, a clickable element 
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Timeout for wait. Defaults to BaseTimeout which is ultimately set by App.config </param>
        /// <returns></returns>
        public IWebElement GetElementByLocator(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? BaseTimeout;
            WebDriverWait wait = new WebDriverWait(BaseDriver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        }


        /// <summary>
        /// Waits for, then retuns, a clickable element 
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Timeout for wait. Defaults to BaseTimeout which is ultimately set by App.config </param>
        /// <returns></returns>
        public IWebElement GetClickableElementByLocator(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? BaseTimeout;
            WebDriverWait wait = new WebDriverWait(BaseDriver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }



        /// <summary>
        /// Waits for, then retuns, a visible element 
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="waitSeconds">Timeout for wait. Defaults to BaseTimeout which is ultimately set by App.config </param>
        /// <returns></returns>
        public IWebElement GetVisibleElementByLocator(By elementLocator, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? BaseTimeout;
            WebDriverWait wait = new WebDriverWait(BaseDriver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator)); ;
        }


        /// <summary>
        /// Waits for, then returns, a visible element that contains the specified visible text
        /// </summary>
        /// <param name="searchText">Visible text used to locate the element</param>
        /// <param name="waitSeconds">Timeout for wait. Defaults to BaseTimeout which is ultimately set by App.config </param>
        /// <returns></returns>
        public IWebElement GetElementByVisibleText(string searchText, int? waitSeconds = null)
        {
            int seconds = waitSeconds ?? BaseTimeout;
            WebDriverWait wait = new WebDriverWait(BaseDriver, TimeSpan.FromSeconds(seconds));

            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[contains(text(),'" + searchText + "')]")));

        }

        /// <summary>
        /// Waits for an element to be clickable then clicks on it
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        public void ClickOnElement(By elementLocator)
        {
            GetClickableElementByLocator(elementLocator).Click();
        }

        /// <summary>
        /// Waits for an element to be clickable and enters the given value in it. Will also clear it if clear set to true
        /// </summary>
        /// <param name="elementLocator">Used to locate the element, e.g. By.Id("xyz")</param>
        /// <param name="value">Value to enter in element</param>
        /// <param name="clear">Clears element if set to true. Defaults to false</param>
        public void EnterText(By elementLocator, string value, bool? clear = false)
        {
            var element = GetClickableElementByLocator(elementLocator);
            if (clear == true)
                element.Clear();

            element.SendKeys(value);
        }

        public void  SelectDropDownOptionByValue(IWebElement dropDown, string value )
        {
            SelectElement select = new SelectElement(dropDown);
            select.SelectByValue(value);
        }
    }
}
