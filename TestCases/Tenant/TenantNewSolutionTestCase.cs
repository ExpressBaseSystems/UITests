using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.Tenant;

namespace UITests.TestCases.Tenant
{
    [TestFixture]
    public class TenantNewSolutionTestCase 
    {
        private IWebDriver driver;
        TenantLogin tl;
        TenantNewSolution l;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if(driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                tl = new TenantLogin(driver);
                l = new TenantNewSolution(driver);
            }
        }

        [TestCaseSource("Login"), Order(1)]
        public void TenantLogin(dynamic data)
        {
            browserOps.Goto("https://myaccount.eb-test.cloud/");
            tl.UserName.SendKeys(data.username);
            tl.Password.SendKeys(data.password);
            tl.LoginButton.Click();
            browserOps.implicitWait(200);
        }

        [Test, Order(2)]
        public void CreateNewSolution()
        {
            browserOps.implicitWait(200);
            l.SkipLink.Click();
            browserOps.implicitWait(200);
            l.NewSolutionButton.Click();
            browserOps.implicitWait(200);
            l.MessagePopUpClose.Click();
            Console.Write("New Solution Created");
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> Login()
        {
            return GetDataFromXML.GetDataFromFile(@"TestData\Tenant\TenantLoginData.xml");
        }

    }
}
