using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.DataDriven.Tenant;

namespace UITests.TestCases.Tenant
{
    [TestFixture]
    public class TenantSignupTestCase : TenantSignUp
    {
        private IWebDriver driver;
        ObjectRepository.Tenant.TenantSignUp l;
        string url = "https://myaccount.eb-test.cloud/";

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            l = new ObjectRepository.Tenant.TenantSignUp(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCaseSource("SignUpTestData")]
        public void ExecuteTest(dynamic testdatas)
        {
            l.SignUpButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string signupurl = driver.Url;
            Console.WriteLine(signupurl);
            l.Email.SendKeys(testdatas.email);
            l.Email.SendKeys(Keys.Tab);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            if (l.EmailError1.GetAttribute("style") == "visibility: visible;")
                Console.WriteLine("Error : " + l.EmailError1.GetAttribute("innerHTML"));
            else if (l.EmailError2.GetAttribute("style") == "visibility: visible; float: right;")
                Console.WriteLine("Error : " + l.EmailError2.GetAttribute("innerHTML"));
            else
            {
                Console.WriteLine("email entered \n");
                l.Password.SendKeys(testdatas.password);
                if (l.StrongPassword.GetAttribute("class") == "fa fa-check")
                    Console.WriteLine("password entered");
                else
                    Console.WriteLine("Enter Strong Password");
                l.Name.SendKeys(testdatas.name);
                if(l.NameCheck.GetAttribute("style")!= " visibility :hidden")
                    Console.WriteLine("Error : " + l.NameCheck.GetAttribute("innerHTML"));
                else
                    Console.Write("name entered");
                var selectElement = new SelectElement(l.Country);
                selectElement.SelectByValue(testdatas.country);
                Console.Write("country entered");
                l.JoinNow.Click();
                Console.Write("SignUp Join Now is clicked");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                if(signupurl != driver.Url)
                  Console.WriteLine("SignUp Success");
            }
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }
        
        private static List<EbTestItem> SignUpTestData()
        {
            return GetValueFromXml();
        }
    }
}
