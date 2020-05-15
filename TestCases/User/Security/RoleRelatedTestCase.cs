using NUnit.Framework;
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
        string anon_role;
        public string urlrols = "https://uitesting.eb-test.cloud/Security/CommonList?type=Roles";
        public void UserLogin()
        {
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ul.UserName.SendKeys("anoopa.baby@expressbase.com");
            ul.Password.SendKeys("Qwerty@123");
            ul.LoginButton.Click();
        }

        [TestCaseSource("Roles"), Order(1)]
        public void CreateNewRole(dynamic r)
        {
            UserLogin();
            role = new RoleRelated(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashboard");

            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[3]/a");
            role.SecurityLink.Click();
            elementOps.ExistsXpath("//*[@id=\"ebm-security\"]/div[2]/ul/li[5]/a");
            role.RoleLink.Click();

            browserOps.UrlToBe(urlrols);
            role.BtnNewRole.Click();

            browserOps.SwitchTo();
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/Security/ManageRoles");

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

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[3]/a");
            role.TabSubRols.Click();
            elementOps.ExistsId("btnAddModalAdd_Roles");
            role.BtnAddRols.Click();
            elementOps.ExistsId("txtSearchAdd_Roles");
            role.SrchRols.SendKeys("Test Role");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Roles']/div[2]/div[1]/input");
            role.Rol1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Roles']/div[4]/div[1]/input");
            role.Rol2.Click();
            elementOps.ExistsId("btnModalOkAdd_Roles");
            role.BtnbOkAdd_Rols.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            role.TabUsrs.Click();
            elementOps.ExistsId("btnAddModalAdd_Users");
            role.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");
            role.SrchUser.Click();
            role.SrchUser.SendKeys("Jos");
            browserOps.implicitWait(100);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input");
            role.Usr1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[2]/div[1]/input");
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

            browserOps.UrlToBe(urlrols);
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
            role.TVis3.Click();
            role.TVis.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[3]/a");
            role.TabSubRols.Click();
            elementOps.ExistsId("btnAddModalAdd_Roles");
            role.BtnAddRols.Click();
            elementOps.ExistsId("txtSearchAdd_Roles");
            role.SrchRols.SendKeys("Test Role");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Roles']/div[1]/div[1]/input");
            role.Rol1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Roles']/div[6]/div[1]/input");
            role.Rol3.Click();
            elementOps.ExistsId("btnModalOkAdd_Roles");
            role.BtnbOkAdd_Rols.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            role.TabUsrs.Click();
            elementOps.ExistsId("btnAddModalAdd_Users");
            role.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");
            role.SrchUser.Click();
            role.SrchUser.SendKeys("Jos");
            browserOps.implicitWait(100);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[1]/div[1]/input");
            role.Usr1.Click();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[2]/div[1]/input");
            role.Usr2.Click();
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

        [TestCaseSource("Roles"), Order(3)]
        public void UniqNameCheck(dynamic r)
        {

            role = new RoleRelated(driver);

            browserOps.UrlToBe(urlrols);
            role.BtnNewRole.Click();

            browserOps.SwitchTo();
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/Security/ManageRoles");

            elementOps.ExistsId("txtRoleName");

            role.RoleName.SendKeys(role_name);
            role.RoleDesc.SendKeys(r.description);

            string currentmsgblk = string.Empty;

            elementOps.ExistsId("btnSaveAll");
            role.BtnSave.Click();

            if (role.MsgBox.Displayed)
            {
                currentmsgblk = role.MsgBox.GetAttribute("style");
            }
            string msgblk = "display: block";

            if (currentmsgblk.Contains(msgblk))
            {
                Console.WriteLine("Role Name is Already Exists ");
                browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Roles");
            }
            else
            {
                Console.WriteLine("New Role Created With the Same Name....");

                elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
                role.BtnDlgBoxOk.Click();

                browserOps.implicitWait(20);
                browserOps.SwitchTo();
                browserOps.UrlToBe("https://uitesting.eb-test.cloud/Security/CommonList?type=Roles");
                driver.Navigate().Refresh();
            }
        }

        [TestCaseSource("Roles"), Order(4)]
        public void Anonymous_Role(dynamic ar)
        {
            browserOps.SwitchTo();
            role = new RoleRelated(driver);

            browserOps.UrlToBe(urlrols);
            driver.Navigate().Refresh();

            browserOps.UrlToBe(urlrols);
            role.BtnNewRole.Click();

            browserOps.SwitchTo();
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/Security/ManageRoles");

            elementOps.ExistsId("txtRoleName");
            anon_role = ar.anonymsrole + id.GetId;
            role.RoleName.SendKeys(anon_role);
            role.RoleDesc.SendKeys(ar.description);
            role.SlctApp.Click();
            role.SlctAppOpt.Click();
            browserOps.implicitWait(5);

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[1]/a");
            role.TabSet.Click();
            elementOps.ExistsXpath("//*[@id='settings']/div[1]/div/div/label[2]");
            role.RolTyp.Click();

            role.TabPermsn.Click();
            elementOps.ExistsId("aWebForm");
            role.Webfrm.Click();
            browserOps.implicitWait(5);
            role.Frm1P1.Click();
            role.Frm1P2.Click();
            browserOps.implicitWait(5);
            role.Webfrm.Click();
            role.Webfrm.Displayed.Equals(false);
            browserOps.implicitWait(100);
            role.TVis.Displayed.Equals(true);
            role.TVis.Click();
            elementOps.ExistsXpath("//*[@id='tblTableVisualization']/tbody/tr[3]/td[2]/input");
            role.Tvis1.Click();
            role.TVis2.Click();
            role.TVis3.Click();

            elementOps.ExistsId("btnSaveAll");
            role.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            role.BtnDlgBoxOk.Click();
            Console.WriteLine("New Anonymous Role Created....");

            browserOps.SwitchTo();
            browserOps.UrlToBe(urlrols);
            driver.Navigate().Refresh();
        }

        [TestCaseSource("Roles"), Order(5)]
        public void Rol_LtdAces(dynamic rl)
        {
            browserOps.SwitchTo();
            role = new RoleRelated(driver);

            browserOps.UrlToBe(urlrols);
            driver.Navigate().Refresh();

            browserOps.UrlToBe(urlrols);
            role.BtnNewRole.Click();

            browserOps.SwitchTo();
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/Security/ManageRoles");

            elementOps.ExistsId("txtRoleName");
            role_name = rl.ltdlocrole + id.GetId;
            role.RoleName.SendKeys(role_name);
            role.RoleDesc.SendKeys(rl.description);
            role.SlctApp.Click();
            role.SlctAppOpt.Click();
            browserOps.implicitWait(5);

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[1]/a");
            role.TabSet.Click();

            //elementOps.ExistsXpath("//*[@id='settings']/div[2]/div/div/label[2]");
            //role.RolLocs.Click();
            //role.Loc1.Click();
            //role.Loc2.Click();
            //role.Loc3.Click();

            actions.MoveToElement(role.TabPermsn).Perform();
            role.TabPermsn.Click();

            role.TabPermsn.Click();
            elementOps.ExistsId("aWebForm");
            role.Webfrm.Click();
            browserOps.implicitWait(5);
            role.Frm1P2.Click();
            role.Frm2P1.Click();
            role.Frm2P2.Click();
            browserOps.implicitWait(5);
            role.Webfrm.Click();
            role.Webfrm.Displayed.Equals(false);
            browserOps.implicitWait(100);

            role.TVis.Displayed.Equals(true);
            role.TVis.Click();
            role.TVis2.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[3]/a");
            role.TabSubRols.Click();
            elementOps.ExistsId("btnAddModalAdd_Roles");
            role.BtnAddRols.Click();
            elementOps.ExistsId("txtSearchAdd_Roles");
            role.SrchRols.SendKeys("Test Role");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Roles']/div[2]/div[1]/input");
            role.Rol1.Click();
            elementOps.ExistsId("btnModalOkAdd_Roles");
            role.BtnbOkAdd_Rols.Click();

            elementOps.ExistsXpath("//*[@id='ulTabOnMngRole']/li[4]");
            role.TabUsrs.Click();
            elementOps.ExistsId("btnAddModalAdd_Users");
            role.BtnAddUser.Click();
            elementOps.ExistsId("txtSearchAdd_Users");
            role.SrchUser.Click();
            role.SrchUser.SendKeys("Jos");
            browserOps.implicitWait(50);
            browserOps.SwitchTo();
            elementOps.ExistsXpath("//*[@id='divSearchResultsAdd_Users']/div[4]/div[1]/input");
            role.Usr2.Click();
            elementOps.ExistsId("btnModalOkAdd_Users");
            role.BtnOkAdd_Usrs.Click();

            elementOps.ExistsId("btnSaveAll");
            role.BtnSave.Click();
            elementOps.ExistsXpath("//*[@id='eb_dlogBox_container']/div/div[3]/button");
            role.BtnDlgBoxOk.Click();
            Console.WriteLine("New Role With Limited Access is Created....");
            browserOps.UrlToBe(urlrols);
            browserOps.Refresh();
        }

        private static List<EbTestItem> Roles()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\RoleRelatedTestCase.xml");
        }
    }
}
