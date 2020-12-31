using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Security.UserCreation;

namespace UITests.TestCases.User.Security
{
    [TestFixture]
    public class LoginActivityTestCase : BaseClass
    {
        UserLogin uln;
        Users usr;
        public void UserLogin()
        {
            uln = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.site/");
            uln.UserName.SendKeys("anoopa.baby@expressbase.com");
            uln.Password.SendKeys("Qwerty@123");
            uln.LoginButton.Click();
            Console.WriteLine("Login Success");
            browserOps.UrlToBe("https://uitesting.eb-test.site/UserDashBoard");
        }

        [Property("TestCaseId", "LoginActivity_CheckLoginActivity_001")]
        [Test]
        public void CheckLoginActivity()
        {
            usr = new Users(driver);
            UserLogin();
            browserOps.Goto("https://uitesting.eb-test.site/Security/LoginActivity");

            elementOps.ExistsXpath("//*[@id=\"activity_table\"]/tbody/tr[1]");
            int val1 = elementOps.GetTableRowCount("//*[@id=\"activity_table\"]/tbody/tr");
            Assert.True(0 < val1, "Success", "Success");
        }
    }
}
