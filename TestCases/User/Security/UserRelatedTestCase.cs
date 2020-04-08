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
    public class UserRelatedTestCase : BaseClass
    {
        GetTempMail tm;
        UserLogin uln;
        Users usr;
        UserRelated nu;
        UserLogOut lo;
        string username = null;
        string password = null;
        
        public void GetTempMailId()
        {
            tm = new GetTempMail(driver);
            browserOps.Goto("https://tempail.com/en/");
            browserOps.implicitWait(50);
            tm.DeleteId.Click();
            username = tm.GetEmailId.GetAttribute("value");
            Console.WriteLine("EmailId : " + username);
            browserOps.implicitWait(50);
        }

        public void UserLogin()
        {
            uln = new UserLogin(driver);
            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            uln.UserName.SendKeys("venel38383@wwrmails.com");
            uln.Password.SendKeys("@Qwerty123");
            uln.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        [TestCaseSource("UserData")]
        public void NewUserCreate(dynamic data)
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
            GetTempMailId();
            UserLogin();
            //usr.MenuButton.Click();
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[3]/a");
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            elementOps.ExistsId("btnNewCmnList");
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

                browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
                uln.UserName.SendKeys(username);
                uln.Password.SendKeys(password);
                uln.LoginButton.Click();
            }
        }

        [TestCaseSource("UserData")]
        public void EditUserData(dynamic data)
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
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
            usr = new Users(driver);
            nu = new UserRelated(driver);
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
            usr = new Users(driver);
            nu = new UserRelated(driver);
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

        [Test]
        public void SuspendUser()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
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
            string emailid = nu.EmailId.GetAttribute("value");
            Console.WriteLine(emailid);
            nu.SuspendUser.Click();
            Console.WriteLine("Suspended User Clicked");
            nu.SaveButton.Click();
            browserOps.implicitWait(50);
            nu.SaveOkButton.Click();
            Console.WriteLine("User Save Success");

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            lo.ProfileImageDropDown.Click();
            browserOps.implicitWait(50);
            lo.LogoutButton.Click();
            browserOps.implicitWait(50);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            string url = driver.Url;
            uln.UserName.SendKeys(emailid);
            uln.Password.SendKeys("@Qwerty123");
            uln.LoginButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (IsElementPresent())
                Console.WriteLine(nu.Message.GetAttribute("innerHTML"));

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
            nu.ActivateUser.Click();
            Console.WriteLine("Activate User Clicked");
            nu.SaveButton.Click();
            browserOps.implicitWait(50);
            nu.SaveOkButton.Click();
            Console.WriteLine("User Save Success");
            browserOps.Refresh();
        }

        [Test]
        public void TerminateUser()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
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
            string emailid = nu.EmailId.GetAttribute("value");
            Console.WriteLine(emailid);
            nu.TerminateUser.Click();
            Console.WriteLine("Terminate User Clicked");
            nu.SaveButton.Click();
            browserOps.implicitWait(50);
            nu.SaveOkButton.Click();
            Console.WriteLine("User Save Success");

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            lo.ProfileImageDropDown.Click();
            browserOps.implicitWait(50);
            lo.LogoutButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            string url = driver.Url;
            uln.UserName.SendKeys(emailid);
            uln.Password.SendKeys("@Qwerty123");
            uln.LoginButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (driver.Url != url)
                Console.WriteLine("Login Success");
        }

        private bool IsElementPresent()
        {
            nu = new UserRelated(driver);
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
        

        private static List<EbTestItem> UserData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\UserRelatedTestCase.xml");
        }
    }
}
