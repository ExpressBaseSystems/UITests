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
    public class RoleRelatedTestCase
    {
        IWebDriver driver;
        UserLogin ul;
        RoleRelated role;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                role = new RoleRelated(driver);
            }
        }

        // [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("josevin@expressbase.com");
            ul.Password.SendKeys("Qwerty@1");
            ul.LoginButton.Click();
        }

        [TestCaseSource("Roles")]
        public void CreateNewRole(dynamic r)
        {
            UserLogin();
            browserOps.implicitWait(200);
            role.SecurityLink.Click();
            browserOps.implicitWait(5);
            role.RoleLink.Click();
            browserOps.implicitWait(10);

            role.CreateNewRoleBtn.Click();
            browserOps.implicitWait(50);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            role.RoleName.SendKeys(r.rolename + Guid.NewGuid().ToString().Substring(0, 8));
            browserOps.implicitWait(50);

            role.RoleDescription.SendKeys(r.description);
            role.SelectApp.Click();
            role.SelectAppOption.Click();
            browserOps.implicitWait(5);

            role.Permissions.Click();
            browserOps.implicitWait(5);
            role.Webform.Click();
            browserOps.implicitWait(5);
            role.WebForm1PNew.Click();
            role.WebForm1PView.Click();
            role.WebForm1PEdit.Click();
            role.WebForm2PNew.Click();
            role.WebForm2PView.Click();
            browserOps.implicitWait(5);
            role.Webform.Click();
            role.Webform.Displayed.Equals(false);
            browserOps.implicitWait(100);

            role.TableVisualization.Displayed.Equals(true);
            role.TableVisualization.Click();
            role.TableVisualization1.Click();
            role.TableVisualization2.Click();
            browserOps.implicitWait(100);

            role.Users.Click();
            browserOps.implicitWait(100);
            role.AddUsers.Click();
            browserOps.implicitWait(50);
            role.SearchAddUsers.Click();
            role.SearchAddUsers.SendKeys("Jos");
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            browserOps.implicitWait(50);
            role.SearchResult1.Click();
            browserOps.implicitWait(50);
            role.SearchResult2.Click();
            browserOps.implicitWait(50);
            role.OkBtnAddUsers.Click();

            browserOps.implicitWait(50);
            role.BtnSave.Click();
            browserOps.implicitWait(50);
            role.DlogBoxOk.Click();
            Console.WriteLine("New Role Created....");
            browserOps.implicitWait(20);
            browserOps.Goto("https://hairocraft.eb-test.cloud/Security/CommonList?type=Roles");
        }

        [TestCaseSource("Roles")]
        public void EditRole(dynamic er)
        {
            UserLogin();
            browserOps.implicitWait(100);

            role.SecurityLink.Click();
            browserOps.implicitWait(5);
            role.RoleLink.Click();
            browserOps.implicitWait(10);

            role.SelectRole.Click();
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            role.RoleDescription.Clear();
            role.RoleDescription.SendKeys(er.editdesc);

            role.Permissions.Click();
            browserOps.implicitWait(20);
            role.TableVisualization.Click();
            browserOps.implicitWait(20);
            role.TableVisualization3.Click();
            browserOps.implicitWait(100);
            role.TableVisualization.Click();
            browserOps.implicitWait(100);
            role.Users.Click();
            browserOps.implicitWait(100);
            role.AddUsers.Click();
            browserOps.implicitWait(50);
            role.SearchAddUsers.Click();
            role.SearchAddUsers.SendKeys("Jos");
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            browserOps.implicitWait(50);
            role.SearchResult1.Click();
            browserOps.implicitWait(50);
            role.SearchResult3.Click();

            browserOps.implicitWait(50);
            role.OkBtnAddUsers.Click();
            browserOps.implicitWait(50);
            role.BtnSave.Click();
            browserOps.implicitWait(50);
            role.DlogBoxOk.Click();
            Console.WriteLine("Role Edited....");
            browserOps.implicitWait(20);
            browserOps.Goto("https://hairocraft.eb-test.cloud/Security/CommonList?type=Roles");
        }

        private static List<EbTestItem> Roles()
        {
            return GetDataFromXML.GetDataFromFile(@"TestData\User\Security\Roles.xml");
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }
    }
}
