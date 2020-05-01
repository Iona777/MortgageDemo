using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;


namespace SeleniumDomo_Mortgage.Utilities
{
    public static class Driver
    {
        public static IWebDriver TheDriver;
        
        //These values come from config file, set via WebHooks 
        public static string BaseUrl;
        public static int DefaultTimeout;


        public static void OpenBrowser(string selectedBrowser)
        {
            switch (selectedBrowser.ToUpper())
            {
                case "CHROME":
                    TheDriver = new ChromeDriver();
                    TheDriver.Manage().Window.Maximize();
                    break;
                case "IE":
                    TheDriver = new InternetExplorerDriver();
                    TheDriver.Manage().Window.Maximize();
                    break;
                default:
                break;
            }
        }


        public static void NavigateTo(string targetURL) 
        {
            TheDriver.Navigate().GoToUrl(targetURL);
        }


        /// <summary>
        /// Waits for specified  number of milliseconds. Used for debugging only
        /// </summary>
        /// <param name="time"></param>
        public static void Pause(int time)
        {
            Thread.Sleep(time);
        }


        public static string GetValueFromConfigKey(string key)
        {
            var settings = ConfigHelper.GetConfig();
            return settings[key];
        }

        public static int GetTimeouSeconds()
        {
            var time = GetValueFromConfigKey("DefaultTimeoutSeconds");
            return int.Parse(time);
        }

        public static string GetBrowser()
        {
            var browser = GetValueFromConfigKey("Browser");
            return browser;
        }

        public static string GetBaseUrl()
        {
            return GetValueFromConfigKey("BaseUrl");
        }

        public static void Shutdown()
        {
            TheDriver.Quit();
        }
    }
}
