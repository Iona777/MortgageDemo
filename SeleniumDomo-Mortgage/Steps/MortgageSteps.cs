using System;
using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using SeleniumDomo_Mortgage.Pages; //Location of page objects
using Microsoft.VisualStudio.TestTools.UnitTesting; //Need this for the Asserts
using TechTalk.SpecFlow;
using System.Threading;

namespace SeleniumDomo_Mortgage.Steps
{
    [Binding]
    public sealed class MortgageSteps
    {
        private readonly MortgagePage _theMortgagePage;
        private readonly string MortgageTitle = "Mortgages | Our best deals & rates | TSB Bank";
        
        //Constructor
        public MortgageSteps()
        {
            _theMortgagePage = new MortgagePage();
        }

        [Given(@"I have navigated to the mortgage page")]
        public void GivenIHaveNavigatedToTheMortgagePage()
        {
            _theMortgagePage.GotToMortgagePage();
            _theMortgagePage.CheckPageTitle(MortgageTitle);
            Driver.Pause(2000);   
        }

        [When(@"I select a mortgage reason of  ""(.*)""")]
        public void WhenISelectAMortgageReasonOf(string reasonText)
        {
            _theMortgagePage.ClickOnMortgageReason(reasonText);
        }

        [When(@"I enter ""(.*)"", ""(.*)"", ""(.*)"",""(.*)"", ""(.*)"" and ""(.*)"" in the how much can I borrow tab")]
        public void WhenIEnterAndInTheHowMuchCanIBorrowTab(string location, string applicants, string dependants, string income, string bonus, string debt)
        {
            _theMortgagePage.EnterHowMuchICanBorrowDetails(location, applicants, dependants, income, bonus, debt);
        }
        

    }
}
