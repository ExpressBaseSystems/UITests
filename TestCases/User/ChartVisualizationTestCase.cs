using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class ChartVisualizationTestCase : BaseClass
    {
        UserLogin ulog;
        UserLogOut lo;
        ChartVisualization cv;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public void UserLogOut()
        {
            lo = new UserLogOut(driver);
            lo.ProfileImageDropDown.Click();
            browserOps.implicitWait(50);
            lo.LogoutButton.Click();
            browserOps.implicitWait(50);
            Console.WriteLine("LogOut Success");
        }

        public void ChooseCV()
        {
            cv = new ChartVisualization(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[6]/a");
            cv.SelectApp.Click();
            elementOps.ExistsXpath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[3]");
            actions.MoveToElement(cv.SelectChartView).Perform();
            cv.SelectChartView.Click();
            elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div");
            actions.MoveToElement(cv.SelectChartVisualizationUsers).Perform();
            cv.SelectChartVisualizationUsers.Click();
        }

        [Property("TestCaseId", "CHartVisualization_YaxisNewEntry_001")]
        [Test]
        public void YaxisNewEntry()
        {
            try
            {
                UserLogin();
                ChooseCV();

                cv = new ChartVisualization(driver);
                //elementOps.ExistsId("btnColumnCollapsedvContainer_1588221308998_0_0");
                //cv.ColumnCollapsedContainer.Click();
                browserOps.implicitWait(100);
                elementOps.ExistsClass("stickBtn");
                cv.Properties.Click();
                Console.WriteLine("Properties Clicked");
                elementOps.ExistsXpath("//*[@id=\"pp_inner_propGrid\"]/table/tbody/tr[7]/td[2]/button");
                cv.YaxisCollection.Click();
                Console.WriteLine("Collection Clicked");
                elementOps.ExistsXpath("//*[@id=\"user_id\"]/button[3]");
                cv.YaxisNewEntry.Click();
                Console.WriteLine("New Entry Clicked");
                cv.YaxisOk.Click();
                Console.WriteLine("Ok Clicked");
                cv.RunButton.Click();
                Console.WriteLine("Run Button Clicked");
                elementOps.ExistsId("Y_col_namedvContainer_1588221308998_0_0");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(cv.YAxisNewEntryli).ToString(), "New Entry Added", "New Entry Added");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
        
    }
}
