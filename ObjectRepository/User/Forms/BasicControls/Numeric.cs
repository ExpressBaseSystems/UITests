using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class Numeric
    {
        private IWebDriver driver;

        public Numeric(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }

        public IWebElement Numeric1
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }

        public IWebElement Numeric2
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric2"));
            }
        }

        public IWebElement Numeric3
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric3"));
            }
        }

        public IWebElement Numeric4
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric4"));
            }
        }

        public IWebElement Numeric4Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric4"));
            }
        }

        public IWebElement Numeric5
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric5"));
            }
        }

        public IWebElement Numeric5Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric5"));
            }
        }

        public IWebElement Numeric6
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric6"));
            }
        }

        public IWebElement Numeric6Div
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric6Wraper"));
            }
        }

        public IWebElement Numeric7
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric7"));
            }
        }

        public IWebElement Numeric8
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric8"));
            }
        }

        public IWebElement Numeric9
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric9"));
            }
        }

        public IWebElement Numeric10
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric10"));
            }
        }
        public IWebElement Numeric11
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric11"));
            }
        }

        public IWebElement Numeric12
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric12"));
            }
        }

        public IWebElement Numeric13
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric13"));
            }
        }

        public IWebElement Numeric14
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric14"));
            }
        }

        public IWebElement Numeric15
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric15"));
            }
        }

        public IWebElement Numeric16
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric16"));
            }
        }

        public IWebElement Numeric17
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric17"));
            }
        }

        public IWebElement Numeric17Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric17"));
            }
        }

        public IWebElement Numeric18
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric18"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformsave"));
            }
        }

        public IWebElement EditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }
    }
}
