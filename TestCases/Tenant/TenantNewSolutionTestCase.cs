using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven.Tenant;

namespace UITests.TestCases.Tenant
{
    [TestFixture]
    public class TenantNewSolutionTestCase : TenantNewSolution
    {
        private IWebDriver driver;
        ObjectRepository.Tenant.TenantNewSolution l;
        string url = "https://myaccount.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            l = new ObjectRepository.Tenant.TenantNewSolution(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

    }
}
