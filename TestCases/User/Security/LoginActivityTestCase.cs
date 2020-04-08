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
            browserOps.Goto("https://ebdbsmwonmu3ky20200326103301.eb-test.cloud/");
            uln.UserName.SendKeys("venel38383@wwrmails.com");
            uln.Password.SendKeys("@Qwerty123");
            uln.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        [Test]
        public void CheckLoginActivity()
        {
            usr = new Users(driver);
            UserLogin();
            //usr.MenuButton.Click();
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[3]/a");
            usr.ChooseSecurity.Click();
            Console.WriteLine("Security");
            usr.ChooseLoginActivity.Click();
            Console.WriteLine("Login Activity");
        }
    }
}
