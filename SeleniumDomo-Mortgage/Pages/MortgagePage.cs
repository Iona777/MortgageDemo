using OpenQA.Selenium;
using SeleniumDomo_Mortgage.Utilities; //Location of Driver class


namespace SeleniumDomo_Mortgage.Pages
{
    public class MortgagePage : BasePage
    {
        string mortagePageURL = null;

        //Constructor - Not required. Inherits from BasePage

        //Element Locators
        private readonly By locationDropdownLocator = By.Id("applicants_address");
        private readonly By numberOfApplicantsDropdownLocator = By.Id("applicants_number");
        private readonly By numberOfDependantsDropdownLocator = By.Id("dependants");

        private readonly By annualIncomeFieldLocator = By.Id("income1");
        private readonly By annualBonusFieldLocator = By.Id("bonus1");
        private readonly By monthlyDebtFieldLocator = By.Id("monthly_outgoings1");
        private readonly By calculateHowMuchButtonLocator = By.Id("lnkButHowMuch");

        private readonly By findMortgageTabLocator = By.Id("findTab");

        private readonly By customerTypeDropdownLocator = By.Id("customer_type");
        private readonly By amountOfDepositFieldLocator = By.Id("deposit_size");
        private readonly By propertyValueFieldLocator = By.Id("property_value");
        private readonly By repaymentTermDropdownLocator = By.Id("repayment_term");
        private readonly By calculateFindButtonLocator = By.Id("lnkButFind");


        //Methods
        public void GotToMortgagePage()
        {
            mortagePageURL = Driver.BaseUrl;
            Driver.NavigateTo(mortagePageURL);
        }

        public void ClickOnMortgageReason(string reasonText)
        {
            GetElementByVisibleText(reasonText).Click();
        }
        public void ClickOnFindMortgageTab()
        {
            GetClickableElementByLocator(findMortgageTabLocator).Click();
        }

        public void EnterFindAMortgageDetails(string customerType, string deposit, string propertyValue, string term)
        {
            //Dropdown elements. SelectElement used for drodowns requires a WebElement
            var customerTypeDropdown = GetElementByLocator(customerTypeDropdownLocator);            
            var repaymentTermDropdown = GetElementByLocator(repaymentTermDropdownLocator);

            SelectDropDownOptionByValue(customerTypeDropdown, customerType);
            EnterText(amountOfDepositFieldLocator, deposit);
            EnterText(propertyValueFieldLocator, propertyValue);
            SelectDropDownOptionByValue(repaymentTermDropdown, term);

            //This is just here to let the user see the screen for this demo. Otherwise it is too fast too see.
            Driver.Pause(2000);
        }
                
        public void EnterHowMuchICanBorrowDetails(string location, string applicants, string dependants, string income, string bonus, string debt)
        {
            //Dropdown elements. SelectElement used for drodowns requires a WebElement
            var locationDropdown = GetElementByLocator(locationDropdownLocator);
            var applicantsDropdown = GetElementByLocator(numberOfApplicantsDropdownLocator);
            var dependantsDropdown = GetElementByLocator(numberOfDependantsDropdownLocator);
            
            SelectDropDownOptionByValue(locationDropdown, location);
            SelectDropDownOptionByValue(applicantsDropdown, applicants);
            SelectDropDownOptionByValue(dependantsDropdown, dependants);

            EnterText(annualIncomeFieldLocator, income);
            EnterText(annualBonusFieldLocator, bonus);
            EnterText(monthlyDebtFieldLocator, debt);

            //This is just here to let the user see the screen for this demo. Otherwise it is too fast too see.
            Driver.Pause(2000);
        }

        public void ClickCalculateHowMuchButton()
        {
            ClickOnElement(calculateHowMuchButtonLocator);
        }

        public void ClickCalculateFindButton()
        {
            ClickOnElement(calculateFindButtonLocator);
        }
    }     
}

