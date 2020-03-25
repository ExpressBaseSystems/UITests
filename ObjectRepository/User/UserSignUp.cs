using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class UserSignUp
    {
        private IWebDriver driver;

        public UserSignUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CreateAccountLink
        {
            get
            {
                return this.driver.FindElement(By.Id("Signupform"));
            }
        }
        
    }
}
