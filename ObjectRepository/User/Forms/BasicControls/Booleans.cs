using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class Booleans
    {
        private IWebDriver driver;

        public Booleans(IWebDriver driver)
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

        public IWebElement RadioButton1
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton1"));
            }
        }

        public IWebElement RadioButton1Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioButton1"));
            }
        }

        public IWebElement RadioButton2
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton2"));
            }
        }

        public IWebElement RadioButton3
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton3"));
            }
        }

        public IWebElement RadioButton4
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton4"));
            }
        }

        public IWebElement RadioButton5
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton5"));
            }
        }

        public IWebElement RadioButton6
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton6"));
            }
        }

        public IWebElement RadioButton7
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton7"));
            }
        }

        public IWebElement RadioButton7Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioButton7"));
            }
        }

        public IWebElement RadioButton8
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton8"));
            }
        }

        public IWebElement RadioButton9
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton9"));
            }
        }

        public IWebElement RadioButton10
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton10"));
            }
        }

        public IWebElement RadioButton11
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton11"));
            }
        }

        public IWebElement RadioButton12
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton12"));
            }
        }

        public IWebElement RadioButton13
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton13"));
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
