using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;

using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SeleniumDomo_Mortgage.Utilities
{
    public static class Driver
    {
        public static IWebDriver TheDriver;
        
        //These values come from .runsettings file, set via WebHooks 
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


        public static void NavigateTo(string targetURL) //Maybe make this a URL type?
        {
            TheDriver.Navigate().GoToUrl(targetURL);
        }


        /// <summary>
        /// Waits for specified  number of milliseconds. USed for debugging only
        /// </summary>
        /// <param name="time"></param>
        public static void Pause(int time)
        {
            Thread.Sleep(time);
        }


        public static string GetValueFromConfigKey(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
            //Also tried this, neither work, get nulls. According to internet my App.config file must be in wrong place
            //but as far as I can see it is correct
            //return ConfigurationManager.AppSettings[key];
        }

        public static int GetTimeouSeconds()
        {
            var time = GetValueFromConfigKey("DefaultTimeoutSeconds");
            return int.Parse(time);
        }

        public static string GetBrowser()
        {
            //I know I could do this one line. Using 2 just so I can see what is returned more easily
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
