using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UITests.ObjectRepository.User;

namespace UITests.DataDriven
{
    [TestFixture]
    public class BaseClass
    {
        public IWebDriver driver;
        public UserLogin ul;
        public BrowserOps browserOps = new BrowserOps();
        public GetUniqueId id = new GetUniqueId();
        public WebDriverWait wait;
        public WebElementOps elementOps;
        public Actions actions;
        public bool login_status;

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                actions = new Actions(driver);
                login_status = CheckLogin();
            }
            wait = browserOps.DriverWait();
            elementOps = new WebElementOps(driver, wait);
        }

        public bool CheckLogin()
        {
            if (driver.Url == "data:,")
                return false;
            return true;
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
            var testCaseId = TestContext.CurrentContext.Test.Properties["TestCaseId"];
            var tid = string.Empty;
            foreach (var testId in testCaseId)
            {
                tid = testId.ToString();
            }
            if (tid != null)
                Console.WriteLine("Testcase ID   : " + tid);
        }
    }
}
