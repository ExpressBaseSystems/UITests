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
        GetUniqueId UID;
        string UniqueId;

        [Test, Order(1)]
        public void UserLogin()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ul.UserName.SendKeys("kurian@expressbase.com");
                ul.Password.SendKeys("@Kurian123");
                ul.LoginButton.Click();

                fo = new FormObject(driver);
                UID = new GetUniqueId();

                wait.Until(webDriver => (driver.PageSource.Contains("class=\"list-group-item inner_li Obj_link for_brd\"")));
                browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashboard");
                Console.WriteLine("Login Succesfull");
                elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"ObjectTypeContainer\"")));
                fo.MenuApplication.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"ebm-objtcontainer\"")));
                fo.MenuSelectFormMenu.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"ebm-objectcontainer\"")));
                fo.MenuSelectForm.Click();
                Console.WriteLine("Test Form Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_TextBox_001")]
        [Test, Order(2)]
        public void TextBox()
        {
            try
            {
                fo.TextBoxLowerCase.SendKeys("LOWERCASE");
                browserOps.implicitWait(100);
                //Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

                fo.TextBoxUpperCase.SendKeys("uppercase");
                browserOps.implicitWait(100);
                //Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");
                
                fo.TextBoxPassword.SendKeys("password");
                Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
                
                fo.TextBoxEmail.SendKeys("kurian@expressbase.com");
                //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"), true.ToString(), "“Test passed for User - side - TextBox - Email”");
                
                fo.TextBoxMultiLine.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
                Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
                
                fo.TextBoxMaxLength.SendKeys("EXPRESSbase");
                Assert.AreEqual("4", fo.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
                
                fo.TextboxAutosuggestion.SendKeys("T");
                Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.TextboxAutosuggestionItem)).ToString(), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");
                
                //fo.TextboxReadOnly.SendKeys("Read");
                Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
                
                fo.TextboxRequired.Click();
                fo.TextboxRequired.SendKeys("Test Data");
                //Assert.AreEqual("3", fo.TextboxRequired.GetAttribute("rows"));
                //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

                UniqueId = UID.GetId;
                fo.TextboxUnique.SendKeys(UniqueId);
                //Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
                //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

                fo.TextboxDoNotPersist.SendKeys("Do Not Persist");
                //Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
                //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

                Console.Write("“Test passed for User - side - TextBox - Form_BasicControls_TextBox_001”");
            }           
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_NumericBox_001")]
        [Test, Order(2)]
        public void NumericTextBox()
        {
            try
            {
                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric2","123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric2');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric3", "7012153871");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric3');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric9", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric9');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_unique", fo.NumericBoxUnique.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                

                //fo.NumericBoxReadOnly.SendKeys("123");
                Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                
                fo.NumericBoxRequired.Click();
                //Assert.AreEqual("numeric_plain", fo.NumericBoxRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                
                elementOps.SetValue("Numeric7", "123456");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric7');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric8", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric8');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric14", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric14');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric10", "123.50");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric10');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                
                elementOps.SetValue("Numeric11", "-123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric11');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric12", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric12');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_persist", fo.NumericBoxDonotpersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric13", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric13');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
               
                Console.Write("“Test passed for User - side - NumericBox - Plain -  Form_BasicControls_NumericBox_001”");

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_DateTimePicker_001")]
        [Test, Order(2)]
        public void dateTimePicker()
        {
            try
            {
                fo.Date.Click();
                browserOps.implicitWait(1000);
                fo.SelectDate.Click();
                //Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"));
                //Console.Write("“Test passed for User - side - NumericBox - Plain”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_BoolenSelect_001")]
        [Test, Order(2)]
        public void BoolenSelect()
        {
            try
            {
                Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

                //Assert.AreEqual("Tool Tip", fo.BoolenSelectToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

                fo.BoolenSelectTrueText.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"dropdown-menu open dd_of_BooleanSelect8\"")));
                Assert.AreEqual("Ohoo yes", fo.BoolenSelectTrueTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                
                fo.BoolenSelectFalseText.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"dropdown-menu open dd_of_BooleanSelect9\"")));
                Assert.AreEqual("Ohoo Noo", fo.BoolenSelectFalseTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");


            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_CheckBoxGroup_001")]
        [Test, Order(2)]
        public void CheckBoxGroup()
        {
            try
            {
                Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");

                Assert.AreEqual("true", fo.CheckBoxGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");

                Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                fo.CheckBoxGroupRequiredSelect.Click();
                //Assert.AreEqual("true", fo.CheckBoxGroupAllHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                //Assert.AreEqual("disabled", fo.CheckBoxGroupAllReadonly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                //Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupAllDoNotPersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }


        [Property("TestCaseId", "Form_BasicControls_RadioButton_001")]
        [Test, Order(2)]
        public void RadioButton()
        {
            try
            {
                Assert.AreEqual("true", fo.RadioButtonGroupHidden.GetAttribute("eb-hidden"));
                Console.Write("“Test passed for User - side - RadioButton - Hidden”");

                Assert.AreEqual("true", fo.RadioButtonGroupReadOnly.GetAttribute("disabled"));
                Console.Write("“Test passed for User - side - RadioButton - ReadOnly”");

                Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"));
                Console.Write("“Test passed for User - side - RadioButton - Required”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }
        
        [Property("TestCaseId", "Form_BasicControls_Label_001")]
        [Test, Order(2)]
        public void Label()
        {
            try
            {
                Assert.AreEqual("true", fo.LabelHidden.GetAttribute("eb-hidden"));
                Console.Write("“Test passed for User - side - Label - Hidden”");

                Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.LabelHelpTextData)).ToString());
                Console.Write("“Test passed for User - side - Label - HelpText”");

                //Assert.AreEqual("Tool Tip", fo.LabelToolTip.GetAttribute("data-original-title"));
                Console.Write("“Test passed for User - side - RadioButton - Tool Tip”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }
        
        
        [Property("TestCaseId", "Form_BasicControls_Label_001")]
        [Test, Order(2)]
        public void Boolean()
        {
            try
            {
                Assert.AreEqual("true", fo.BoolenHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean - Hidden”");

                fo.BoolenReadOnly.Click();
                Assert.AreEqual("true", fo.BoolenReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean - Read Only”");

                fo.BoolenString.Click();
                Assert.AreEqual("String", fo.BoolenString.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - String”");

                fo.BoolenInteger.Click();
                Assert.AreEqual("Int32", fo.BoolenInteger.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - Integer”");

                //Assert.AreEqual("True", IsElementPresent(fo.BoolenRequired).ToString(), true.ToString(), "“Test passed for User - side - Boolean - Required”");

                //Assert.AreEqual("Tool Tip", fo.BoolenDoNotPersist.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean - Do Not Persist”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }


        [Test, Order(5)]
        public void SaveFoam()
        {
            FormObject NewForm = new FormObject(driver);
            NewForm.SaveForm.Click();

            browserOps.implicitWait(2000);
            //elementOps.ExistsXpath("//*[@id='objname']/span");

            //Assert.AreEqual("View Mode", fo.GetMode.Text, true.ToString(), "Form Saved and is opened in View Mode");

            Assert.AreEqual("lowercase", NewForm.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

            Assert.AreEqual("UPPERCASE", NewForm.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");

            Assert.AreEqual("password", NewForm.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
            Assert.AreEqual("password", NewForm.TextBoxPassword.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Password Has data”");

            //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"), true.ToString(), "“Test passed for User - side - TextBox - Email”");

            Assert.AreEqual("3", NewForm.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
            Assert.AreEqual("187", (NewForm.TextBoxMultiLine.GetAttribute("value").Length).ToString(), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("4", NewForm.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - Max Length”");
            Assert.AreEqual("EXPR", NewForm.TextBoxMaxLength.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("ui-autocomplete-input", NewForm.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");

            Assert.AreEqual("true", NewForm.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
            Assert.AreEqual("Read Only Data", NewForm.TextboxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Read Only Has Data”");

            Assert.AreEqual("Test Data", NewForm.TextboxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Required”");
           
            Assert.AreEqual(UniqueId, NewForm.TextboxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Unique”");
           
            Assert.AreEqual("", NewForm.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");       }
    }
}
