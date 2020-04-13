using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class FormTestCase : BaseClass
    {
        FormObject fo;

        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ul.UserName.SendKeys("kurian@expressbase.com");
            ul.Password.SendKeys("@Kurian123");
            ul.LoginButton.Click();
        }

        [Test, Order(2)]
        public void SelectForm()
        {
            fo = new FormObject(driver);

            browserOps.implicitWait(1000);
            //browserOps.UrlToBe("https://uitesting.eb-test.cloud/WebForm/Index?refid=hairocraft_stagging-ebdbjiwavi72zy20200413071346-0-13-13-1419-1594");
            //browserOps.implicitWait(1000);

            fo.MenuApplication.Click();
            browserOps.implicitWait(100);
            fo.MenuSelectFormMenu.Click();
            browserOps.implicitWait(100);
            fo.MenuSelectForm.Click();

            fo.TextBoxLowerCase.SendKeys("LOWERCASE");
            fo.TextBoxUpperCase.SendKeys("uppercase");
            fo.TextBoxPassword.SendKeys("password");
            fo.TextBoxEmail.SendKeys("kurian@expressbase.com");
            fo.TextBoxMultiLine.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
            fo.TextBoxMaxLength.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
            fo.TextboxAutosuggestion.SendKeys("Test");
        }
    }
}
