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
    class TextBoxTestCases : BaseClass
    {
        UserLogin ulog;
        TextBox t;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.site/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            t = new TextBox(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.site/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
        }

        public void AddCompleteValues()
        {
            t.TextBox1.SendKeys("Normal Test");
            t.TextBox2.SendKeys("IS LOWERCASE");
            t.TextBox3.SendKeys("is uppercase");
            t.TextBox4.Clear();
            t.TextBox4.SendKeys("Test");
            t.TextBox5.Clear();
            t.TextBox5.SendKeys("password");
            t.TextBox6.SendKeys("abc@lmn.xyz");
            elementOps.SetValue("TextBox7", "#b42727");
            t.TextBox8.SendKeys("Line 1" + Keys.Enter + "Line 2");
            t.TextBox9.SendKeys("Name");
            t.TextBox10.SendKeys("aaaaaaa");
            t.TextBox11.SendKeys("aaaaaaa");
            t.TextBox13.SendKeys("Auto Complete Off");
            t.TextBox15.SendKeys("Required");
            t.TextBox16.SendKeys("Tester" + id.GetId);
            t.TextBox17.SendKeys("Test");
            t.TextBox18.SendKeys(" sss");
            t.TextBox19.SendKeys("sss");
            t.TextBox20.SendKeys("Do not Persist");
            t.TextBox21.SendKeys("On Change");
        }

        [Property("TestCaseId", "TextBox_Transform_001")]
        [Test, Order(1)]
        public void TextBox_Transform()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox1");
            t.TextBox1.SendKeys("Normal Test");
            t.TextBox2.SendKeys("IS LOWERCASE");
            t.TextBox3.SendKeys("is uppercase");
            Console.WriteLine(t.TextBox1.GetAttribute("value").ToString()+"\n"+ t.TextBox2.GetAttribute("value").ToString()+ "\n" + t.TextBox3.GetAttribute("value").ToString());
            Assert.Multiple(() =>
            {
                Assert.True(t.TextBox1.GetAttribute("value").ToString() == "Normal Test", "Success", "Success");
                Assert.True(t.TextBox2.GetAttribute("value").ToString() == "is lowercase", "Success", "Success");
                Assert.True(t.TextBox3.GetAttribute("value").ToString() == "IS UPPERCASE", "Success", "Success");
            });

        }

        [Property("TestCaseId", "TextBox_Mode_001")]
        [Test, Order(2)]
        public void TextBox_Mode()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox4");
            t.TextBox4.Clear();
            Assert.False(elementOps.HasAttribute("TextBox4", "rows"), "Success", "Success");
            t.TextBox4.SendKeys("Test");
            t.TextBox5.Clear();
            Assert.True(t.TextBox5.GetAttribute("type").ToString() == "password", "Success", "Success");
            t.TextBox5.SendKeys("password");
            Assert.True(t.TextBox6.GetAttribute("type").ToString() == "email", "Success", "Success");
            t.TextBox6.SendKeys("abc@lmn.xyz");
            Assert.True(t.TextBox7.GetAttribute("type").ToString() == "color", "Success", "Success");
            elementOps.SetValue("TextBox7", "#b42727");
            Assert.True(elementOps.HasAttribute("TextBox8", "rows"), "Success", "Success");
            t.TextBox8.SendKeys("Line 1" + Keys.Enter + "Line 2");
            elementOps.ExistsId("TextBox9");
            //Assert.True(t.TextBox9.GetAttribute("type").ToString() == "name", "Success", "Success");
            t.TextBox9.SendKeys("Name");

        }

        [Property("TestCaseId", "TextBox_MaxLength_001")]
        [Test, Order(3)]
        public void TextBox_MaxLength()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox10");
            t.TextBox10.SendKeys("aaaaaaa" + Keys.Tab);
            Assert.Multiple(() =>
            {
                Assert.True(elementOps.HasAttribute("TextBox10", "maxlength"), "Success", "Success");
                Assert.True(t.TextBox10.GetAttribute("maxlength").ToString() == "5", "Success", "Success");
                Assert.True(t.TextBox10.GetAttribute("value").ToString() == "aaaaa", "Success", "Success");
            });
        }

        [Property("TestCaseId", "TextBox_AutoSuggestion_001")]
        [Test, Order(4)]
        public void TextBox_AutoSuggestion()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox11");
            t.TextBox11.SendKeys("aaaaaaa" + Keys.Tab);
            Assert.True(t.TextBox11.GetAttribute("class").ToString() == "ui-autocomplete-input", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_Behaviour_001")]
        [Test, Order(5)]
        public void TextBox_Behaviour()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox13");
            t.TextBox13.SendKeys("Auto Complete Off");
            Assert.Multiple(() =>
            {
                Assert.True(t.TextBox12Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(t.TextBox13.GetAttribute("autocomplete").ToString() == "off", "Success", "Success");
                Assert.True(t.TextBox14Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "TextBox_Required_001")]
        [Test, Order(6)]
        public void TextBox_Required()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox15");
            Assert.True(elementOps.HasAttribute("TextBox15", "required"), "Success", "Success");
            t.TextBox15.SendKeys(Keys.Tab);
            Assert.True(elementOps.HasAttribute("TextBox15Wraper", "style"), "Success", "Success");
            Assert.True(t.TextBox15Div.GetAttribute("style").ToString() == "border: 1px solid rgb(255, 0, 0);", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_Unique_001")]
        [Test, Order(7)]
        public void TextBox_Unique()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox16");
            t.TextBox16.SendKeys("Testerr" + Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("uniq-ok")));
            Assert.True(elementOps.HasAttribute("TextBox16", "uniq-ok"), "Success", "Success");
            Assert.True(t.TextBox16.GetAttribute("uniq-ok").ToString() == "true", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_Validation_001")]
        [Test, Order(8)]
        public void TextBox_Validation()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox17");
            t.TextBox17.SendKeys("Nil" + Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("style=\"width: 100%; display: inline-block; padding: 7px 10px; background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); pointer-events: inherit;\"")));
            Assert.True(t.TextBox17.GetAttribute("value").ToString() == "Hello", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_DefaultValueExpression_001")]
        [Test, Order(9)]
        public void TextBox_DefaultValueExpression()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox18");
            Assert.True(t.TextBox18.GetAttribute("value").ToString() == "Sample", "Success", "Success");
            t.TextBox18.SendKeys(" sss" + Keys.Tab);
            Assert.True(t.TextBox18.GetAttribute("value").ToString() == "Sample sss", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_ValueExpression_001")]
        [Test, Order(10)]
        public void TextBox_ValueExpression()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox19");
            Assert.True(t.TextBox19.GetAttribute("value").ToString() == "", "Success", "Success");
            t.TextBox19.SendKeys("sss" + Keys.Tab);
            Assert.True(t.TextBox19.GetAttribute("value").ToString() == "Success", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_DoNotPersist_001")]
        [Test, Order(11)]
        public void TextBox_DoNotPersist()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox1");
            AddCompleteValues();

            t.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", t.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.True(t.TextBox20.GetAttribute("value").ToString() == "", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_OnChange_001")]
        [Test, Order(12)]
        public void TextBox_OnChange()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox21");
            t.TextBox21.SendKeys("sss" + Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"true\" style=\"margin: 4px; display: none;\"")));
            Assert.True(t.TextBox14Div.GetAttribute("style") == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_HideExpression_001")]
        [Test, Order(13)]
        public void TextBox_HideExpression()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox22");
            t.TextBox22.SendKeys("Hello" + Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"false\" style=\"margin: 4px; display: none;\"")));
            Assert.True(t.TextBox22Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_ReadOnlyExpression_001")]
        [Test, Order(14)]
        public void TextBox_ReadOnlyExpression()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox23");
            t.TextBox23.SendKeys("Hello" + Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("<div id=\"TextBox23Wraper\" class=\"ctrl-cover\" eb-readonly=\"false\" disabled=\"disabled\" style=\"pointer-events: inherit;\">")));
            Assert.True(elementOps.HasAttribute("TextBox23", "disabled"), "Success", "Success");
        }

        [Property("TestCaseId", "TextBox_ViewMode_001")]
        [Test, Order(15)]
        public void TextBox_ViewMode()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox1");
            AddCompleteValues();

            t.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", t.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.Multiple(() =>
            {
                Assert.True(t.TextBox1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox4.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox5.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox6.GetAttribute("value").ToString() != "", "Success", "Success");
                //Assert.True(t.TextBox7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox16.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox17.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox18.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox19.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox20.GetAttribute("value").ToString() == "", "Success", "Success");
                Assert.True(t.TextBox21.GetAttribute("value").ToString() != "", "Success", "Success");
            });
        }

        [Property("TestCaseId", "TextBox_EditMode_001")]
        [Test, Order(16)]
        public void TextBox_EditMode()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-169-169-169-169");
            elementOps.ExistsId("TextBox1");
            AddCompleteValues();

            t.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", t.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            t.EditButton.Click();
            elementOps.ExistsId("TextBox1");

            Assert.Multiple(() =>
            {
                Assert.True(t.TextBox1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox4.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox5.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox6.GetAttribute("value").ToString() != "", "Success", "Success");
                //Assert.True(t.TextBox7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox16.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox17.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox18.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox19.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(t.TextBox20.GetAttribute("value").ToString() == "", "Success", "Success");
                Assert.True(t.TextBox21.GetAttribute("value").ToString() != "", "Success", "Success");
            });
            t.SaveButton.Click();
        }
    }
}
