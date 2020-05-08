using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumDomo_Mortgage.Utilities;
using System;

namespace SeleniumDomo_Mortgage.Pages
{
    public class MortgageCalcResultPage: BasePage
    {
        //Constructor - not requuired, inherited from BasePage

        //WebElement Locators
        private readonly By offerAmountLocator = By.ClassName("borrow-result");


        //Methods
        public bool CheckOfferAmount(string expectedAmount)
        {
            string text = getOfferAmount();
            for (int index = 0; index < 10; index++)
            {
                //Sometimes it will display briefly as zero before filling in the required amount
                try
                {
                    Assert.AreEqual(expectedAmount, text);
                    break;
                }
                catch (Exception e)
                {
                    Driver.Pause(1000);
                    text = getOfferAmount();
                }
            }

            return (text.Equals(expectedAmount));

        }


        public string getOfferAmount()
        {
            var text = GetVisibleElementByLocator(offerAmountLocator).Text;
            text = text.Replace("£","");

            return text;
        }
    }
}
