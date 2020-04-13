using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class FormObject
    {
        private IWebDriver driver;

        public FormObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MenuApplication
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='appList']/div/ul/li/ul/li[6]/a"));
            }
        }
        public IWebElement MenuSelectFormMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div[2]/div[2]/div[2]/div[1]"));
            }
        }public IWebElement MenuSelectForm
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div[2]/div[3]/div[2]/div[1]/a"));
            }
        }

        public IWebElement TextBoxLowerCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }

        }

        public IWebElement TextBoxUpperCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }
        
        public IWebElement TextBoxPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }
        }
        public IWebElement TextBoxEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }
        public IWebElement TextBoxMultiLine
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }
        
        public IWebElement TextBoxMaxLength
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }
        
        public IWebElement TextboxAutosuggestion
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox7"));
            }
        }public IWebElement TextboxHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox8"));
            }
        }public IWebElement TextboxReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }public IWebElement TextboxRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox10"));
            }
        }public IWebElement TextboxUnique
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox11"));
            }
        }public IWebElement TextboxDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox12"));
            }
        }
    }
}
