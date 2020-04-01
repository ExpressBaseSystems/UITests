using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.TempMail
{
    public class GetTempMail
    {
        private IWebDriver driver;

        public GetTempMail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetEmailId
        {
            get
            {
                return this.driver.FindElement(By.Id("email"));
            }
        }

        public IWebElement DeleteId
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[3]/a[1]"));
            }
        }
    }
}
