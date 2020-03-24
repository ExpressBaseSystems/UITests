using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UITests.DataDriven;

namespace UITests.TestCases
{
    [TestFixture]
    public class Login : GetTenantFromXml
    {
        private IWebDriver driver;
        ObjectRepository.Login l;
        string url = "https://myaccount.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            l = new ObjectRepository.Login(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }


        [TestCaseSource("LoginTestData")]
        public void ExecuteTest(dynamic testdatas)
        {
            l.UserName.SendKeys(testdatas.username);
            Console.Write("username value is entered \n");
            l.Password.SendKeys(testdatas.password);
            Console.Write("password is entered");
            l.LoginButton.Click();
            Console.Write("\nlogin button is clicked");
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }


        private static List<EbTenantItem> LoginTestData()
        {
            return GetTenantValues();
        }
    }
}
