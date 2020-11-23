using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class RoleRelatedTestCase :BaseClass
    {
        UserLogin ulog;
        RoleRelated r;
        public string role_name;
        string anon_role;
        public string urlrols = "https://uitesting.eb-test.cloud/Security/CommonList?type=Roles";

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            r = new RoleRelated(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
                browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Roles");
            }
        }

        [Property("TestCaseId", "Role_UniqNameCheck_001")]
        [Test, Order(1)]
        public void UniqNameCheck()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.BtnNewRole.Click();
            browserOps.SwitchTo();
            elementOps.ExistsId("txtRoleName");
            role_name = "Test Role" + id.GetId;
            r.RoleName.SendKeys(role_name);
            wait.Until(webDriver => (!driver.PageSource.Contains("title=\"Validating...\"")));
            Assert.True(elementOps.IsWebElementPresent(r.RoleNameVerify), "Success", "Success");
            driver.Close();
            browserOps.SwitchTo();
            browserOps.Refresh();
        }

        [Property("TestCaseId", "Role_CreateNewRole_001")]
        [Test, Order(2)]
        public void CreateNewRole()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.BtnNewRole.Click();
            browserOps.SwitchTo();

            elementOps.ExistsId("txtRoleName");
            role_name = "Test Role" + id.GetId;
            r.RoleName.SendKeys(role_name);
            wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check\" aria-hidden=\"true\" style=\"color:green; padding: 9px;\"")));
            r.RoleDesc.SendKeys("Test Role Desc");
            r.SlctApp.Click();
            r.SlctAppOpt.Click();

            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("New Role Created....");
            browserOps.SwitchTo();
            browserOps.Refresh();
            int val1 = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            Assert.True(val1 > val, "Success", "Success");
        }


        [Property("TestCaseId", "Role_SetPermission_001")]
        [Test, Order(3)]
        public void SetPermission()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.ChooseRole.Click();
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id=\"ulTabOnMngRole\"]/li[2]/a");
            r.TabPermsn.Click();

            elementOps.ExistsId("aWebForm");
            actions = new Actions(driver);
            actions.MoveToElement(r.Webfrm);
            actions.Perform();
            r.Webfrm.Click();
            elementOps.ExistsXpath("//*[@id='tblWebForm']/tbody/tr[1]/td[2]/input");
            actions = new Actions(driver);
            actions.MoveToElement(r.Frm1P1);
            actions.Perform();
            r.Frm1P1.Click();

            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("Permission Set");
            browserOps.SwitchTo();
            browserOps.Refresh();
        }

        [Property("TestCaseId", "Role_SetSubRoles_001")]
        [Test, Order(4)]
        public void SetSubRoles()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.ChooseRole.Click();
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id=\"ulTabOnMngRole\"]/li[3]/a");
            r.TabSubRols.Click();

            elementOps.ExistsXpath("//*[@id='divroles']/div[1]/button");
            actions = new Actions(driver);
            actions.MoveToElement(r.BtnAddRols);
            actions.Perform();
            r.BtnAddRols.Click();
            elementOps.ExistsXpath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[1]/div[1]/input");
            r.Rol1.Click();
            elementOps.ExistsId("btnModalOkAdd_Roles");
            r.BtnbOkAdd_Rols.Click();

            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("Sub Role Set");
            browserOps.SwitchTo();
            browserOps.Refresh();
        }

        [Property("TestCaseId", "Role_SubRolesSearch_001")]
        [Test, Order(5)]
        public void SubRolesSearch()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.ChooseRole.Click();
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id=\"ulTabOnMngRole\"]/li[3]/a");
            r.TabSubRols.Click();

            elementOps.ExistsId("btnAddModalAdd_Roles");
            actions = new Actions(driver);
            actions.MoveToElement(r.BtnAddRols);
            actions.Perform();
            r.BtnAddRols.Click();
            elementOps.ExistsId("txtSearchAdd_Roles");
            browserOps.ClickableWait(r.SrchRols);
            r.SrchRols.SendKeys("SolutionO");
            Console.WriteLine("Sub Role Search Success");
            driver.Close();
            browserOps.SwitchTo();
            browserOps.Refresh();
        }
        
        [Property("TestCaseId", "Role_SearchUser_001")]
        [Test, Order(6)]
        public void SearchUser()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.ChooseRole.Click();
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            r.TabUsrs.Click();

            elementOps.ExistsId("btnAddModalAdd_Users");
            actions = new Actions(driver);
            actions.MoveToElement(r.BtnAddUser);
            actions.Perform();
            r.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");

            r.SrchUser.SendKeys("Anoopa");
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input");
            r.Usr1.Click();
            elementOps.ExistsId("btnModalOkAdd_Users");
            r.BtnOkAdd_Usrs.Click();
            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("Set User Success");
            browserOps.SwitchTo();
            browserOps.Refresh();
        }


        [Property("TestCaseId", "Role_Anonymous_Role_001")]
        [Test, Order(7)]
        public void Anonymous_Role()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.BtnNewRole.Click();
            browserOps.SwitchTo();

            elementOps.ExistsId("txtRoleName");
            anon_role = "Test Anonymous Role" + id.GetId;
            r.RoleName.SendKeys(anon_role);
            wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check\" aria-hidden=\"true\" style=\"color:green; padding: 9px;\"")));
            r.RoleDesc.SendKeys("Test Anonymous Role Desc");
            r.SlctApp.Click();
            r.SlctAppOpt.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[1]/a");
            r.TabSet.Click();
            elementOps.ExistsXpath("//*[@id='settings']/div[1]/div/div/label[2]");
            r.RolTyp.Click();

            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("New Role Created....");
            browserOps.SwitchTo();
            browserOps.Refresh();
            int val1 = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            Assert.True(val1 > val, "Success", "Success");

        }

        [Property("TestCaseId", "Role_Rol_LtdAces_001")]
        [Test, Order(8)]
        public void Rol_LtdAces()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            r.BtnNewRole.Click();
            browserOps.SwitchTo();

            elementOps.ExistsId("txtRoleName");
            role_name = "Test Role" + id.GetId;
            r.RoleName.SendKeys(role_name);
            wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check\" aria-hidden=\"true\" style=\"color:green; padding: 9px;\"")));
            r.RoleDesc.SendKeys("Test Role DEsc");
            r.SlctApp.Click();
            r.SlctAppOpt.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[1]/a");
            r.TabSet.Click();

            elementOps.ExistsXpath("//*[@id='settings']/div[2]/div/div/label[2]");
            r.RolLocs.Click();
            r.Loc1.Click();
            r.Loc2.Click();

            elementOps.ExistsId("btnSaveAll");
            r.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            r.BtnDlgBoxOk.Click();
            Console.WriteLine("New Role Created....");
            browserOps.SwitchTo();
            browserOps.Refresh();
            int val1 = elementOps.GetTableRowCount("//*[@id=\"tblCommonList\"]/tbody/tr");
            Assert.True(val1 > val, "Success", "Success");

        }
        
    }
}
