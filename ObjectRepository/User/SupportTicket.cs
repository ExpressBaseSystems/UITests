using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class SupportTicket
    {
        IWebDriver driver;
        public SupportTicket(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SupportTicketLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='appList']/div/ul/li/ul/li[1]/a"));
            }
        }

        public IWebElement BtnNewTkt
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='newticket']"));
            }
        }
    }
}
