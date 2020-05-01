using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using TechTalk.SpecFlow;

namespace SeleniumDomo_Mortgage.Steps.Shared
{
    [Binding]
    public class WebHooks
    {
        //public static RunSettings _runSettings = new RunSettings();

        [BeforeFeature()]
        public static void StartBrowser()
        {
            //Less simple versions that do not work
            //Runsettigns version
            //Driver.BaseUrl = _runSettings.WebRoot;
            //Driver.OpenBrowser(_runSettings.Browser);

            //Here are errors when running: 
            //[MSTest][Discovery][C:\Users\gregm\source\repos\SeleniumDomo-Mortgage\SeleniumDomo-Mortgage\bin\Debug\netcoreapp3.1\SeleniumDomo-Mortgage.dll] UTA001: TestClass attribute defined on non-public class SeleniumDomo_Mortgage_MSTestAssemblyHooks
            //[MSTest] [Discovery] [C: \Users\gregm\source\repos\SeleniumDomo-Mortgage\SeleniumDomo-Mortgage\bin\Debug\netcoreapp3.1\SeleniumDomo-Mortgage.dll] UTA031: class SeleniumDomo_Mortgage.RunSettings does not have valid TestContext property.TestContext must be of type TestContext, must be non-static, public and must not be read-only.For example: public TestContext TestContext.

            //I do have non-static public TestContext. On line 23 of Runsettings.cs.cs is this:
            //public TestContext TestContext => _testContext;

            //When I try to dubug, I get this error message:
            // Message: 
            //UTA013: SeleniumDomo_Mortgage_MSTestAssemblyHooks: Cannot define more than one method with the AssemblyInitialize attribute inside an assembly.
            // As far as I can see, I only have the AssemblyInit() method here.


            //App.config version
            Driver.BaseUrl = Driver.GetBaseUrl();
            Driver.DefaultTimeout = Driver.GetTimeouSeconds();
            Driver.OpenBrowser(Driver.GetBrowser());

            //Using App.config I get this error
            //Class Initialization method SeleniumDomo_Mortgage.Features.MortgageFeature.FeatureSetup threw exception.System.NullReferenceException: System.NullReferenceException: Object reference not set to an instance of an object..Stack Trace:
            //Driver.OpenBrowser(String selectedBrowser) line 25
            //WebHooks.StartBrowser() line 38


            //Simple version that works
        //    Driver.BaseUrl = "https://www2.tsb.co.uk/mortgages/";
         //   Driver.DefaultTimeout = 10;
          //  Driver.OpenBrowser("chrome");


        }

        [AfterFeature()]
        public static void Shutdown()
        {
            Driver.Shutdown();
        }

    }
}
