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

        public string role_name { get; set; } = string.Empty;

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

        public IWebElement BtnNewRole
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

        public IWebElement RoleDesc
        {
            get
            {
                return this.driver.FindElement(By.Id("txtRoleDescription"));
            }
        }

        public IWebElement SlctApp
        {
            get
            {
                return this.driver.FindElement(By.Id("selectApp"));
            }
        }

        public IWebElement SlctAppOpt
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='selectApp']/option[34]"));
            }
        }

        public IWebElement TabPermsn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[2]/a"));
            }
        }

        public IWebElement Webfrm
        {
            get
            {
                return this.driver.FindElement(By.Id("aWebForm"));
            }
        }

        public IWebElement Frm1P1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[2]/input"));
            }
        }

        public IWebElement Frm1P2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[3]/input"));
            }
        }

        public IWebElement Frm1P3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[1]/td[4]/input"));
            }
        }

        public IWebElement Frm2P1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[2]/td[2]/input"));
            }
        }

        public IWebElement Frm2P2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr[2]/td[3]/input"));
            }
        }

        public IWebElement TVis
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='aTableVisualization']"));
            }
        }

        public IWebElement Tvis1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[5]/td[2]/input"));
            }
        }

        public IWebElement TVis2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[9]/td[2]/input"));
            }
        }

        public IWebElement TabUsrs
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[4]"));
            }
        }

        public IWebElement TabSubRols
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[3]/a"));
            }
        }

        public IWebElement BtnAddRols
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Roles"));
            }
        }

        public IWebElement SrchRols
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSearchAdd_Roles"));
            }
        }

        public IWebElement Rol1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Roles']/div[2]/div[1]/input"));
            }
        }

        public IWebElement Rol2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Roles']/div[4]/div[1]/input"));
            }
        }

        public IWebElement Rol3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Roles']/div[32]/div[1]/input"));
            }
        }

        public IWebElement BtnbOkAdd_Rols
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_Roles"));
            }
        }

        public IWebElement BtnAddUser
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Users"));
            }
        }

        public IWebElement SrchUser
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSearchAdd_Users"));
            }
        }

        public IWebElement Usr1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[3]/div[1]/input"));
            }
        }

        public IWebElement Usr2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[4]/div[1]/input"));
            }
        }

        public IWebElement Usr3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input"));
            }
        }

        public IWebElement BtnOkAdd_Usrs
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

        public IWebElement BtnDlgBoxOk
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='eb_dlogBox_container']/div/div[3]/button"));
            }
        }

        public IWebElement SrchRole
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSrchCmnList"));
            }
        }

        public IWebElement SlctRole
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblCommonList']/tbody/tr/td[2]/div"));
            }
        }

        public IWebElement TVis3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[8]/td[2]/input"));
            }
        }

        public IWebElement MsgBox
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb_messageBox_container"));
            }
        }
    }
}
