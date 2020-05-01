using OpenQA.Selenium;

namespace SeleniumDomo_Mortgage.Pages
{
    public class FindMortgageCalcResultPage: BasePage
    {
        //Constructor - not required as inherits from BasePage

        //Element Locators
        private readonly By numberOfProductsLocator = By.ClassName("no-products");

        //Methods
        public int GetNumberOfProducts()
        {
            string noOfproductsText = GetVisibleElementByLocator(numberOfProductsLocator).Text;
            int noOfProducts;
            int.TryParse(noOfproductsText, out noOfProducts);
            return noOfProducts;
        }
    }
}
