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
        CalenderView cv;
        GetUniqueId UID;
        string dataobjecttype;
        string datavalue;
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

                cv = new CalenderView(driver);
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
            cv.MenuApplication.Click();
            browserOps.implicitWait(1);

            actions.MoveToElement(cv.MenuSelectCalenderViewMenu).Perform();
            elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[7]");
            cv.MenuSelectCalenderViewMenu.Click();
            browserOps.implicitWait(1);
            if (FormID == "PlatformCCalendar")
            {
                actions.MoveToElement(cv.MenuSelectCalenderView).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div/a");
                cv.MenuSelectCalenderView.Click();
            }
            Console.WriteLine("Test Form Opened");
        }



        [Property("TestCaseId", "CalenderView_HourlyWise")]
        [Test, Order(2)]
        public void HourlyChecker()
        {
            try
            {
                Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonHourly.Click();
                cv.CalenderViewFilterHourly.SendKeys("");
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("HourlyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - DayWise”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        [Property("TestCaseId", "CalenderView_DayWise")]
        [Test, Order(1)]
        public void DayWiseChecker()
        {
            try
            {
                Userlogin("PlatformCCalendar");
                cv.CalenderViewFilterMonth.Click();
                cv.CalenderViewFilterMonthSelect.Click();
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("DayWiseChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - DayWise”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        [Property("TestCaseId", "CalenderView_HoulryWise")]
        [Test, Order(3)]
        public void WeeklyChecker()
        {
            try
            {
                //Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonWeekly.Click();
                cv.CalenderViewFilterMonth.Click();
                cv.CalenderViewFilterMonthSelect.Click();
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("WeeklyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - DayWise”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        [Property("TestCaseId", "CalenderView_MonthlyWise")]
        [Test, Order(4)]
        public void MonthlyChecker()
        {
            try
            {
                //Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonMonthly.Click();
                cv.CalenderViewFilterYear.SendKeys("2020");
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("MonthlyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - DayWise”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        
        [Property("TestCaseId", "CalenderView_QuarterlyWise")]
        [Test, Order(5)]
        public void QuarterlyChecker()
        {
            try
            {
                //Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonQuarterly.Click();
                cv.CalenderViewFilterYear.SendKeys("2020");
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("QuarterlyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - DayWise”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        [Property("TestCaseId", "CalenderView_HalfYearlyWise")]
        [Test, Order(6)]
        public void HalfYearlyChecker()
        {
            try
            {
                //Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonHalfYearly.Click();
                cv.CalenderViewFilterYear.SendKeys("2020");
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("HalfYearlyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - HalfYearly”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        [Property("TestCaseId", "CalenderView_YearlyWise")]
        [Test, Order(7)]
        public void YearlyChecker()
        {
            try
            {
                //Userlogin("PlatformCCalendar");
                cv.CalenderViewCalenderControlButton.Click();
                cv.CalenderViewCalenderControlButtonYearly.Click();
                cv.CalenderViewFilterYear.SendKeys("2020");
                cv.CalenderViewFilterbtnGo.Click();
                Assert.AreEqual(true, datachecker("YearlyChecker"), true.ToString(), "“Test passed for User - side - ClenderView  - HalfYearly”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }
        public bool datachecker(string objects)
        {
            try
            {
                for (int i=49; i <= 90; i++)
                {
                    switch (objects)
                    {
                        case "HourlyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[3]/div/span"))).Text;
                            break;
                        case "DayWiseChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[6]/div/span"))).Text;
                            break;
                        case "WeeklyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[3]/div/span"))).Text;
                            break;
                        case "MonthlyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[9]/div/span"))).Text;
                            break;
                        case "QuarterlyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[4]/div/span"))).Text;
                            break;
                        case "HalfYearlyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[3]/div/span"))).Text;
                            break;
                        case "YearlyChecker":
                            datavalue = (this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + i + "]/td[3]/div/span"))).Text;
                            break;
                    }
                    if (datavalue != "1")
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
                return false;
            }
           
        }

    }
}
