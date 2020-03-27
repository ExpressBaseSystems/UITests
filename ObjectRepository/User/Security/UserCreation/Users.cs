using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security.UserCreation
{
    public class Users
    {
        private IWebDriver driver;

        public Users(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MenuButton
        {
            get
            {
                return this.driver.FindElement(By.Id("quik_menu"));
            }
        }

        public IWebElement ChooseSecurity
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[3]/a"));
            }
        }

        public IWebElement ChooseUsers
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-security\"]/div[2]/ul/li[1]/a"));
            }
        }
    }
}
