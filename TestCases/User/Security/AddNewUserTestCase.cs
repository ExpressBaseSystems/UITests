using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        WebDriverWait wait;
        WebElementOps elementOps;
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
            wait = browserOps.DriverWait();
            elementOps = new WebElementOps(driver, wait);
        }
        
        public void GetTempMailId()
        {
            browserOps.Goto("https://tempail.com/en/");
            browserOps.implicitWait(50);
            tm.DeleteId.Click();
            username = tm.GetEmailId.GetAttribute("value");
            Console.WriteLine("EmailId : "+username);
            browserOps.implicitWait(50);
        }
        
        public void UserLogin()
        {
            browserOps.implicitWait(50);
            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            browserOps.implicitWait(50);
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
            browserOps.implicitWait(50);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(50);
            string url = driver.Url;
            nu.CreateUserButton.Click();
            browserOps.implicitWait(200);
            if (!IsElementPresent())
            {
                Console.WriteLine("Inside New User Creation");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                string emailid_style = nu.EmailId.GetAttribute("style");
                string passwordstyle = nu.Password.GetAttribute("style");
                string confrimpasswordstyle = nu.ConfirmPassword.GetAttribute("style");
                Console.WriteLine(data.fullname);
                nu.FullName.SendKeys(data.fullname);
                Console.WriteLine("Name Entered");
                nu.NickName.SendKeys(data.nickname);
                nu.EmailId.SendKeys(username);
                nu.Password.SendKeys(data.password);
                password = data.password;
                nu.ConfirmPassword.SendKeys(data.confirmpassword);

                nu.AddRoleTab.Click();
                browserOps.implicitWait(50);
                nu.AddRoleButton.Click();
                browserOps.implicitWait(50);
                nu.SolutionOwner.Click();
                nu.SolutionAdmin.Click();
                nu.RolesOkButton.Click();
                browserOps.implicitWait(50);

                nu.AddGroupTab.Click();
                browserOps.implicitWait(50);
                nu.AddGroupButton.Click();
                browserOps.implicitWait(50);
                nu.TestUserGroup.Click();
                nu.ChooseGroupOkButton.Click();
                browserOps.implicitWait(50);

                //if (emailid_style == nu.EmailId.GetAttribute("style") && passwordstyle == nu.Password.GetAttribute("style") && confrimpasswordstyle == nu.ConfirmPassword.GetAttribute("style"))
                //{
                nu.SaveButton.Click();
                browserOps.implicitWait(50);
                nu.SaveOkButton.Click();
                Console.WriteLine("New User Created");
                //}

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                lo.ProfileImageDropDown.Click();
                browserOps.implicitWait(50);
                lo.LogoutButton.Click();
                browserOps.implicitWait(50);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                browserOps.Goto("https://ebdbfpdd7vsmq220200403120032.eb-test.cloud/");
                ul.UserName.SendKeys(username);
                ul.Password.SendKeys(password);
                ul.LoginButton.Click();
            }
        }

        [TestCaseSource("UserData")]
        public void EditUserData(dynamic data)
        {
            UserLogin();
            browserOps.implicitWait(50);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(50);
            nu.VieworEditIcon.Click();
            browserOps.implicitWait(50);
            //nu.FullName.SendKeys(data.fullname);
            //nu.NickName.SendKeys(data.nickname);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            nu.ResetPasswordButton.Click();
            browserOps.implicitWait(50);
            nu.NewPassword.SendKeys(data.password);
            nu.ConfirmNewPassword.SendKeys(data.password);
            nu.ResetButton.Click();
            Console.WriteLine(nu.Message.GetAttribute("innerHTML"));
            elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

            browserOps.implicitWait(50);
            nu.AddRoleTab.Click();
            browserOps.implicitWait(50);
            nu.EditRoleToggle.Click();
            nu.ViewRole.Click();
            browserOps.implicitWait(10);
            Console.WriteLine(nu.Message.GetAttribute("innerHTML"));
            elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

            browserOps.implicitWait(200);
            nu.EditRoleToggle.Click();
            nu.RemoveRole.Click();
            browserOps.implicitWait(50);
            nu.RemoveRoleOkButton.Click();
            Console.WriteLine("Role Removed");

            browserOps.implicitWait(50);
            nu.AddRoleButton.Click();
            browserOps.implicitWait(50);
            nu.SolutionOwner.Click();
            nu.RolesOkButton.Click();
            browserOps.implicitWait(50);
            Console.WriteLine("Role Created");

            browserOps.implicitWait(50);
            nu.AddGroupTab.Click();
            browserOps.implicitWait(50);
            nu.EditGrupToggle.Click();
            //nu.ViewGrup.Click();
            browserOps.implicitWait(50);
            nu.RemoveGrup.Click();
            browserOps.implicitWait(50);
            nu.RemoveGrupOkButton.Click();
            Console.WriteLine("Group Removed");

            browserOps.implicitWait(50);
            nu.AddGroupTab.Click();
            browserOps.implicitWait(50);
            nu.AddGroupButton.Click();
            browserOps.implicitWait(50);
            nu.TestUserGroup.Click();
            nu.ChooseGroupOkButton.Click();
            browserOps.implicitWait(50);

            nu.SaveButton.Click();
            browserOps.implicitWait(50);
            nu.SaveOkButton.Click();
            Console.WriteLine("User Edit Success");

        }

        [Test]
        public void DeleteUser()
        {
            UserLogin();
            browserOps.implicitWait(50);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(50);
            nu.VieworEditIcon.Click();
            Console.WriteLine("View / Edit Clicked");
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            nu.DeleteUserButton.Click();
            Console.WriteLine("Delete Button Clicked");
            browserOps.implicitWait(50);
            nu.DeleteUserYesButton.Click();
            Console.WriteLine("Delete Yes Button Clicked");
            nu.DeleteUserOkButton.Click();
            Console.WriteLine("Delete Ok Button Clicked");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            browserOps.Refresh();
        }

        [Test]
        public void LoginActivity()
        {
            UserLogin();
            browserOps.implicitWait(50);
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            browserOps.implicitWait(50);
            nu.VieworEditIcon.Click();
            Console.WriteLine("View / Edit Clicked");
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            nu.LoginActivityTab.Click();
            Console.WriteLine("Login Activity Clicked");
        }

        private bool IsElementPresent()
        {
            try
            {
                bool f = nu.Message.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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
