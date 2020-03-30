using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security
{
    public class RoleRelated
    {
        IWebDriver driver;
        public RoleRelated(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SecurityLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='appList']/div/ul/li/ul/li[3]"));
            }
        }

        public IWebElement RoleLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ebm-security']/div[2]/ul/li[5]/a"));
            }
        }

        public IWebElement CreateNewRoleBtn
        {
            get
            {
                return this.driver.FindElement(By.Id("btnNewCmnList"));
            }
        }

        public IWebElement RoleName
        {
            get
            {
                return this.driver.FindElement(By.Id("txtRoleName"));
            }
        }

        public IWebElement RoleDescription
        {
            get
            {
                return this.driver.FindElement(By.Id("txtRoleDescription"));
            }
        }

        public IWebElement SelectApp
        {
            get
            {
                return this.driver.FindElement(By.Id("selectApp"));
            }
        }

        public IWebElement SelectAppOption
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='selectApp']/option[34]"));
            }
        }

        public IWebElement Permissions
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[2]/a"));
            }
        }

        public IWebElement Webform
        {
            get
            {
                return this.driver.FindElement(By.Id("aWebForm"));
            }
        }

        public IWebElement WebForm1PNew
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[2]/input"));
            }
        }

        public IWebElement WebForm1PView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[3]/input"));
            }
        }

        public IWebElement WebForm1PEdit
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[4]/input"));
            }
        }

        public IWebElement WebForm2PNew
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[2]/td[2]/input"));
            }
        }

        public IWebElement WebForm2PView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[2]/td[3]/input"));
            }
        }

        public IWebElement TableVisualization
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='aTableVisualization']"));
            }
        }

        public IWebElement TableVisualization1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[5]/td[2]/input"));
            }
        }

        public IWebElement TableVisualization2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[9]/td[2]/input"));
            }
        }

        public IWebElement Users
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[4]"));
            }
        }

        public IWebElement AddUsers
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Users"));
            }
        }

        public IWebElement SearchAddUsers
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSearchAdd_Users"));
            }
        }

        public IWebElement SearchResult1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[3]/div[1]/input"));
            }
        }

        public IWebElement SearchResult2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[4]/div[1]/input"));
            }
        }

        public IWebElement SearchResult3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input"));
            }
        }

        public IWebElement OkBtnAddUsers
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_Users"));
            }
        }

        public IWebElement BtnSave
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSaveAll"));
            }
        }

        public IWebElement DlogBoxOk
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='eb_dlogBox_container']/div/div[3]/button"));
            }
        }

        public IWebElement SearchRolesList
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSrchCmnList"));
            }
        }

        public IWebElement SelectRole
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblCommonList']/tbody/tr[24]/td[2]/div"));
            }
        }

        public IWebElement TableVisualization3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[8]/td[2]/input"));
            }
        }
    }
}
