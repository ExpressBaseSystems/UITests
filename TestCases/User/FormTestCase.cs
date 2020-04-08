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
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("hairocraft123@gmail.com");
            ul.Password.SendKeys("12345678");
            ul.LoginButton.Click();
        }

        [Test, Order(2)]
        public void SelectForm()
        {
            fo = new FormObject(driver);

            browserOps.implicitWait(1000);
            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/WebForm/Index?refid=hairocraft_stagging-hairocraft_stagging-0-427-531-427-531");
            browserOps.implicitWait(1000);

            fo.DatePickerClick.Click();

            fo.TextBox.SendKeys("Hello");

            fo.SimpleSelect.Click();
            fo.SimpleSelectItemSelect.Click();

            fo.DatePickerCheckBox.Click();

            actions.DoubleClick(fo.PowerSelectClicker);
            fo.PowerSelectItemSelector.Click();
        }
    }
}
