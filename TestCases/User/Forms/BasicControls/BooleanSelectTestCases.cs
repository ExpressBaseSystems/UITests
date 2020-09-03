using NUnit.Framework;
using OpenQA.Selenium;
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
    class BooleanSelectTestCases : BaseClass
    {
        UserLogin ulog;
        BooleanSelect b;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            b = new BooleanSelect(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-179-179-179-179");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(1)]
        public void BooleanSelect_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect1");
            Assert.Multiple(() =>
            {
                Assert.True(b.BooleanSelect1Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(b.BooleanSelect6Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(2)]
        public void BooleanSelect_TrueText()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect2");
            var selectElement = new SelectElement(b.BooleanSelect2);
            selectElement.SelectByValue("true");
            Assert.True(b.BooleanSelect2Text.GetAttribute("innerHTML").ToString() == "True", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(3)]
        public void BooleanSelect_FalseText()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect3");
            var selectElement = new SelectElement(b.BooleanSelect3);
            selectElement.SelectByValue("false");
            Assert.True(b.BooleanSelect3Text.GetAttribute("innerHTML").ToString() == "False", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(4)]
        public void BooleanSelect_HiddenExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect4");
            Assert.True(b.BooleanSelect4Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(5)]
        public void BooleanSelect_ReadOnlyExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect5");
            Assert.True(b.BooleanSelect5Div.GetAttribute("disabled").ToString() == "true", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(6)]
        public void BooleanSelect_ReadOnly()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect6");
            Assert.True(b.BooleanSelect6Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(7)]
        public void BooleanSelect_Required()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect7");
            Assert.True(elementOps.IsWebElementPresent(b.BooleanSelect7Sup), "Success", "Success");
        }
        //  UNIQUE PENDING

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(8)]
        public void BooleanSelect_Validators()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect9");
            var selectElement = new SelectElement(b.BooleanSelect9);
            selectElement.SelectByValue("false");
            Assert.True(b.BooleanSelect9.GetAttribute("style").ToString() == "width: 100%; background-color: rgb(255, 255, 255); color: rgb(51, 51, 51);", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(9)]
        public void BooleanSelect_DefaultValueExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect10");
            Assert.True(b.BooleanSelect10Text.GetAttribute("innerHTML").ToString() == "Yes", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(10)]
        public void BooleanSelect_ValueExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect11");
            Assert.True(b.BooleanSelect11Text.GetAttribute("innerHTML").ToString() == "Yes", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(11)]
        public void BooleanSelect_DoNotPersist()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect12");
            var selectElement = new SelectElement(b.BooleanSelect9);
            selectElement.SelectByValue("true");
            b.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", b.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(12)]
        public void BooleanSelect_OnChange()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect13");
            var selectElement = new SelectElement(b.BooleanSelect9);
            selectElement.SelectByValue("true");
            b.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", b.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(13)]
        public void BooleanSelect_ViewMode()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect13");
            var selectElement = new SelectElement(b.BooleanSelect9);
            selectElement.SelectByValue("true");
            b.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", b.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.Multiple(() =>
            {
                Assert.True(b.BooleanSelect1.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect2.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect3.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect5.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect6.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect7.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect9.GetAttribute("value").ToString() == "true", "Success", "Success");
                Assert.True(b.BooleanSelect10.GetAttribute("value").ToString() == "true", "Success", "Success");
                Assert.True(b.BooleanSelect11.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect12.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect13.GetAttribute("value").ToString() == "false", "Success", "Success");
            });

        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(13)]
        public void BooleanSelect_EditMode()
        {
            CheckUsrLogin();

            elementOps.ExistsId("BooleanSelect1");
            var selectElement = new SelectElement(b.BooleanSelect9);
            selectElement.SelectByValue("true");
            b.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", b.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            b.EditButton.Click();
            elementOps.ExistsId("BooleanSelect1");

            Assert.Multiple(() =>
            {
                Assert.True(b.BooleanSelect1.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect2.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect3.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect5.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect6.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect7.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect9.GetAttribute("value").ToString() == "true", "Success", "Success");
                Assert.True(b.BooleanSelect10.GetAttribute("value").ToString() == "true", "Success", "Success");
                Assert.True(b.BooleanSelect11.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect12.GetAttribute("value").ToString() == "false", "Success", "Success");
                Assert.True(b.BooleanSelect13.GetAttribute("value").ToString() == "false", "Success", "Success");
            });

        }
    }
}
