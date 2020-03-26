using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class UserGroupTestCase
    {
        IWebDriver driver;
        UserLogin ul;
        UserGroupObject ug;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                ug = new UserGroupObject(driver);
            }
        }

        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("hairocraft123@gmail.com");
            ul.Password.SendKeys("12345678");
            ul.LoginButton.Click();
        }

        [TestCaseSource("UserGroupObjects"), Order(2)]
        public void CreateUserGroup(dynamic UserGroupObject)
        {
            browserOps.implicitWait(300);
            ug.locateUserGroupMenu.Click();
            browserOps.implicitWait(50);
            ug.locateUserGroupInnerMenu.Click();
            browserOps.implicitWait(50);
            ug.CreateUserGroup.Click();
            browserOps.implicitWait(50);



            driver.SwitchTo().Window(driver.WindowHandles.Last());


            browserOps.implicitWait(50);
            ug.Name.SendKeys(UserGroupObject.Name);
            ug.Description.SendKeys(UserGroupObject.Description);

            browserOps.implicitWait(50);
            ug.AddUserButton.Click();
            ug.SearchForUser.SendKeys(UserGroupObject.UserName);
            browserOps.implicitWait(100);
            ug.SelectUser.Click();
            browserOps.implicitWait(50);
            ug.AddSelectedUser.Click();

            browserOps.implicitWait(100);
            ug.ConstrainTab.Click();
            ug.NewIP.Click();
            ug.IpAddress.SendKeys(UserGroupObject.Ip);
            ug.IpDescription.SendKeys(UserGroupObject.IpDescription);
            ug.SaveIp.Click();

            ug.SaveUserGroup.Click();
           
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> UserGroupObjects()
        {
            return GetDataFromXML.GetDataFromFile(@"TestData\User\Security\UserGroup.xml");
        }
    }  
}
