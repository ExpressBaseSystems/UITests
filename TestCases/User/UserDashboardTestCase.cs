using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    class UserDashboardTestCase
    {
        IWebDriver driver;
        UserLogin ul;
        UserDashboardObject udb;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                udb = new UserDashboardObject(driver);
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

        [Test, Order(2)]
        public void SwitchDashboard()
        {
            browserOps.implicitWait(300);
            udb.SwitchDB.Click();
            browserOps.implicitWait(100);
            udb.SelectFirstDB.Click();
            browserOps.implicitWait(100);
            udb.TableCoumnSort.Click();
            browserOps.implicitWait(100);
            udb.TableTree.Click();
            browserOps.implicitWait(100);
            udb.TableLink.Click();
        }
    }
}
