using OpenQA.Selenium;
using SeleniumDomo_Mortgage.Utilities;

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
            int noOfProducts = getProducts();

            //Sometimes it will display briefly as zero before filling in the required amount
            for (int index = 0; index < 10; index++)
            {
                if (noOfProducts == 0)
                {
                    Driver.Pause(1000);
                    noOfProducts = getProducts();
                }
            }

            return noOfProducts;
        }

        private int getProducts()
        {
            string noProductsText = GetVisibleElementByLocator(numberOfProductsLocator).Text;
            return int.Parse(noProductsText);
        }

    }
}
