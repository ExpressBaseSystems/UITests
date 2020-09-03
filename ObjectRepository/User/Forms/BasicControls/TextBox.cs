using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class TextBox
    {
        private IWebDriver driver;

        public TextBox(IWebDriver driver)
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

        public IWebElement TextBox1
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement TextBox2
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }

        public IWebElement TextBox3
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }
        }

        public IWebElement TextBox4
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }

        public IWebElement TextBox5
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }

        public IWebElement TextBox6
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }

        public IWebElement TextBox7
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox7"));
            }
        }

        public IWebElement TextBox8
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox8"));
            }
        }

        public IWebElement TextBox9
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }

        public IWebElement TextBox10
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox10"));
            }
        }

        public IWebElement TextBox11
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox11"));
            }
        }

        public IWebElement TextBox12
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox12"));
            }
        }

        public IWebElement TextBox12Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox12"));
            }
        }

        public IWebElement TextBox13
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox13"));
            }
        }

        public IWebElement TextBox14
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox14"));
            }
        }

        public IWebElement TextBox14Div
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox14Wraper"));
            }
        }

        public IWebElement TextBox15
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox15"));
            }
        }

        public IWebElement TextBox15Div
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox15Wraper"));
            }
        }

        public IWebElement TextBox16
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox16"));
            }
        }

        public IWebElement TextBox17
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox17"));
            }
        }

        public IWebElement TextBox18
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox18"));
            }
        }

        public IWebElement TextBox19
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox19"));
            }
        }

        public IWebElement TextBox20
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox20"));
            }
        }

        public IWebElement TextBox21
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox21"));
            }
        }

        public IWebElement TextBox22
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox22"));
            }
        }
        public IWebElement TextBox22Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox22"));
            }
        }

        public IWebElement TextBox23
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox23"));
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
