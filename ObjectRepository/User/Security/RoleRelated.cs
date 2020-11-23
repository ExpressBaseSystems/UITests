using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.TestCases.User.Security;

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
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[3]/a"));
            }
        }

        public IWebElement RoleLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-security\"]/div[2]/ul/li[5]/a"));
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
                return this.driver.FindElement(By.XPath("//*[@id='selectApp']/option[4]"));
            }
        }

        public IWebElement TabSet
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ulTabOnMngRole']/li[1]/a"));
            }
        }

        public IWebElement RolTyp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='settings']/div[1]/div/div/label[2]"));
            }
        }

        public IWebElement RolLocs
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='settings']/div[2]/div/div/label[2]"));
            }
        }

        public IWebElement Loc1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[text()='Thiruvananthapuram - Thiruvananthapuram']"));
            }
        }

        public IWebElement Loc2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[text()='Ernakulam - Ernakulam']"));
            }
        }

        public IWebElement Loc3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[text()='Kochi Corporation - Kochi Corporation']"));
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

        public IWebElement Frm1P4
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr/td[5]/input"));
            }
        }

        public IWebElement Frm1P5
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblWebForm']/tbody/tr/td[6]/input"));
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
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[3]/td[2]/input"));
            }
        }

        public IWebElement TVis2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[4]/td[2]/input"));
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
                return this.driver.FindElement(By.XPath("//*[@id='divroles']/div[1]/button"));
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
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Roles']/div[3]/div[1]/input"));
            }
        }

        public IWebElement Rol3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Roles']/div[6]/div[1]/input"));
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
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input"));
            }
        }

        public IWebElement Usr2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[2]/div[1]/input"));
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
                return this.driver.FindElement(By.XPath("//*[@id='tblTableVisualization']/tbody/tr[6]/td[2]/input"));
            }
        }

        public IWebElement MsgBox
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb_messageBox_container"));
            }
        }

        public IWebElement ChooseRole
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tblCommonList\"]/tbody/tr[3]/td[8]/i"));
            }
        }

        public IWebElement RoleNameVerify
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"spanRoleName\"]/i"));
            }
        }

    }
}
