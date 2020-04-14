using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class TableVisualizationTestCase : BaseClass
    {
        UserLogin ulog;
        TableVisualization tv;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public void ChooseTV()
        {
            tv = new TableVisualization(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[6]/a");
            tv.SelectApp.Click();
            Console.WriteLine("SelectApp");
            elementOps.ExistsXpath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[2]");
            tv.SelectTableView.Click();
            Console.WriteLine("SelectTableView");
            elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div");
            tv.SelectTableVisualization.Click();
            Console.WriteLine("SelectTableVisualization");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Console.WriteLine("Table Visualization");
        }

        [Test]
        public void AddNewForm()
        {
            UserLogin();
            ChooseTV();
            tv = new TableVisualization(driver);
            tv.NewFormButton.Click();
            elementOps.ExistsXpath("//*[@id=\"NewFormdddvContainer_1586780535084_0_0\"]/div/ul/li/a");
            string url = driver.Url;
            tv.NewFormUserCreation.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (driver.Url != url)
                Console.WriteLine("Success!!");
            else
                Console.WriteLine("Faliure!!");
        }

        [Test]
        public void EditForm()
        {
            UserLogin();
            ChooseTV();
            tv = new TableVisualization(driver);
            tv.DataEntryLinkClick.Click();
            Console.WriteLine("Link Clicked");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            tv.WebFormEditButton.Click();
            Console.WriteLine("Edit Button Clicked");
            browserOps.implicitWait(50);
            string txt = tv.EditMode.GetAttribute("innerHTML");
            Assert.AreEqual(txt, "Edit Mode");
            Console.WriteLine("Success!!");
        }
    }
}
