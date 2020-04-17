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
        private readonly By annualIncomeDropdownLocator = By.Id("income1");
        private readonly By annualBonusDropdownLocator = By.Id("bonus1");
        private readonly By monthlyDebtDropdownLocator = By.Id("monthly_outgoings1");
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


        //Cannot find elements. I think I need to switch frame first
        public void EnterHowMuchICanBorrowDetails(string location, string applicants, string dependants, string income, string bonus, string debt)
        {
            var locationDropdown = GetClickableElementByLocator(locationDropdownLocator);
            var applicantsDropdown = GetClickableElementByLocator(numberOfApplicantsDropdownLocator);
            var dependantsDropdown = GetClickableElementByLocator(numberOfDependantsDropdownLocator);
            var incomeDropdown = GetClickableElementByLocator(annualIncomeDropdownLocator);
            var bonusDropdown = GetClickableElementByLocator(annualBonusDropdownLocator);
            var debtDropdown = GetClickableElementByLocator(monthlyDebtDropdownLocator);

            SelectDropDownOptionByValue(locationDropdown, location);
            SelectDropDownOptionByValue(applicantsDropdown, applicants);
            SelectDropDownOptionByValue(dependantsDropdown, dependants);
            SelectDropDownOptionByValue(incomeDropdown, income);
            SelectDropDownOptionByValue(bonusDropdown, bonus);
            SelectDropDownOptionByValue(debtDropdown, debt);

        }
    }     
}

