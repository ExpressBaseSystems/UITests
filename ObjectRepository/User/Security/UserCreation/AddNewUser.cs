using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security.UserCreation
{
    public class AddNewUser
    {
        private IWebDriver driver;

        public AddNewUser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CreateUserButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnNewCmnList"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.driver.FindElement(By.Id("txtFullName"));
            }
        }

        public IWebElement NickName
        {
            get
            {
                return this.driver.FindElement(By.Id("txtNickName"));
            }
        }

        public IWebElement EmailId
        {
            get
            {
                return this.driver.FindElement(By.ClassName("txtEmail"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdPassword"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdPasswordCon"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnCreateUser"));
            }
        }
    }
}
