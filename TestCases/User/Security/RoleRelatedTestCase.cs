﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class RoleRelatedTestCase : BaseClass
    {
        public RoleRelated role;
        public string role_name;

        [TestCaseSource("Roles"), Order(1)]
        public void CreateNewRole(dynamic r)
        {
            UserLogin();
            role = new RoleRelated(driver);
            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/UserDashboard");

            elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[3]");
            role.SecurityLink.Click();
            elementOps.ExistsXpath("//*[@id='ebm-security']/div[2]/ul/li[5]/a");
            role.RoleLink.Click();

            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/Security/CommonList?type=Roles");
            role.BtnNewRole.Click();

            browserOps.SwitchTo();
            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/Security/ManageRoles");

            elementOps.ExistsId("txtRoleName");
            role_name = r.rolename + id.GetId;
            role.RoleName.SendKeys(role_name);
            role.RoleDesc.SendKeys(r.description);
            role.SlctApp.Click();
            role.SlctAppOpt.Click();
            browserOps.implicitWait(5);

            role.TabPermsn.Click();
            elementOps.ExistsId("aWebForm");
            role.Webfrm.Click();
            browserOps.implicitWait(5);
            role.Frm1P1.Click();
            role.Frm1P2.Click();
            role.Frm1P3.Click();
            role.Frm2P1.Click();
            role.Frm2P2.Click();
            browserOps.implicitWait(5);
            role.Webfrm.Click();
            role.Webfrm.Displayed.Equals(false);
            browserOps.implicitWait(100);

            role.TVis.Displayed.Equals(true);
            role.TVis.Click();
            role.Tvis1.Click();
            role.TVis2.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            role.TabUsrs.Click();
            elementOps.ExistsId("btnAddModalAdd_Users");
            role.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");
            role.SrchUser.Click();
            role.SrchUser.SendKeys("Jos");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[3]/div[1]/input");
            role.Usr1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[4]/div[1]/input");
            role.Usr2.Click();

            elementOps.ExistsId("btnModalOkAdd_Users");
            role.BtnOkAdd_Usrs.Click();

            elementOps.ExistsId("btnSaveAll");
            role.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            role.BtnDlgBoxOk.Click();
            Console.WriteLine("New Role Created....");
        }

        [TestCaseSource("Roles"), Order(2)]
        public void EditRole(dynamic edt_r)
        {
            browserOps.SwitchTo();
            role = new RoleRelated(driver);

            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/Security/CommonList?type=Roles");
            driver.Navigate().Refresh();

            elementOps.ExistsId("txtSrchCmnList");
            role.SrchRole.SendKeys(role_name);

            role.SlctRole.Click();
            browserOps.SwitchTo();
            role.RoleDesc.Clear();
            role.RoleDesc.SendKeys(edt_r.editdesc);

            role.TabPermsn.Click();
            browserOps.implicitWait(20);
            role.TVis.Click();
            browserOps.implicitWait(20);
            role.TVis3.Click();
            browserOps.implicitWait(100);
            role.TVis.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            role.TabUsrs.Click();
            elementOps.ExistsId("btnAddModalAdd_Users");
            role.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");
            role.SrchUser.Click();
            role.SrchUser.SendKeys("Jos");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();

            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[3]/div[1]/input");
            role.Usr1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input");
            role.Usr3.Click();

            elementOps.ExistsId("btnModalOkAdd_Users");
            role.BtnOkAdd_Usrs.Click();
            elementOps.ExistsId("btnSaveAll");
            role.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            role.BtnDlgBoxOk.Click();
            Console.WriteLine("Role Edited....");
            browserOps.implicitWait(20);
            browserOps.SwitchTo();
            driver.FindElement(By.Id("txtSrchCmnList")).Clear();
            driver.Navigate().Refresh();
        }

        private static List<EbTestItem> Roles()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\RoleRelatedTestCase.xml");
        }
    }
}
