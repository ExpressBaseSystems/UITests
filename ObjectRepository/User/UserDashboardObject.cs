using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class UserDashboardObject
    {
        private IWebDriver driver;

        public UserDashboardObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SwitchDB
        {
            get
            {
                return this.driver.FindElement(By.Id("UserDashBoardSwitchBtn"));
            }
        }

        public IWebElement SelectFirstDB
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='UserDashBoardSwitchList']/div[5]/button"));
            }
        }
        
        public IWebElement TableCoumnSort
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tb1tile1_wrapper']/div[3]/div[1]/div/table/thead/tr/th[3]"));
            }
        }
        
        public IWebElement TableTree
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tb1tile1']/tbody/tr[1]/td[2]/i"));
            }
        }
        public IWebElement TableLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tb1tile1']/tbody/tr[2]/td[10]"));
            }
        }
    }
}