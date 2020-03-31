using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UITests.DataDriven;

namespace UITests.TestCases.Tenant
{
    [TestFixture]
    public class TenantLoginTestCase
    {
        private IWebDriver driver;
        ObjectRepository.Tenant.TenantLogin l;
        BrowserOps browserOps = new BrowserOps();
        string url = "https://myaccount.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            browserOps.Init_Browser();
        }
        
        [TestCaseSource("LoginTestData")]
        public void ExecuteTest(dynamic testdatas)
        {
            driver = browserOps.getDriver;
            l = new ObjectRepository.Tenant.TenantLogin(driver);
            browserOps.Goto(url);
            l.UserName.SendKeys(testdatas.username);
            Console.Write("username value is entered \n");
            l.Password.SendKeys(testdatas.password);
            Console.Write("password is entered");
            l.LoginButton.Click();
            Console.Write("\nlogin button is clicked\n");
            browserOps.implicitWait(10);

            if (string.Compare(driver.Url, testdatas.url) != 1)
            {
                Console.Write("“Test passed for Tenant Login Corrent UserName & Password ”");
            }
            else
            {
                String ExpectedTitle = l.TestResult.GetCssValue("background-color");
                Assert.AreEqual(testdatas.color, ExpectedTitle);
                Console.Write("“Test passed for Tenant Login InCorrent UserName & Password ”");
            }
        }

        [TearDown]
        public void EndTest()
        {
           // driver.Close();
        }

        private static List<EbTestItem> LoginTestData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\Tenant\TenantLogin.xml");
        }
    }
}
