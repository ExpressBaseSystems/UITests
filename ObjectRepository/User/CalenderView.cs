using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class CalenderView
    {
        private IWebDriver driver;

        public CalenderView(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement MenuApplication
        {
            get
            {
                return this.driver.FindElement(By.LinkText("UITest"));
            }
        }
        public IWebElement MenuSelectCalenderViewMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ebm-objtcontainer']/div[2]/div[7]"));
            }
        }
        public IWebElement MenuSelectCalenderView
        {
            get
            {
                return this.driver.FindElement(By.LinkText("PlatformC Calendar"));
            }
        }
        public IWebElement CalenderViewFilterbtnGo
        {
            get
            {
                return this.driver.FindElement(By.Id("btnGo"));
            }
        }
        public IWebElement CalenderViewNumeriCheck
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[49]/td[6]/div/span"));
            }
        }
        public IWebElement CalenderViewCalenderControlButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/button"));
            }
        }
        public IWebElement CalenderViewCalenderControlButtonHourly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[1]/a"));
            }
        }
        public IWebElement CalenderViewCalenderControlButtonWeekly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[3]/a"));
            }
        }
        public IWebElement CalenderViewCalenderControlButtonMonthly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[4]/a"));
            }
        }
        public IWebElement CalenderViewCalenderControlButtonQuarterly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[5]/a"));
            }
        }
        public IWebElement CalenderViewCalenderControlButtonHalfYearly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[6]/a"));
            }
        } 
        public IWebElement CalenderViewCalenderControlButtonYearly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='param1_CalendarControl1']/div[1]/div/ul/li[7]/a"));
            }
        }
        public IWebElement CalenderViewFilterHourly
        {
            get
            {
                return this.driver.FindElement(By.Id("date"));
            }
        }
        public IWebElement CalenderViewFilterMonth
        {
            get
            {
                return this.driver.FindElement(By.Id("month"));
            }
        }
        public IWebElement CalenderViewFilterYear
        {
            get
            {
                return this.driver.FindElement(By.Id("year"));
            }
        }
        public IWebElement CalenderViewFilterMonthSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='MonthPicker_month']/div[2]/table/tr[3]/td[2]/a"));
            }
        }
        
    }
}
