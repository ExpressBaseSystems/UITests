using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class Location
    {
        private IWebDriver driver;

        public Location(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LocationLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='appList']/div/ul/li/ul/li[4]/a"));
            }
        }

        public IWebElement BtnNewLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='layout_div']/div[2]/div/div[1]/div[2]/a"));
            }
        }

        public IWebElement LongName
        {
            get
            {
                return this.driver.FindElement(By.Name("longname"));
            }
        }

        public IWebElement ShortName
        {
            get
            {
                return this.driver.FindElement(By.Name("shortname"));
            }
        }   
        
        public IWebElement test
        {
            get
            {
                return this.driver.FindElement(By.Name("Test"));
            }
        }
        
        public IWebElement BtnAddLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='createloc']"));
            }
        }       
    }
}
