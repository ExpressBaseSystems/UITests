using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class UserDashboardTestCase :BaseClass
    {
       
        UserDashboardObject udb;


        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ul.UserName.SendKeys("kurian@expressbase.com");
            ul.Password.SendKeys("@Kurian123");
            ul.LoginButton.Click();

            udb = new UserDashboardObject(driver);
        }

        [Property("TestCaseId", "User_Dashboard_001")]
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
