using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security.UserCreation
{
    public class ChooseGroup
    {
        private IWebDriver driver;

        public ChooseGroup(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AddGroupTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[4]/a"));
            }
        }

        public IWebElement AddGroupButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_User_Group"));
            }
        }

        public IWebElement TestUserGroup
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_User_Group\"]/div/div[1]/input"));
            }
        }

        public IWebElement ChooseGroupOkButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_User_Group"));
            }
        }
    }
}
