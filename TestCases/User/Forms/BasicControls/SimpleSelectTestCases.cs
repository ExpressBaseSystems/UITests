using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Forms.BasicControls;

namespace UITests.TestCases.User.Forms.BasicControls
{
    [TestFixture]
    class SimpleSelectTestCases : BaseClass
    {
        UserLogin ulog;
        SimpleSelect s;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            s = new SimpleSelect(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-198-198-198-198");
        }

        [Property("TestCaseId", "SimpleSelect_OptionWithGroup_001")]
        [Test, Order(1)]
        public void SimpleSelect_OptionWithGroup()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect1\"]/optgroup");
            Assert.True(elementOps.IsWebElementPresent(s.SimpleSelect1OptGrp), "Success", "Success");
            var selectElement = new SelectElement(s.SimpleSelect1);
            selectElement.SelectByValue("Option 1");
            Assert.True(s.SimpleSelect1Value.GetAttribute("innerHTML") == "Option 1", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_OptionWithOutGroup_001")]
        [Test, Order(2)]
        public void SimpleSelect_OptionWithOutGroup()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect2\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect2);
            selectElement.SelectByValue("Option 1");
            Assert.True(s.SimpleSelect2Value.GetAttribute("innerHTML") == "Option 1", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_IsDynamic_001")]
        [Test, Order(3)]
        public void SimpleSelect_IsDynamic()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect3\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect3);
            selectElement.SelectByValue("4");
            Assert.True(s.SimpleSelect3Value.GetAttribute("innerHTML") == "Riya V", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(4)]
        public void SimpleSelect_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("cont_SimpleSelect4");
            Assert.Multiple(() =>
            {
                Assert.True(s.SimpleSelect4Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(s.SimpleSelect7Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(5)]
        public void SimpleSelect_HideExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect5\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect5);
            selectElement.SelectByValue("Option 1");
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"false\" style=\"margin: 4px; display: none;\"")));
            Assert.True(s.SimpleSelect5Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(6)]
        public void SimpleSelect_ReadOnlyExpresion()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect6\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect6);
            selectElement.SelectByValue("Option 1");
            wait.Until(webDriver => (driver.PageSource.Contains("data-id=\"SimpleSelect6\" title=\"Option 1\" aria-expanded=\"false\" disabled=\"disabled\" style=\"pointer-events: none; background-color: rgb(243, 243, 243);\"")));
            Assert.True(s.SimpleSelect6SelectButton.GetAttribute("disabled").ToString() == "disabled", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(7)]
        public void SimpleSelect_Required()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect8\"]/option[3]");
            s.SaveButton.Click();
            Assert.True(elementOps.IsWebElementPresent(s.SimpleSelect8Al), "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(8)]
        public void SimpleSelect_Validators()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect10\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect10);
            selectElement.SelectByValue("1");
            s.SaveButton.Click();
            Assert.True(elementOps.IsWebElementPresent(s.SimpleSelect10Al), "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(9)]
        public void SimpleSelect_MultiSelect()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect11\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect11);
            Assert.True(selectElement.IsMultiple, "Success", "Success");
            selectElement.SelectByValue("Option 1");
            selectElement.SelectByValue("Option 2");
            Assert.True(s.SimpleSelect11Value.GetAttribute("innerHTML") == "Option 1, Option 2", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(10)]
        public void SimpleSelect_DefaultValue()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect12\"]/option[3]");
            Assert.True(s.SimpleSelect12Value.GetAttribute("innerHTML") == "ebsimpleselectoption1", "Success", "Success");
        }

        [Property("TestCaseId", "SimpleSelect_Behaviour_001")]
        [Test, Order(10)]
        public void SimpleSelect_OnChange()
        {
            CheckUsrLogin();

            elementOps.ExistsXpath("//*[@id=\"SimpleSelect15\"]/option[3]");
            var selectElement = new SelectElement(s.SimpleSelect15);
            selectElement.SelectByValue("1");
            Assert.True(s.SimpleSelect4Div.GetAttribute("style") == "margin: 4px; display: block;", "Success", "Success");
        }
    }
}
