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

        public IWebElement DatePickerClick
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Date1TglBtn']"));
            }

        }

        public IWebElement TextBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='TextBox1']"));
            }
        }
        
        public IWebElement SimpleSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect1Wraper']/div/button/div/div/div"));
            }
        }
        public IWebElement SimpleSelectItemSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='WebForm_jq6bcupe']/div[5]/div/div/ul/li[3]/a"));
            }
        }
        public IWebElement DatePickerCheckBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='WebForm_jq6bcupe']/div[5]/div/div/ul/li[3]/a"));
            }
        }
        
        public IWebElement PowerSelectClicker
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='name']"));
            }
        }
        
        public IWebElement PowerSelectItemSelector
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect1tbl']/tbody/tr[17]/td[1]/input"));
            }
        }
    }
}
