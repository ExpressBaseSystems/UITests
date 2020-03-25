using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UITests.ObjectRepository.Tenant
{
    class TenantSignUp
    {
        private IWebDriver driver;

        public TenantSignUp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SignUpButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("callActionBtn"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.driver.FindElement(By.Id("email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("inputPassword"));
            }
        }

        public IWebElement Name
        {
            get
            {
                return this.driver.FindElement(By.Id("name"));
            }
        }

        public IWebElement Country
        {
            get
            {
                return this.driver.FindElement(By.Id("country"));
            }
        }

        public IWebElement JoinNow
        {
            get
            {
                return this.driver.FindElement(By.Id("save-profile"));
            }
        }

        public IWebElement EmailError1
        {
            get
            {
                return this.driver.FindElement(By.Id("emaillbl"));
            }
        }
        
        public IWebElement EmailError2
        {
            get
            {
                return this.driver.FindElement(By.Id("emaillbl2"));
            }
        }

        public IWebElement StrongPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("psdinfo1"));
            }
        }

        public IWebElement NameCheck
        {
            get
            {
                return this.driver.FindElement(By.Id("namelbl"));
            }
        }
    }
}
