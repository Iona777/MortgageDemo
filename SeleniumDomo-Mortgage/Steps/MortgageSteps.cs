using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using SeleniumDomo_Mortgage.Pages; //Location of page objects
using Microsoft.VisualStudio.TestTools.UnitTesting; //Need this for the Asserts
using TechTalk.SpecFlow; //Need this for the BDD

namespace SeleniumDomo_Mortgage.Steps
{
    [Binding]
    public sealed class MortgageSteps
    {
        //Declare your page objects
        private readonly MortgagePage _theMortgagePage;
        private readonly MortgageCalcResultPage _theMortgageCalcResultPage;
        private readonly FindMortgageCalcResultPage _theFindMortgageCalcResultsPage;
        private readonly string MortgageTitle = "Mortgages | Our best deals & rates | TSB Bank";
        
        //Constructor
        public MortgageSteps()
        {
            //Instantiate your page objects
            _theMortgagePage = new MortgagePage();
            _theMortgageCalcResultPage = new MortgageCalcResultPage();
            _theFindMortgageCalcResultsPage = new FindMortgageCalcResultPage();
        }

        [Given(@"I have navigated to the mortgage page")]
        public void GivenIHaveNavigatedToTheMortgagePage()
        {
            _theMortgagePage.GotToMortgagePage();
            _theMortgagePage.CheckPageTitle(MortgageTitle);
            //This is just here so user can see what is happening in this demo, otherwise it is too fast too see. 
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
            _theMortgagePage.ClickCalculateHowMuchButton();
            //This is just here so user can see what is happening in this demo, otherwise it is too fast too see. 
            Driver.Pause(2000); 
        }

        [Then(@"the offer amount should be ""(.*)""")]
        public void ThenTheOfferAmountShouldBe(string expectedAmount)
        {
            Assert.IsTrue(_theMortgageCalcResultPage.CheckOfferAmount(expectedAmount),"Check Offer returned false");
            //This is just here so user can see what is happening in this demo, otherwise it is too fast too see. 
            Driver.Pause(2000);
        }

        [When(@"I click on the Find a Mortgage tab")]
        public void WhenIClickOnTheFindAMortgageTab()
        {
            _theMortgagePage.ClickOnFindMortgageTab();

        }

        [When(@"I enter ""(.*)"", ""(.*)"",""(.*)"", and ""(.*)"" in the find a mortgage tab")]
        public void WhenIEnterAndInTheFindAMortgageTab(string customerType, string deposit, string propertyValue, string term)
        {
            _theMortgagePage.EnterFindAMortgageDetails(customerType, deposit, propertyValue, term);
        }

        [When(@"I click on the calculate find a mortgage button")]
        public void WhenIClickOnTheCalculateFindAMortgageButton()
        {
            _theMortgagePage.ClickCalculateFindButton();
            //This is just here so user can see what is happening in this demo, otherwise it is too fast too see. 
            Driver.Pause(2000);
        }

        [Then(@"The number of products is greater than zero")]
        public void ThenTheNumberOfProductsIsGreatedThanZer()
        {
            Assert.IsTrue(_theFindMortgageCalcResultsPage.GetNumberOfProducts() > 0, "Expected number of products to be greater than zero");
            
        }

    }
}
