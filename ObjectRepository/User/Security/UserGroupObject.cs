using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.ObjectRepository.User.Security
{
    class UserGroupObject
    {
        private IWebDriver driver;

        public UserGroupObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement locateUserGroupMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='appList']/div/ul/li/ul/li[3]/a"));
            }
            
        }
        public IWebElement locateUserGroupInnerMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ebm-security']/div[2]/ul/li[3]/a"));
            }

        }
        
        public IWebElement UserGroupSearch
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSrchCmnList"));
            }

        }
        public IWebElement CreateUserGroup
        {
            get
            {
                return this.driver.FindElement(By.Id("btnNewCmnList"));
            }

        }

        public IWebElement Name
        {
            get
            {
                return this.driver.FindElement(By.Id("txtUserGroupName"));
            }
        }
        
        public IWebElement Description
        {
            get
            {
                return this.driver.FindElement(By.Id("txtUserGroupDescription"));
            }
        }
        public IWebElement AddUserButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Users"));
            }
        }
        public IWebElement SearchForUser
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSearchAdd_Users"));
            }
        }
        public IWebElement SelectUser
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input"));
            }
        }
        public IWebElement AddSelectedUser
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_Users"));
            }
        }
        public IWebElement ConstrainTab 
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='eb-usrgrp-pane h-100']/ul/li[2]/a"));
            }
        }
        public IWebElement NewIP
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalNew_IP"));
            }
        }
        public IWebElement IpAddress
        {
            get
            {
                return this.driver.FindElement(By.Id("txtIpAddressNew_IP"));
            }
        }
        public IWebElement IpDescription
        {
            get
            {
                return this.driver.FindElement(By.Id("txtIpDescriptionNew_IP"));
            }
        }
        public IWebElement SaveIp
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkNew_IP"));
            }
        }
        public IWebElement SaveUserGroup
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSaveAll"));
            }
        }

        public IWebElement SelectToEdit
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblCommonList']/tbody/tr/td[4]/i"));
            }
        }
        public IWebElement EditTheFirstUser
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSelectedDisplayAdd_Users']/div[1]/div/div[3]/div/i"));
            }
        }
        public IWebElement RemoveFirstUser
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSelectedDisplayAdd_Users']/div[1]/div/div[3]/div/ul/li[2]/a"));
            }//*[@id="divSelectedDisplayAdd_Users"]/div[1]/div/div[3]/div/i
        }
        public IWebElement OkButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='eb_dlogBox_container']/div/div[3]/button[1]"));
            }
        }

        public IWebElement RemoveIpConstrain
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divSelectedDisplayNew_IP']/div/div/div[3]/i"));
            }
        }
    }
}
