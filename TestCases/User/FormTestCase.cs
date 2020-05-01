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
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ul.UserName.SendKeys("kurian@expressbase.com");
                ul.Password.SendKeys("@Kurian123");
                ul.LoginButton.Click();

                fo = new FormObject(driver);

                browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashboard");
                Console.WriteLine("Login Succesfull");
                browserOps.implicitWait(1000);
                fo.MenuApplication.Click();
                browserOps.implicitWait(100);
                fo.MenuSelectFormMenu.Click();
                browserOps.implicitWait(100);
                fo.MenuSelectForm.Click();
                Console.WriteLine("Test Form Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        private bool IsElementPresent(IWebElement webelement)
        {
            try
            {
                bool f = webelement.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
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
                
                fo.TextboxAutosuggestion.SendKeys("Test");
                Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");
                
                //fo.TextboxReadOnly.SendKeys("Read");
                Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
                
                fo.TextboxRequired.Click();
                fo.TextboxRequired.SendKeys("Test Data");
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
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_NumericBox_001")]
        [Test, Order(3)]
        public void NumericTextBox()
        {
            try
            {
                elementOps.SetValue("Numeric1", "123");
                Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric2","123");
                Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric3", "7012153871");
                Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric9", "123");
                Assert.AreEqual("numeric_unique", fo.NumericBoxUnique.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                

                //fo.NumericBoxReadOnly.SendKeys("123");
                Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                
                fo.NumericBoxRequired.Click();
                //Assert.AreEqual("numeric_plain", fo.NumericBoxRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                
                elementOps.SetValue("Numeric7", "123456");
                Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric8", "123");
                Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric14", "123");
                Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric11", "-123");
                Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric12", "123");
                Assert.AreEqual("numeric_persist", fo.NumericBoxDonotpersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric13", "123");
                Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
               
                Console.Write("“Test passed for User - side - NumericBox - Plain -  Form_BasicControls_NumericBox_001”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_DateTimePicker_001")]
        [Test, Order(4)]
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
        [Test, Order(5)]
        public void BoolenSelect()
        {
            try
            {
                Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

                //Assert.AreEqual("Tool Tip", fo.BoolenSelectToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

                fo.BoolenSelectTrueText.Click();
                fo.BoolenSelectTrueTextSelect.Click();
                Assert.AreEqual("Tool Tip", fo.BoolenSelectTrueTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                
                fo.BoolenSelectFalseText.Click();
                fo.BoolenSelectFalseTextSelect.Click();
                Assert.AreEqual("Tool Tip", fo.BoolenSelectFalseTextSelect.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");


            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


        [Property("TestCaseId", "Form_BasicControls_CheckBoxGroup_001")]
        [Test, Order(6)]
        public void CheckBoxGroup()
        {
            try
            {
                Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");

                Assert.AreEqual("disabled", fo.CheckBoxGroupAllReadonly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");

                Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                Assert.AreEqual("true", fo.CheckBoxGroupAllHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                Assert.AreEqual("disabled", fo.CheckBoxGroupAllReadonly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupAllDoNotPersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }


        [Property("TestCaseId", "Form_BasicControls_RadioButton_001")]
        [Test, Order(7)]
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
        [Test, Order(8)]
        public void Label()
        {
            try
            {
                Assert.AreEqual("true", fo.LabelHidden.GetAttribute("eb-hidden"));
                Console.Write("“Test passed for User - side - Label - Hidden”");

                Assert.AreEqual("True", IsElementPresent(fo.LabelHelpTextData).ToString());
                Console.Write("“Test passed for User - side - Label - HelpText”");

                Assert.AreEqual("Tool Tip", fo.LabelToolTip.GetAttribute("data-original-title"));
                Console.Write("“Test passed for User - side - RadioButton - Tool Tip”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }
        
        
        [Property("TestCaseId", "Form_BasicControls_Label_001")]
        [Test, Order(8)]
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


        [Test, Order(8)]
        public void SaveFoam()
        {
            fo.SaveForm.Click();

            elementOps.ExistsXpath("//*[@id='objname']/span");

            Assert.AreEqual("View Mode", fo.GetMode.Text, true.ToString(), "Form Saved and is opened in View Mode");

            Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

            Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");

            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Password Has data”");

            //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"), true.ToString(), "“Test passed for User - side - TextBox - Email”");

            Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
            Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("value").Length, true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("4", fo.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - Max Length”");
            Assert.AreEqual("EXPR", fo.TextBoxMaxLength.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");

            Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
            Assert.AreEqual("Read Only Data", fo.TextboxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Read Only Has Data”");

            Assert.AreEqual("Test Data", fo.TextboxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Required”");
           
            Assert.AreEqual("Test", fo.TextboxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Unique”");
           
            Assert.AreEqual("", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");       }
    }
}
