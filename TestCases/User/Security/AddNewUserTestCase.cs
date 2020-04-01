using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.TempMail;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security.UserCreation;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class AddNewUserTestCase
    {
        IWebDriver driver;
        GetTempMail tm;
        UserLogin ul;
        Users usr;
        AddNewUser nu;
        ChooseRoles r;
        ChooseGroup g;
        UserLogOut lo;
        BrowserOps browserOps = new BrowserOps();
        string username = null;
        string password = null;
        Boolean islimitexceed = false;

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                tm = new GetTempMail(driver);
                ul = new UserLogin(driver);
                usr = new Users(driver);
                nu = new AddNewUser(driver);
                r = new ChooseRoles(driver);
                g = new ChooseGroup(driver);
                lo = new UserLogOut(driver);
            }
        }

        [Test, Order(1)]
        public void GetTempMailId()
        {
            browserOps.Goto("https://www.fakemail.net/");
            browserOps.implicitWait(200);
            tm.DeleteId.Click();
            username = tm.GetEmailId.GetAttribute("innerHTML");
            browserOps.implicitWait(200);
        }

        [Test, Order(2)]
        public void UserLogin()
        {
            browserOps.implicitWait(200);
            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            ul.UserName.SendKeys("venel38383@wwrmails.com");
            ul.Password.SendKeys("@Qwerty123");
            ul.LoginButton.Click();
        }

        [Test, Order(3)]
        public void User()
        {
            browserOps.implicitWait(200);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            usr.ChooseUsers.Click();
        }

        [TestCaseSource("UserData"), Order(4)]
        public void NewUserCreate(dynamic data)
        {
            browserOps.implicitWait(200);
            string url = driver.Url;
            nu.CreateUserButton.Click();
            browserOps.implicitWait(200);
            if (url == driver.Url)
            {
                islimitexceed = true;
            }
            else if (url != driver.Url)
            {
                string emailid_style = nu.EmailId.GetAttribute("style");
                string passwordstyle = nu.Password.GetAttribute("style");
                string confrimpasswordstyle = nu.ConfirmPassword.GetAttribute("style");
                nu.FullName.SendKeys(data.fullname);
                nu.NickName.SendKeys(data.nickname);
                nu.EmailId.SendKeys(username);
                nu.Password.SendKeys(data.password);
                password = data.password;
                nu.ConfirmPassword.SendKeys(data.confirmpassword);

                r.AddRoleTab.Click();
                browserOps.implicitWait(200);
                r.AddRoleButton.Click();
                browserOps.implicitWait(200);
                r.SolutionOwner.Click();
                r.SolutionAdmin.Click();
                r.RolesOkButton.Click();
                browserOps.implicitWait(200);

                g.AddGroupTab.Click();
                browserOps.implicitWait(200);
                g.AddGroupButton.Click();
                browserOps.implicitWait(200);
                g.TestUserGroup.Click();
                g.ChooseGroupOkButton.Click();
                browserOps.implicitWait(200);

                //if (emailid_style == nu.EmailId.GetAttribute("style") && passwordstyle == nu.Password.GetAttribute("style") && confrimpasswordstyle == nu.ConfirmPassword.GetAttribute("style"))
                //{
                nu.SaveButton.Click();
                browserOps.implicitWait(200);
                nu.SaveOkButton.Click();
                Console.WriteLine("New User Created");
                //}
            }
        }

        [Test, Order(5)]
        public void UserLogoutandLogin()
        {
            if (!islimitexceed)
            {
                browserOps.implicitWait(200);
                lo.ProfileImageDropDown.Click();
                browserOps.implicitWait(200);
                lo.LogoutButton.Click();
                browserOps.implicitWait(200);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
                ul.UserName.SendKeys(username);
                ul.Password.SendKeys(password);
                ul.LoginButton.Click();
            }
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> UserData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestData\User\Security\AddNewUser.xml");
        }
    }
}
