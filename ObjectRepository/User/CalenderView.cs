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
                return this.driver.FindElement(By.XPath("//*[@id='ebm-objtcontainer']/div[2]/div[1]"));
            }
        }
        public IWebElement MenuSelectCalenderView
        {
            get
            {
                return this.driver.FindElement(By.LinkText("PlatformC Calendar"));
            }
        }
    }
}
