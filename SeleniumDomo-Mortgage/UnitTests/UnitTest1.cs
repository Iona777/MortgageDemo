using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumDomo_Mortgage.Utilities;

namespace SeleniumDomo_Mortgage.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //YOUR APPSETTOMGS.JSON FILE NEEDS TO BE SET TO COPY ALWAYS IN PROPERTIES

            var settings = ConfigHelper.GetConfig();
            

            Assert.IsNotNull(settings);
            //var setting1 = settings["TestSetting1"];

            var key = "Browser";
            

            Assert.AreEqual("Chrome", settings[key]);
            Assert.AreEqual("10", settings["DefaultTimeoutSeconds"]);
            Assert.AreEqual("https://www2.tsb.co.uk/mortgages/", settings["BaseUrl"]);



            //int a = Driver.GetTimeouSeconds();
            var time = settings["DefaultTimeoutSeconds"];
            int a = int.Parse(time);
            
            int b = 2; 
            int c = 3;
            int result = a + b + c;
            
            Assert.AreEqual(15,result);

        }
    }
}
