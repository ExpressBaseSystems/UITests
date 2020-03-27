using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.Tenant
{
    public class IntegrationObject
    {
        private IWebDriver driver;

        public IntegrationObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement TenentToSetting
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='tdash-box-body']/div[4]/div/div[3]/a"));
            }
        }
        public IWebElement NewDB
        {
            get
            {
                return this.driver.FindElement(By.Id("Postgres"));
            }
        }
        public IWebElement dbNickNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbNickNameInput"));
            }
        }
        public IWebElement dbDatabaseNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbDatabaseNameInput"));
            }
        }

        public IWebElement dbServerInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbServerInput"));
            }
        }
        public IWebElement dbPortInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbPortInput"));
            }
        }
        public IWebElement dbTimeoutInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbTimeoutInput"));
            }
        }
        public IWebElement dbIsSSLInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbIsSSLInput"));
            }
        }
        public IWebElement dbUserNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbUserNameInput"));
            }
        }
        public IWebElement dbPasswordInput
        {
            get
            {
                return this.driver.FindElement(By.Id("dbPasswordInput"));
            }
        }

        public IWebElement SaveDB
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='dbConnectionSubmit']/div[3]/a"));
            }
        }
    }
}
