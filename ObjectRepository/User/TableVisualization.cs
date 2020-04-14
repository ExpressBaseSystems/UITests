using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class TableVisualization
    {
        private IWebDriver driver;

        public TableVisualization(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SelectApp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[6]/a"));
            }
        }

        public IWebElement SelectTableView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[2]"));
            }
        }

        public IWebElement SelectTableVisualization
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div"));
            }
        }

        //-------------- Table Visulization

        public IWebElement NewFormButton
        {
            get
            {
                return this.driver.FindElement(By.Id("NewFormButtondvContainer_1586780535084_0_0"));
            }
        }

        public IWebElement NewFormUserCreation
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"NewFormdddvContainer_1586780535084_0_0\"]/div/ul/li/a"));
            }
        }

        public IWebElement DataEntryLinkClick
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement WebFormEditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }

        public IWebElement EditMode
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"objname\"]/span"));
            }
        }
    }
}
