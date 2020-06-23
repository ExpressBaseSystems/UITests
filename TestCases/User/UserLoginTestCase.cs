using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class UserLoginTestCase : BaseClass
    {
        [Property("TestCaseId", "User_Login_001")]
        [TestCaseSource("UserLoginData"), Order(1)]
        public void ExecuteTest(dynamic Userdata)
        {
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ul.UserName.SendKeys(Userdata.username);
            Console.Write("username value is entered \n");
            ul.Password.SendKeys(Userdata.password);
            Console.Write("password is entered");
            ul.LoginButton.Click();
            Console.Write("\nlogin button is clicked");
            browserOps.implicitWait(10);
            if (string.Compare(driver.Url, Userdata.url) != 1)
            {
                Console.Write("“Test passed for User Login Corrent UserName & Password ”");
            }
            else
            {
                String ExpectedColor = ul.MessageBox.GetCssValue("background-color");
                Assert.AreEqual(Userdata.color, ExpectedColor);
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
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\UserLoginTestCase.xml");
        }
    }
}
