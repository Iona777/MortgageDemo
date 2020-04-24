using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SeleniumDomo_Mortgage.Pages
{
    public class MortgageCalcResultPage: BasePage
    {
        //Constructor - not requuired, inherited from BasePage

        //WebElements
        private readonly By offerAmountLocator = By.ClassName("borrow-result");


        //Methods
        public string getOfferAmount()
        {
            var text = GetVisibleElementByLocator(offerAmountLocator).Text;
            text = text.Replace("£","");

            return text;
        }
    }
}
