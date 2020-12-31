using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security;
using OpenQA.Selenium.Support.UI;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class UserGroupTestCase : BaseClass
    {
        UserLogin uln;
        UserGroupObject ug;
        GetUniqueId UID;
        string UserName;
        string Desp;

        public void UserLogin()
        {
            ug = new UserGroupObject(driver);

            UID = new GetUniqueId();
            UserName = UID.GetId;
            Desp = UID.GetId;

            uln = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.site/");
            uln.UserName.SendKeys("anoopa.baby@expressbase.com");
            uln.Password.SendKeys("Qwerty@123");
            uln.LoginButton.Click();
            Console.WriteLine("Login Success");
            browserOps.UrlToBe("https://uitesting.eb-test.site/UserDashBoard");
        }
        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
        }
       
        [Property("TestCaseId", "User_Secuity_CreateGroup_001")]
        [TestCaseSource("UserGroupObjects"), Order(2)]
        public void CreateUserGroup(dynamic UserGroupObject)
        {
            UserLogin();

            browserOps.implicitWait(300);
            ug.locateUserGroupMenu.Click();
            browserOps.implicitWait(50);
            ug.locateUserGroupInnerMenu.Click();
            browserOps.implicitWait(50);
            ug.CreateUserGroup.Click();
            browserOps.implicitWait(50);



            driver.SwitchTo().Window(driver.WindowHandles.Last());


            browserOps.implicitWait(50);
            ug.Name.SendKeys(UserName);
            ug.Description.SendKeys(UserGroupObject.Description);

            browserOps.implicitWait(50);
            ug.AddUserButton.Click();
            ug.SearchForUser.SendKeys("Ku");
            browserOps.implicitWait(100);
            elementOps.ExistsXpathClickable(ug.SelectUser);
            ug.SelectUser.Click();
            browserOps.implicitWait(100);
            ug.AddSelectedUser.Click();

            browserOps.implicitWait(100);
            ug.ConstrainTab.Click();
            browserOps.implicitWait(100);
            ug.NewIP.Click();
            browserOps.implicitWait(300);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(ug.IpAddress));
            //driver.SwitchTo().ActiveElement();

            //ug.IpAddress.Click(); 
            //ug.IpAddress.Clear();  
            //ug.IpDescription.Clear();
            ug.IpAddress.SendKeys(UserGroupObject.Ip);
            //ug.IpDescription.Click();
            ug.IpDescription.SendKeys(UserGroupObject.IpDescription);
            browserOps.implicitWait(100);
            ug.SaveIp.Click();
            browserOps.implicitWait(300);
            ug.SaveUserGroup.Click();
            browserOps.implicitWait(300);

        }

        [Property("TestCaseId", "User_Secuity_EditGroup_001")]
        [TestCaseSource("UserGroupObjects"), Order(3)]
        public void EditUserGroup(dynamic UserGroupEdit)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.Navigate().Refresh();
            driver.Navigate().Refresh();

           
            
            ug.UserGroupSearch.SendKeys(UserName);
            ug.SelectToEdit.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ug.EditTheFirstUser.Click();
            ug.RemoveFirstUser.Click();
            ug.OkButton.Click();

            browserOps.implicitWait(100);
            ug.ConstrainTab.Click();
            ug.RemoveIpConstrain.Click();
            ug.OkButton.Click();

            ug.SaveUserGroup.Click();
            browserOps.implicitWait(100);
            elementOps.ExistsXpathClickable(ug.OkButton);
            ug.OkButton.Click();
        }


        private static List<EbTestItem> UserGroupObjects()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\UserGroupTestCase.xml");
        }
    }  
}
