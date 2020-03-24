using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UITests.DataDriven;
using UITests.DataDriven.User;


namespace UITests.TestCases.User
{
    [TestFixture]
    public class UserLoginTestCase : UserLogin
    {
        private IWebDriver driver;
        ObjectRepository.User.UserLogin l;
        string url = "https://hairocraft.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            l = new ObjectRepository.User.UserLogin(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }


        [TestCaseSource("UserLoginData")]
        public void ExecuteTest(dynamic Userdata)
        {
            l.UserName.SendKeys(Userdata.username);
            Console.Write("username value is entered \n");
            l.Password.SendKeys(Userdata.password);
            Console.Write("password is entered");
            l.LoginButton.Click();
            Console.Write("\nlogin button is clicked");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (string.Compare(driver.Url, Userdata.url) != 1)
            {
                Console.Write("“Test passed for User Login Corrent UserName & Password ”");
            }
            else
            {
                String ExpectedTitle = l.TestResult.GetCssValue("background-color");
                Assert.AreEqual(Userdata.color, ExpectedTitle);
                Console.Write("“Test passed for User Login InCorrent UserName & Password ”");
            }           
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }


        private static List<EbTestItem> UserLoginData()
        {
            return GetValueFromXml();
        }
    }
}
