using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security.UserCreation
{
    public class ChooseRoles
    {
        private IWebDriver driver;

        public ChooseRoles(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AddRoleTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[2]/a"));
            }
        }

        public IWebElement AddRoleButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Roles"));
            }
        }

        public IWebElement SolutionOwner
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[1]/div[1]/input"));
            }
        }

        public IWebElement SolutionAdmin
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[2]/div[1]/input"));
            }
        }

        public IWebElement RolesOkButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_Roles"));
            }
        }

    }
}
