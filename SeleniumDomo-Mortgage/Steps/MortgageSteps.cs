using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using SeleniumDomo_Mortgage.Pages; //Location of page objects
using Microsoft.VisualStudio.TestTools.UnitTesting; //Need this for the Asserts
using TechTalk.SpecFlow;

namespace SeleniumDomo_Mortgage.Steps
{
    [Binding]
    public sealed class MortgageSteps
    {
        private readonly MortgagePage _theMortgagePage;
        private readonly MortgageCalcResultPage _theMortgageCaclResultPage;
        private readonly string MortgageTitle = "Mortgages | Our best deals & rates | TSB Bank";
        
        //Constructor
        public MortgageSteps()
        {
            _theMortgagePage = new MortgagePage();
            _theMortgageCaclResultPage = new MortgageCalcResultPage();
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

        [When(@"I click on calculate how much I can borrow button")]
        public void WhenIClickOnCalculateHowMuchICanBorrowButton()
        {
            _theMortgagePage.ClickCalculateButton();
            Driver.Pause(2000); //So uiser can see what is happening
        }

        [Then(@"the offer amount should be ""(.*)""")]
        public void ThenTheOfferAmountShouldBe(string expectedAmount)
        {
            var actualAmount = _theMortgageCaclResultPage.getOfferAmount();
            Assert.AreEqual(expectedAmount, actualAmount);
        }

    }
}
