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
        public void ExecuteTest(KeyValuePair<string, List<EbTestData>> testdata)
        {
            if (testdata.Key == "test1")
            {
                l.UserName.SendKeys(testdata.Value[0].Value);
                Console.Write("username value is entered \n");
                l.Password.SendKeys(testdata.Value[1].Value);
                Console.Write("password is entered");
                l.LoginButton.Click();
                Console.Write("\nlogin button is clicked");
            }
            else if (testdata.Key == "test2")
            {
                l.UserName.SendKeys(testdata.Value[0].Value);
                Console.Write("username value is entered \n");
                l.Password.SendKeys(testdata.Value[1].Value);
                Console.Write("password is entered");
                l.LoginButton.Click();
                Console.Write("\nlogin button is clicked");
                l.SkipTour.Click();
                l.NewSolutionButton.Click();
                l.ApplicationName.SendKeys(testdata.Value[2].Value);
                l.ApplicationDescription.SendKeys(testdata.Value[3].Value);
                l.ApplicationIcon.SendKeys(testdata.Value[4].Value);
            }

            //if (l.UNameCheckValidator.Text != null)
            //{
            //    Console.WriteLine(l.UNameCheckValidator.Text);
            //}
            //else if (l.PasswordCheckValidator.Text != null)
            //{
            //    Console.WriteLine(l.PasswordCheckValidator.Text);
            //}
            //else
            //{
            //    Console.WriteLine("\nSUCCESS");
            //}

        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static Dictionary<string, List<EbTestData>> LoginTestData()
        {
            return GetTestValues();
        }
    }
}
