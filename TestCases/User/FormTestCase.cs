﻿using NUnit.Framework;
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

            fo = new FormObject(driver);
        }

        [Test, Order(2)]
        public void TextBox()
        {
            

            //browserOps.UrlToBe("https://uitesting.eb-test.cloud/WebForm/Index?refid=hairocraft_stagging-ebdbjiwavi72zy20200413071346-0-13-13-1419-1594");

            browserOps.implicitWait(1000);
            fo.MenuApplication.Click();
            browserOps.implicitWait(100);
            fo.MenuSelectFormMenu.Click();
            browserOps.implicitWait(100);
            fo.MenuSelectForm.Click();

            fo.TextBoxLowerCase.SendKeys("LOWERCASE");
            Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"));
            Console.Write("“Test passed for User - side - TextBox - lowercase”");

            fo.TextBoxUpperCase.SendKeys("uppercase");
            Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"));
            Console.Write("“Test passed for User - side - TextBox - Uppercase”");

            fo.TextBoxPassword.SendKeys("password");
            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"));
            Console.Write("“Test passed for User - side - TextBox - Password”");

            fo.TextBoxEmail.SendKeys("kurian@expressbase.com");
            //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"));
            //Console.Write("“Test passed for User - side - TextBox - Email”");

            fo.TextBoxMultiLine.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
            Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
            Console.Write("“Test passed for User - side - TextBox - MultiLine”");

            fo.TextBoxMaxLength.SendKeys("EXPRESSbase");
            Assert.AreEqual("4", fo.TextBoxMaxLength.GetAttribute("maxlength"));
            Console.Write("“Test passed for User - side - TextBox - MultiLine”");

            fo.TextboxAutosuggestion.SendKeys("Test");
            Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"));
            Console.Write("“Test passed for User - side - TextBox - Auto Suggestion”");

            //fo.TextboxReadOnly.SendKeys("Read");
            Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"));
            Console.Write("“Test passed for User - side - TextBox - Read Only”");

            fo.TextboxRequired.Click();
            //Assert.AreEqual("3", fo.TextboxRequired.GetAttribute("rows"));
            //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

            fo.TextboxUnique.SendKeys("Test");
            //Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
            //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

            fo.TextboxDoNotPersist.SendKeys("Do Not Persist");
            //Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
            //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

            Console.Write("“Test passed for User - side - TextBox - Form_BasicControls_TextBox_001”");

        }

        [Test, Order(3)]
        public void NumericTextBox()
        {
            fo.NumericBox.SendKeys(123456 + "");
            Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxCurrency.SendKeys(123456 + "");
            Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxPhone.SendKeys("7012153871");
            Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxUnique.SendKeys(123456 + "");
            Assert.AreEqual("numeric_unique", fo.NumericBoxUnique.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            //fo.NumericBoxReadOnly.SendKeys("123");
            Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxRequired.Click();
            //Assert.AreEqual("numeric_plain", fo.NumericBoxRequired.GetAttribute("name"));
            //Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxMax.SendKeys(123456 + "");
            Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxMin.SendKeys(123 + "");
            Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxTooltip.SendKeys(123456 + "");
            Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxNegative.SendKeys(-123456 + "");
            Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxDonotpersist.SendKeys(123456 + "");
            Assert.AreEqual("numeric_persist", fo.NumericBoxDonotpersist.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");

            fo.NumericBoxHelpText.SendKeys(123456 + "");
            Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"));
            Console.Write("“Test passed for User - side - NumericBox - Plain”");
            
            Console.Write("“Test passed for User - side - NumericBox - Plain -  Form_BasicControls_NumericBox_001”");
        }

        [Test, Order(4)]
        public void dateTimePicker()
        {
            fo.Date.Click();
            browserOps.implicitWait(1000);
            fo.SelectDate.Click();
            //Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"));
            //Console.Write("“Test passed for User - side - NumericBox - Plain”");
        }
    }
}
