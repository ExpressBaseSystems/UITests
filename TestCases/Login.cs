using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITests.DataDriven;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UITests.TestCases
{
    [TestFixture]
    public class Login: GetDataFromXml
    {
        private IWebDriver driver;
        ObjectRepository.Login l;
        string url = "https://myaccount.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver("D:\\Selenium\\Selenium\\bin\\Debug\\netcoreapp2.1");
            l = new ObjectRepository.Login(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCaseSource("LoginTestData")]
        public void ExecuteTest(KeyValuePair<string, string> login)
        {
                l.UserName.SendKeys(login.Key);
                Console.Write("username value is entered \n");
                l.Password.SendKeys(login.Value);
                Console.Write("password is entered");
                l.LoginButton.Click();
                Console.Write("\nlogin button is clicked");
            
            if (l.UNameCheckValidator.Text != null)
            {
                Console.WriteLine(l.UNameCheckValidator.Text);
            }
            else if(l.PasswordCheckValidator.Text != null)
            {
                Console.WriteLine(l.PasswordCheckValidator.Text);
            }
            else
            {
                Console.WriteLine("\nSUCCESS");
            }
              
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static Dictionary<string, string> LoginTestData()
        {
            return LoginTestValues();
        }
    }
}
