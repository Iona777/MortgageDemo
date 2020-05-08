using SeleniumDomo_Mortgage.Utilities; //Location of Driver class
using TechTalk.SpecFlow;

namespace SeleniumDomo_Mortgage.Steps.Shared
{
    [Binding]
    public class WebHooks
    {
        [BeforeFeature()]
        public static void StartBrowser()
        {
            //Using appSettings.json for settings
            Driver.BaseUrl = Driver.GetBaseUrl();
            Driver.DefaultTimeout = Driver.GetTimeouSeconds();
            Driver.OpenBrowser(Driver.GetBrowser());
        }

        [AfterFeature()]
        public static void Shutdown()
        {
            Driver.Shutdown();
        }

    }
}
