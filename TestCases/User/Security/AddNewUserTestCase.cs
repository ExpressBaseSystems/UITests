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
        UserRelated nu;
        UserLogOut lo;
        BrowserOps browserOps = new BrowserOps();
        string username = null;
        string password = null;

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
                nu = new UserRelated(driver);
                lo = new UserLogOut(driver);
            }
        }
        
        public void GetTempMailId()
        {
            browserOps.Goto("https://tempail.com/en/");
            browserOps.implicitWait(200);
            tm.DeleteId.Click();
            username = tm.GetEmailId.GetAttribute("value");
            Console.WriteLine("EmailId : "+username);
            browserOps.implicitWait(200);
        }
        
        public void UserLogin()
        {
            browserOps.implicitWait(200);
            browserOps.NewTab("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            ul.UserName.SendKeys("venel38383@wwrmails.com");
            ul.Password.SendKeys("@Qwerty123");
            ul.LoginButton.Click();
            Console.WriteLine("Login Success");
        }
        
        [TestCaseSource("UserData")]
        public void NewUserCreate(dynamic data)
        {
            GetTempMailId();
            UserLogin();
            browserOps.implicitWait(200);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(200);
            string url = driver.Url;
            nu.CreateUserButton.Click();
            browserOps.implicitWait(200);
            if (url != driver.Url)
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

                nu.AddRoleTab.Click();
                browserOps.implicitWait(200);
                nu.AddRoleButton.Click();
                browserOps.implicitWait(200);
                nu.SolutionOwner.Click();
                nu.SolutionAdmin.Click();
                nu.RolesOkButton.Click();
                browserOps.implicitWait(200);

                nu.AddGroupTab.Click();
                browserOps.implicitWait(200);
                nu.AddGroupButton.Click();
                browserOps.implicitWait(200);
                nu.TestUserGroup.Click();
                nu.ChooseGroupOkButton.Click();
                browserOps.implicitWait(200);

                //if (emailid_style == nu.EmailId.GetAttribute("style") && passwordstyle == nu.Password.GetAttribute("style") && confrimpasswordstyle == nu.ConfirmPassword.GetAttribute("style"))
                //{
                nu.SaveButton.Click();
                browserOps.implicitWait(200);
                nu.SaveOkButton.Click();
                Console.WriteLine("New User Created");
                //}

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

        [TestCaseSource("UserData")]
        public void EditUserData(dynamic data)
        {
            UserLogin();
            browserOps.implicitWait(200);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(200);
            nu.VieworEditIcon.Click();
            browserOps.implicitWait(200);
            nu.FullName.SendKeys(data.fullname);
            nu.NickName.SendKeys(data.nickname);
            nu.ResetPasswordButton.Click();
            browserOps.implicitWait(200);
            nu.NewPassword.SendKeys(data.password);
            nu.ConfirmNewPassword.SendKeys(data.password);
            nu.ResetButton.Click();

            browserOps.implicitWait(200);
            nu.AddRoleTab.Click();
            browserOps.implicitWait(200);
            nu.EditRoleToggle.Click();
            nu.ViewRole.Click();

        }
        
        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> UserData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\AddNewUserTestCase.xml");
        }
    }
}
