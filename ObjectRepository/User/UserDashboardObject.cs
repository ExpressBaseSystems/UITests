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
                return this.driver.FindElement(By.XPath("//*[@id='UserDashBoardSwitchList']/div[1]/button"));
            }
        }
    }
}