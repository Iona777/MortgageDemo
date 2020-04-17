using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumDomo_Mortgage
{
    [TestClass]
    public class RunSettings
    {
        //The TestContext variables here are only relevant when run on server.
        //context is set by the framework itself. It is static so _testContext needs to 
        //be static too. testContext is passed to the non-static TestContext that cannot use static variables.
        //(Can't pass directly from context to TestContext it seems.)
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _testContext = context;
        }

        private static TestContext _testContext;

        public TestContext TestContext => _testContext;

        //The Test.Context.Propeties are set by TFS if tests run remotely on server.
        //If run locally, they will be null and the default value will be taken //instead.
        public string Browser => (TestContext.Properties["Browser"] ?? "Chrome").ToString();
        public string EnvironmentKey => (TestContext.Properties["EnvironmentKey"] ?? "QA").ToString();
        public string WebRoot => (TestContext.Properties["WebRoot"] ?? "https://www2.tsb.co.uk/mortgages/").ToString();
        
    }
}
