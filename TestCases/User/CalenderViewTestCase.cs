using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    public class CalenderViewTestCase : BaseClass
    {
        CalenderView fo;
        GetUniqueId UID;
        string UniqueId;
        string TodaysDate;

        public void Userlogin(string FormId)
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ul.UserName.SendKeys("kurian@expressbase.com");
                ul.Password.SendKeys("@Kurian123");
                ul.LoginButton.Click();

                fo = new CalenderView(driver);
                UID = new GetUniqueId();

                wait.Until(webDriver => (driver.PageSource.Contains("class=\"list-group-item inner_li Obj_link for_brd\"")));
                Console.WriteLine("Login Succesfull");

                FormSelect(FormId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!  " + e.Message + "Stack Trace" + e.StackTrace);
            }
        }
        public void FormSelect(string FormID)
        {


            browserOps.implicitWait(1);
            elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
            fo.MenuApplication.Click();
            browserOps.implicitWait(1);

            actions.MoveToElement(fo.MenuSelectCalenderViewMenu).Perform();
            elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[1]");
            fo.MenuSelectCalenderViewMenu.Click();
            browserOps.implicitWait(1);
            if (FormID == "PlatformCCalendar")
            {
                actions.MoveToElement(fo.MenuSelectCalenderView).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectCalenderView.Click();
            }
            Console.WriteLine("Test Form Opened");
        }

    }
}
