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
    class NumericTestCases : BaseClass
    {
        UserLogin ulog;
        Numeric n;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            n = new Numeric(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-172-172-172-172");

        }

        void AddCompleteValue()
        {
            elementOps.SetValue("Numeric1", "1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric2", "1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric3", "8123456789");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric3');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric6", "355");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric6');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric7", "1111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric7');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric8", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric8');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric9", id.GetId); //----------------
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric9');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric10", "111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric10');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric11", "11.2553");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric11');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric12", "-111.25");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric12');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric14", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric14');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric15", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric15');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric16", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric16');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric17", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric17');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric18", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric18');" +
                "element.dispatchEvent(e); ");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(1)]
        public void Numeric_InputMode()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric1");
            Assert.Multiple(() =>
            {
                Assert.True(n.Numeric1.GetAttribute("value").ToString() == "0.00", "Success", "Success");
                Assert.True(n.Numeric2.GetAttribute("value").ToString() == "0.00", "Success", "Success");
                Assert.True(n.Numeric3.GetAttribute("value").ToString() == "0__-___-____", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(2)]
        public void Numeric_NumericTest()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric1");
            elementOps.SetValue("Numeric1", "1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            n.Numeric1.SendKeys(Keys.Tab);
            Assert.True(n.Numeric1.GetAttribute("value").ToString() == "1234.00", "Success", "Success");
            elementOps.SetValue("Numeric1", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric1", "-1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            n.Numeric1.SendKeys(Keys.Tab);
            Assert.True(n.Numeric1.GetAttribute("value").ToString() == "1234.00", "Success", "Success");
            elementOps.SetValue("Numeric1", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric1", "123.45");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            n.Numeric1.SendKeys(Keys.Tab);
            Assert.True(n.Numeric1.GetAttribute("value").ToString() == "123.45", "Success", "Success");
            elementOps.SetValue("Numeric1", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric1", "-123.45");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
            n.Numeric1.SendKeys("-123.45" + Keys.Tab);
            Assert.True(n.Numeric1.GetAttribute("value").ToString() == "123.45", "Success", "Success");
            elementOps.SetValue("Numeric1", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric1');" +
                "element.dispatchEvent(e); ");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(3)]
        public void Numeric_CurrencyTest()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric2");
            elementOps.SetValue("Numeric2", "1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            n.Numeric2.SendKeys(Keys.Tab);
            Assert.True(n.Numeric2.GetAttribute("value").ToString() == "1234.00", "Success", "Success");
            elementOps.SetValue("Numeric2", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric2", "-1234");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            n.Numeric2.SendKeys(Keys.Tab);
            Assert.True(n.Numeric2.GetAttribute("value").ToString() == "1234.00", "Success", "Success");
            elementOps.SetValue("Numeric2", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric2", "123.45");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            n.Numeric2.SendKeys(Keys.Tab);
            Assert.True(n.Numeric2.GetAttribute("value").ToString() == "123.45", "Success", "Success");
            elementOps.SetValue("Numeric2", "");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            elementOps.SetValue("Numeric2", "-123.45");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric2');" +
                "element.dispatchEvent(e); ");
            n.Numeric2.SendKeys(Keys.Tab);
            Assert.True(n.Numeric2.GetAttribute("value").ToString() == "123.45", "Success", "Success");
            n.Numeric2.Clear();
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(4)]
        public void Numeric_PhoneTest()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric3");
            elementOps.SetValue("Numeric3", "8123456789");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric3');" +
                "element.dispatchEvent(e); ");
            n.Numeric3.SendKeys(Keys.Tab);
            Assert.True(n.Numeric3.GetAttribute("value").ToString() == "812-345-6789", "Success", "Success");
            elementOps.SetValue("Numeric3", "-8123456789");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric3');" +
                "element.dispatchEvent(e); ");
            n.Numeric3.SendKeys(Keys.Tab);
            Assert.True(n.Numeric3.GetAttribute("value").ToString() == "812-345-6789", "Success", "Success");
            elementOps.SetValue("Numeric3", "8123456789999");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric3');" +
                "element.dispatchEvent(e); ");
            n.Numeric3.SendKeys(Keys.Tab);
            Assert.True(n.Numeric3.GetAttribute("value").ToString() == "812-345-6789", "Success", "Success");
            elementOps.SetValue("Numeric3", "8123.456789");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric3');" +
                "element.dispatchEvent(e); ");
            n.Numeric3.SendKeys("8123.456789" + Keys.Tab);
            Assert.True(n.Numeric3.GetAttribute("value").ToString() == "812-345-6789", "Success", "Success");
            n.Numeric3.Clear();
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(5)]
        public void Numeric_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric4");
            Assert.Multiple(() =>
            {
                Assert.True(n.Numeric4Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(n.Numeric5Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(6)]
        public void Numeric_Required()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric6");
            Assert.True(elementOps.HasAttribute("Numeric6", "required"), "Success", "Success");
            n.Numeric6.SendKeys(Keys.Tab);
            Assert.True(elementOps.HasAttribute("Numeric6Wraper", "style"), "Success", "Success");
            Assert.True(n.Numeric6Div.GetAttribute("style").ToString() == "border: 1px solid rgb(255, 0, 0);", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(7)]
        public void Numeric_Maximum()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric7");
            elementOps.SetValue("Numeric7", "1111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric7');" +
                "element.dispatchEvent(e); ");
            n.Numeric7.SendKeys(Keys.Tab);
            Assert.True(n.Numeric7.GetAttribute("value").ToString() == "200.00", "Success", "Success");
            elementOps.SetValue("Numeric7", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric7');" +
                "element.dispatchEvent(e); ");
            n.Numeric7.SendKeys(Keys.Tab);
            Assert.True(n.Numeric7.GetAttribute("value").ToString() == "123.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(8)]
        public void Numeric_Minimum()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric8");
            elementOps.SetValue("Numeric8", "700");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric8');" +
                "element.dispatchEvent(e); ");
            n.Numeric8.SendKeys(Keys.Tab);
            Assert.True(n.Numeric8.GetAttribute("value").ToString() == "700.00", "Success", "Success");
            elementOps.SetValue("Numeric8", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric8');" +
                "element.dispatchEvent(e); ");
            n.Numeric8.SendKeys(Keys.Tab);
            Assert.True(n.Numeric8.GetAttribute("value").ToString() == "500.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(9)]
        public void Numeric_Unique()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric9");
            elementOps.SetValue("Numeric9", "111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric9');" +
                "element.dispatchEvent(e); ");
            n.Numeric9.SendKeys(Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("uniq-ok")));
            Assert.True(elementOps.HasAttribute("Numeric9", "uniq-ok"), "Success", "Success");
            Assert.True(n.Numeric9.GetAttribute("uniq-ok").ToString() == "true", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(10)]
        public void Numeric_Validator()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric10");
            elementOps.SetValue("Numeric10", "11");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric10');" +
                "element.dispatchEvent(e); ");
            n.Numeric10.SendKeys(Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("width: 100%; padding: 7px 10px; background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); text-align: right; pointer-events: inherit;\"")));
            Assert.True(n.Numeric10.GetAttribute("value").ToString() == "222.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(11)]
        public void Numeric_DecimalPlaces()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric11");
            elementOps.SetValue("Numeric11", "11.2553");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric11');" +
                "element.dispatchEvent(e); ");
            n.Numeric11.SendKeys(Keys.Tab);
            Assert.True(n.Numeric11.GetAttribute("value").ToString() == "11.255", "Success", "Success");
            elementOps.SetValue("Numeric11", "11.25");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric11');" +
                "element.dispatchEvent(e); ");
            n.Numeric11.SendKeys(Keys.Tab);
            Assert.True(n.Numeric11.GetAttribute("value").ToString() == "11.250", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(12)]
        public void Numeric_Negative()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric12");
            elementOps.SetValue("Numeric12", "111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric12');" +
                "element.dispatchEvent(e); ");
            n.Numeric12.SendKeys(Keys.Tab);
            Assert.True(n.Numeric12.GetAttribute("value").ToString() == "111.00", "Success", "Success");
            elementOps.SetValue("Numeric12", "-111.25");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric12');" +
                "element.dispatchEvent(e); ");
            n.Numeric12.SendKeys(Keys.Tab);
            Assert.True(n.Numeric12.GetAttribute("value").ToString() == "-111.25", "Success", "Success");
            elementOps.SetValue("Numeric12", "-211");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric12');" +
                "element.dispatchEvent(e); ");
            n.Numeric12.SendKeys(Keys.Tab);
            Assert.True(n.Numeric12.GetAttribute("value").ToString() == "-211.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(13)]
        public void Numeric_DefaultValueExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric13");
            Assert.True(n.Numeric13.GetAttribute("value").ToString() == "123.00", "Success", "Success");
            elementOps.SetValue("Numeric13", "111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric13');" +
                "element.dispatchEvent(e); ");
            n.Numeric13.SendKeys(Keys.Tab);
            Assert.True(n.Numeric13.GetAttribute("value").ToString() == "111.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(14)]
        public void Numeric_ValueExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric14");
            Assert.True(n.Numeric14.GetAttribute("value").ToString() == "0.00", "Success", "Success");
            elementOps.SetValue("Numeric14", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric14');" +
                "element.dispatchEvent(e); ");
            n.Numeric14.SendKeys(Keys.Tab);
            Assert.True(n.Numeric14.GetAttribute("value").ToString() == "246.00", "Success", "Success");
            elementOps.SetValue("Numeric14", "111");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric14');" +
                "element.dispatchEvent(e); ");
            n.Numeric14.SendKeys(Keys.Tab);
            Assert.True(n.Numeric14.GetAttribute("value").ToString() == "109.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(15)]
        public void Numeric_DoNotPersist()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric1");
            AddCompleteValue();

            n.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", n.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.True(n.Numeric15.GetAttribute("value").ToString() == "0.00", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(16)]
        public void Numeric_OnChange()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric16");
            elementOps.SetValue("Numeric16", "123");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric16');" +
                "element.dispatchEvent(e); ");
            n.Numeric16.SendKeys(Keys.Tab);
            Assert.True(n.Numeric4Div.Displayed, "Success", "Success");

        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(17)]
        public void Numeric_HideExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric17");
            elementOps.SetValue("Numeric17", "1");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric17');" +
                "element.dispatchEvent(e); ");
            n.Numeric17.SendKeys(Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"false\" style=\"margin: 4px; display: none;\"")));
            Assert.True(n.Numeric17Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(18)]
        public void Numeric_ReadOnlyExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric18");
            elementOps.SetValue("Numeric18", "1");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Numeric18');" +
                "element.dispatchEvent(e); ");
            wait.Until(webDriver => (driver.PageSource.Contains("<div id=\"Numeric18Wraper\" class=\"ctrl-cover\" eb-readonly=\"false\" style=\"pointer-events: none;\" disabled=\"disabled\">")));
            Assert.True(elementOps.HasAttribute("Numeric18", "disabled"), "Success", "Success");
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(19)]
        public void Numeric_ViewMode()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric1");
            AddCompleteValue();

            n.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", n.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.Multiple(() =>
            {
                Assert.True(n.Numeric1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric6.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric12.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric14.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric16.GetAttribute("value").ToString() != "", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Numeric_InputMode_001")]
        [Test, Order(20)]
        public void Numeric_EditMode()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Numeric1");
            AddCompleteValue();

            n.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", n.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            n.EditButton.Click();
            elementOps.ExistsId("Numeric1");

            Assert.Multiple(() =>
            {
                Assert.True(n.Numeric1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric6.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric12.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric14.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(n.Numeric16.GetAttribute("value").ToString() != "", "Success", "Success");
            });
            n.SaveButton.Click();
        }
    }
}
