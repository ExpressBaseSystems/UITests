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
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            uln.UserName.SendKeys("anoopa.baby@expressbase.com");
            uln.Password.SendKeys("Qwerty@123");
            uln.LoginButton.Click();
            Console.WriteLine("Login Success");
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }
        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
        }

        [Property("TestCaseId", "Security_NewUserCreate_001")]
        [TestCaseSource("UserData"), Order(1)]
        public void NewUserCreate(dynamic data)
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
            //GetTempMailId();
            username = data.emailid + id.GetId + "@test.com";
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

            elementOps.ExistsId("btnNewCmnList");
            string url = driver.Url;
            nu.CreateUserButton.Click();
            browserOps.implicitWait(200);
            //if (!elementOps.IsWebElementPresent(nu.Message))
            //{
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
                elementOps.ExistsId("btnAddModalAdd_Roles");
                nu.AddRoleButton.Click();
                elementOps.ExistsXpath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[1]/div[1]/input");
                nu.SolutionOwner.Click();
                nu.SolutionAdmin.Click();
                nu.RolesOkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[4]/a");

                nu.AddGroupTab.Click();
                elementOps.ExistsId("btnAddModalAdd_User_Group");
                nu.AddGroupButton.Click();
                elementOps.ExistsXpath("//*[@id=\"divSearchResultsAdd_User_Group\"]/div/div[1]/input");
                nu.TestUserGroup.Click();
                nu.ChooseGroupOkButton.Click();
                browserOps.implicitWait(50);

                //if (emailid_style == nu.EmailId.GetAttribute("style") && passwordstyle == nu.Password.GetAttribute("style") && confrimpasswordstyle == nu.ConfirmPassword.GetAttribute("style"))
                //{
                nu.SaveButton.Click();
                elementOps.ExistsName("Ok");
                nu.SaveOkButton.Click();
                Console.WriteLine("New User Created");
                //}

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                lo.ProfileImageDropDown.Click();
                browserOps.implicitWait(50);
                lo.LogoutButton.Click();
                browserOps.implicitWait(50);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                browserOps.Goto("https://uitesting.eb-test.cloud/");
                uln.UserName.SendKeys(username);
                uln.Password.SendKeys(password);
                uln.LoginButton.Click();
                browserOps.Refresh();
                UserLogin();
            //}
            //else
            //{
            //    Console.WriteLine(nu.Message.GetAttribute("innerHTML"));
            //    elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
            //}
        }

        [Property("TestCaseId", "Security_EditUserData_002")]
        [TestCaseSource("UserData"), Order(2)]
        public void EditUserData(dynamic data)
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr[10]/td[10]/i");
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

            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[2]/a");
            nu.AddRoleTab.Click();
            elementOps.ExistsXpath("//*[@id=\"divSelectedDisplayAdd_Roles\"]/div[1]/div/div[3]/div/i");
            nu.EditRoleToggle.Click();
            nu.ViewRole.Click();
            browserOps.implicitWait(10);
            Console.WriteLine(nu.Message.GetAttribute("innerHTML"));
            elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            
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

        [Property("TestCaseId", "Security_DeleteUser_003")]
        //[Test, Order(6)]
        public void DeleteUser()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            CheckUsrLogin();
            //usr.MenuButton.Click();
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseUsers.Click();
            Console.WriteLine("Users");

            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr[10]/td[10]/i");
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

        [Property("TestCaseId", "Security_LoginActivity_004")]
        [Test, Order(3)]
        public void LoginActivity()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            CheckUsrLogin();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr[10]/td[10]/i");
            nu.VieworEditIcon.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            nu.LoginActivityTab.Click();
            elementOps.ExistsXpath("//*[@id=\"activity_table\"]/tbody/tr[1]");
            int val1 = elementOps.GetTableRowCount("//*[@id=\"activity_table\"]/tbody/tr");
            Assert.True(0 < val1, "Success", "Success");
        }

        [Property("TestCaseId", "Security_SuspendUser_005")]
        [Test, Order(4)]
        public void SuspendUser()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr[10]/td[10]/i");
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
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/");
            
            string url = driver.Url;
            uln.UserName.SendKeys(emailid);
            uln.Password.SendKeys("Qwerty@123");
            uln.LoginButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            UserLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

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
            //browserOps.Refresh();
        }

        [Property("TestCaseId", "Security_TerminateUser_006")]
        [Test, Order(5)]
        public void TerminateUser()
        {
            usr = new Users(driver);
            nu = new UserRelated(driver);
            lo = new UserLogOut(driver);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

            elementOps.ExistsXpath("//*[@id=\"tblCommonList\"]/tbody/tr[10]/td[10]/i");
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

            browserOps.Goto("https://uitesting.eb-test.cloud/");
            string url = driver.Url;
            uln.UserName.SendKeys(emailid);
            uln.Password.SendKeys("Qwerty@123");
            uln.LoginButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (elementOps.IsWebElementPresent(nu.Message))
                Console.WriteLine(nu.Message.GetAttribute("innerHTML"));

            UserLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/Security/CommonList?type=Users");

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
        }
        
        private static List<EbTestItem> UserData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\Security\UserRelatedTestCase.xml");
        }
    }
}
