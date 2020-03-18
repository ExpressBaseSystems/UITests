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
        string url = "https://hairocraft.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            //driver = new ChromeDriver("D:\\Selenium\\Selenium\\bin\\Debug\\netcoreapp2.1");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            l = new ObjectRepository.Login(driver);
            driver.Manage().Window.Maximize();           
        }

        [TestCaseSource("LoginTestData")]
        public void ExecuteTest(dynamic testdata)
        {
            driver.Navigate().GoToUrl(url);
            l.UserName.SendKeys(testdata.user);
            Console.Write("username value is entered \n");
            l.Password.SendKeys(testdata.pass);
            Console.Write("password is entered");
            l.LoginButton.Click();
            Console.Write("\nlogin button is clicked");

            if (l.UNameCheckValidator.Text != null)
            {
                Console.WriteLine(l.UNameCheckValidator.Text);
            }
            else if (l.PasswordCheckValidator.Text != null)
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

        private static IEnumerable<object[]> LoginTestData()
        {
            var dict = LoginTestValues(@"E:\Expressbase.Core\UITests\TestData\LoginData.xml", "test1");
            return new[] { new object[] { dict } };
        }
    }
}
