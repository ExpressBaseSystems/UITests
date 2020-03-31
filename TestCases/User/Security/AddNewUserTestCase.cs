using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security.UserCreation;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class AddNewUserTestCase
    {
        IWebDriver driver;
        UserLogin ul;
        Users usr;
        AddNewUser nu;
        ChooseRoles r;
        ChooseGroup g;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                usr = new Users(driver);
                nu = new AddNewUser(driver);
                r = new ChooseRoles(driver);
                g = new ChooseGroup(driver);
            }
        }

        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            ul.UserName.SendKeys("venel38383@wwrmails.com");
            ul.Password.SendKeys("@Qwerty123");
            ul.LoginButton.Click();
        }

        [Test, Order(2)]
        public void User()
        {
            browserOps.implicitWait(200);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            //browserOps.implicitWait(300);
            usr.ChooseUsers.Click();
        }

        [TestCaseSource("UserData"), Order(3)]
        public void NewUserCreate(dynamic data)
        {
            browserOps.implicitWait(200);
            nu.CreateUserButton.Click();
            browserOps.implicitWait(200);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string emailid_style = nu.EmailId.GetAttribute("style");
            string passwordstyle = nu.Password.GetAttribute("style");
            string confrimpasswordstyle = nu.ConfirmPassword.GetAttribute("style");
            nu.FullName.SendKeys(data.fullname);
            nu.NickName.SendKeys(data.nickname);
            nu.EmailId.SendKeys(data.emailid);
            nu.Password.SendKeys(data.password);
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

            if (emailid_style == nu.EmailId.GetAttribute("style") && passwordstyle == nu.Password.GetAttribute("style") && confrimpasswordstyle == nu.ConfirmPassword.GetAttribute("style"))
            {
                nu.CreateUserButton.Click();
                Console.WriteLine("New User Created");
            }
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> UserData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\AddNewUser.xml");
        }
    }
}
