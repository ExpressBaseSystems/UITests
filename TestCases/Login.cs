using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.DataDriven;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UITests.TestCases
{
    [TestFixture]
    public class Login : GetDataFromXml
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
        public void ExecuteTest(dynamic testdata)
        {
            l.UserName.SendKeys(testdata.username);
            Console.Write("username value is entered \n");
            l.Password.SendKeys(testdata.password);
            Console.Write("password is entered");
            l.LoginButton.Click();
            Console.Write("\nlogin button is clicked");
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }


        private static List<EbTestItem> LoginTestData()
        {
            return GetTestValues();
        }
    }
}
