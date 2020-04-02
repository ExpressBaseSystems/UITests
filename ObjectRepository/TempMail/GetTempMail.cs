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
                return this.driver.FindElement(By.Id("eposta_adres"));
            }
        }

        public IWebElement DeleteId
        {
            get
            {
                return this.driver.FindElement(By.ClassName("yoket-link"));
            }
        }
    }
}
