using OpenQA.Selenium;

namespace SeleniumDomo_Mortgage.Pages
{
    public class MortgageCalcResultPage: BasePage
    {
        //Constructor - not requuired, inherited from BasePage

        //WebElement Locators
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
