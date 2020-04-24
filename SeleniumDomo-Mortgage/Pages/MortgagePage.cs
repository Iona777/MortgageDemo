using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumDomo_Mortgage.Utilities; //Location of Driver class


namespace SeleniumDomo_Mortgage.Pages
{
    public class MortgagePage : BasePage
    {
        string mortagePageURL = null;

        //Constructor - Not required. Inherits from BasePage

        //Elements
        private readonly By overviewLocator = By.ClassName("nav-main_second--active");
        private readonly By firstTimeBuyerLocator = By.ClassName("First time buyers");

        private readonly By locationDropdownLocator = By.Id("applicants_address");
        private readonly By numberOfApplicantsDropdownLocator = By.Id("applicants_number");
        private readonly By numberOfDependantsDropdownLocator = By.Id("dependants");

        private readonly By annualIncomeFieldLocator = By.Id("income1");
        private readonly By annualBonusFieldLocator = By.Id("bonus1");
        private readonly By monthlyDebtFieldLocator = By.Id("monthly_outgoings1");
        private readonly By calculateButtonLocator = By.Id("lnkButHowMuch");


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

                
        public void EnterHowMuchICanBorrowDetails(string location, string applicants, string dependants, string income, string bonus, string debt)
        {
            var locationDropdown = GetElementByLocator(locationDropdownLocator);
            var applicantsDropdown = GetElementByLocator(numberOfApplicantsDropdownLocator);
            var dependantsDropdown = GetElementByLocator(numberOfDependantsDropdownLocator);
            
            SelectDropDownOptionByValue(locationDropdown, location);
            SelectDropDownOptionByValue(applicantsDropdown, applicants);
            SelectDropDownOptionByValue(dependantsDropdown, dependants);

            EnterText(annualIncomeFieldLocator, income);
            EnterText(annualBonusFieldLocator, bonus);
            EnterText(monthlyDebtFieldLocator, debt);

            Driver.Pause(2000);

        }

        public void ClickCalculateButton()
        {
            ClickOnElement(calculateButtonLocator);
        }

    }     
}

