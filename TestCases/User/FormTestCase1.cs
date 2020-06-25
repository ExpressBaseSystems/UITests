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
    public class FormTestCase1 : BaseClass
    {
        FormObject fo;
       // UserLogin ul;
        GetUniqueId UID;
        string UniqueId;



        public void Userlogin(IWebDriver Driver)
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ul.UserName.SendKeys("kurian@expressbase.com");
                ul.Password.SendKeys("@Kurian123");
                ul.LoginButton.Click();

                UID = new GetUniqueId();

                wait.Until(webDriver => (Driver.PageSource.Contains("class=\"list-group-item inner_li Obj_link for_brd\"")));
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=hairocraft_stagging-ebdbjiwavi72zy20200413071346-0-13-13-1419-1594");
                Console.WriteLine("Login Succesfull");
                fo = new FormObject(Driver);
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!  " + e.Message + "Stack Trace" + e.StackTrace);
            }
        }

        public void FormSelect(int FormID, IWebDriver Driver)
        {

            
            browserOps.implicitWait(1);
            elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
            fo.MenuApplication.Click();
            browserOps.implicitWait(1);

            actions.MoveToElement(fo.MenuSelectFormMenu).Perform();
            elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[1]");
            fo.MenuSelectFormMenu.Click();
            browserOps.implicitWait(1);
            if (FormID == 1)
            {
                actions.MoveToElement(fo.MenuSelectForm1).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectForm1.Click();
            }else if(FormID == 2)
            {
                actions.MoveToElement(fo.MenuSelectForm2).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectForm2.Click();
            }
            else if(FormID == 3)
            {
                actions.MoveToElement(fo.MenuSelectForm3).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectForm3.Click();
            }
            Console.WriteLine("Test Form Opened");
        }

        [Test, Order(1)]
        public void Funtions()
        {
            Userlogin(driver);
            //FormSelect(1, driver);

            fo.TextBoxLowerCase.SendKeys("LOWERCASE");
            fo.TextBoxLowerCase.Clear();
            actions.MoveToElement(fo.TextBoxShowHidden).Perform();
            fo.TextBoxUpperCase.SendKeys("uppercase");
            fo.TextBoxUpperCase.Clear();


            Assert.AreEqual("margin: 4px; display: none;", fo.TextBoxShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - TextBox - Funtion Hide”", "“Test passed for User - side - TextBox - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.NumericShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Numeric - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.DateShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Date - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.BooleanSelectShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - BooelanSelect - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.CheckboxesShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - CheckBox - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.RadioButtonShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - RadioButton - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.LabelShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Label - Funtion Hide”");
            Assert.AreEqual("margin: 4px; display: none;", fo.BooleanShowHidden.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Boolean - Funtion Hide”");


            Assert.AreEqual("true", fo.TextBoxDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.NumericDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Numeric - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.DateDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Date - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.BooleanSelectDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - BooelanSelect - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.CheckBoxDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Label - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.RadioButtonDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton - Funtion EnableDiable”");
            Assert.AreEqual("true", fo.BooleanDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean - Funtion EnableDiable”");

            Assert.AreEqual("Default Value Expression", fo.TextBoxDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Default Value Expression”");
            Assert.AreEqual("1234.00", fo.NumericDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - Numeric - Default Value Expression”");
            Assert.AreEqual("21-05-2020", fo.DateDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - Date - Default Value Expression”");
            Assert.AreEqual("Yes", fo.BooleanSelectDVE.Text, true.ToString(), "“Test passed for User - side - BooelanSelect - Default Value Expression”");
            // Assert.AreEqual("true", fo.CheckBoxDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Label - Default Value Expression”");
            // Assert.AreEqual("true", fo.RadioButtonDisableEnable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton - Default Value Expression”");
            Assert.AreEqual("on", fo.BooleanDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - Boolean - Default Value Expression”");

            fo.TextBoxMaxLength.SendKeys("kurian@expressbase.com");
            fo.TextboxAutosuggestion.SendKeys("kurian@expressbase.com");
            fo.TextBoxLowerCase.Click();
            fo.CheckBoxGroupOnChangeTrigger.Click();
            fo.RadioButtonOnChangeTrigger.Click();
            fo.BooleanOnChangeTrigger.Click();

            Assert.AreEqual("margin: 4px; display: none;", fo.TextBoxOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
            Assert.AreEqual("true", fo.TextBoxOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion EnableDiable”");
            
            Assert.AreEqual("margin: 4px; display: none;", fo.NumericOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Numeric OnChange- Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
            Assert.AreEqual("true", fo.NumericOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Numeric - OnChangeFuntion EnableDiable”");
            
            Assert.AreEqual("margin: 4px; display: none;", fo.BooleanSelectOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - BooleanSelect OnChange - Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
            Assert.AreEqual("true", fo.BooleanSelectOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - BooleanSelect OnChange- Funtion EnableDiable”");

            Assert.AreEqual("false", fo.CheckBoxGroupOnChangeHideShow.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup -OnChange Funtion Hide”");
            Assert.AreEqual("true", fo.CheckBoxGroupOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup -OnChange Funtion EnableDiable”");

            Assert.AreEqual("false", fo.RadioButtonnChangeHideShow.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange Hidden”");
            Assert.AreEqual("true", fo.RadioButoonOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange ReadOnly”");
            
            Assert.AreEqual("false", fo.BooleanOnChangeHideShow.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean -OnChange Hidden”");
            Assert.AreEqual("true", fo.BooleanOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean -OnChange ReadOnly”");
        }

        //[Property("TestCaseId", "Form_BasicControls_TextBox_001")]
        //[Test, Order(2)]
        public void TextBox()
        {
            try
            {
                fo.TextBoxLowerCase.SendKeys("LOWERCASE");
                fo.TextBoxUpperCase.SendKeys("uppercase");
                Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

                Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");

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

                //fo.TextboxDoNotPersist.SendKeys("Do Not Persist");
                //Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"));
                //Console.Write("“Test passed for User - side - TextBox - MultiLine”");

                Console.Write("“Test passed for User - side - TextBox - Form_BasicControls_TextBox_001”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


     //   [Property("TestCaseId", "Form_BasicControls_NumericBox_001")]
     //   [Test, Order(3)]
        public void NumericTextBox()
        {
            try
            {
                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric2", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric2');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric3", "7012153871");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric3');" +
                    "element.dispatchEvent(e); ");
                Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Numeric9", UniqueId);
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
                Assert.AreEqual("numeric_decimal", fo.NumericBoxDecimal.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

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


      //  [Property("TestCaseId", "Form_BasicControls_DateTimePicker_001")]
        //[Test, Order(4)]
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


      //  [Property("TestCaseId", "Form_BasicControls_BoolenSelect_001")]
     //   [Test, Order(5)]
        public void BoolenSelect()
        {
            try
            {
                Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

                //Assert.AreEqual("Tool Tip", fo.BoolenSelectToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

                browserOps.implicitWait(10);
                fo.BoolenSelectTrueText.Click();
                fo.BoolenSelectTrueText.Click();
                fo.BoolenSelectTrueText.Click();
                //actions.MoveToElement(fo.BoolenSelectTrueTextSelect).Perform();                
                Assert.AreEqual("Ohoo yes", fo.BoolenSelectTrueTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                fo.BoolenSelectTrueTextSelect.Click();

                fo.BoolenSelectFalseText.Click();
                Assert.AreEqual("Ohoo Noo", fo.BoolenSelectFalseTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                fo.BoolenSelectFalseTextSelect.Click();


            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }


      //  [Property("TestCaseId", "Form_BasicControls_CheckBoxGroup_001")]
      //  [Test, Order(6)]
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


      //  [Property("TestCaseId", "Form_BasicControls_RadioButton_001")]
      //  [Test, Order(7)]
        public void RadioButton()
        {
            try
            {
                Assert.AreEqual("true", fo.RadioButtonGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton - Hidden”");

                Assert.AreEqual("true", fo.RadioButtonGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton - ReadOnly”");

                Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - RadioButton - Required”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }

     //   [Property("TestCaseId", "Form_BasicControls_Label_001")]
       // [Test, Order(8)]
        public void Label()
        {
            try
            {
                Assert.AreEqual("true", fo.LabelHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Label - Hidden”");

                Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.LabelHelpTextData)).ToString(), true.ToString(), "“Test passed for User - side - Label - HelpText”");

                //Assert.AreEqual("Tool Tip", fo.LabelToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - RadioButton - Tool Tip”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }


      //  [Property("TestCaseId", "Form_BasicControls_Boolean_001")]
     //   [Test, Order(9)]
        public void Boolean()
        {
            try
            {
                Assert.AreEqual("true", fo.BoolenHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean - Hidden”");

                //fo.BoolenReadOnly.Click();
                Assert.AreEqual("true", fo.BoolenReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean - Read Only”");

                fo.BoolenString.Click();
                Assert.AreEqual("String", fo.BoolenString.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - String”");

                fo.BoolenInteger.Click();
                Assert.AreEqual("Int32", fo.BoolenInteger.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - Integer”");

                //Assert.AreEqual("True", IsElementPresent(fo.BoolenRequired).ToString(), true.ToString(), "“Test passed for User - side - Boolean - Required”");


                fo.BoolenDoNotPersist.Click();
                //Assert.AreEqual("Tool Tip", fo.BoolenDoNotPersist.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean - Do Not Persist”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }


     //   [Test, Order(10)]
        public void SaveFoam()
        {
            fo.SaveForm.Click();

            browserOps.implicitWait(2000);
            browserOps.implicitWait(2000);
            browserOps.implicitWait(2000);
            browserOps.DriverWait();
            browserOps.DriverWait();
            //elementOps.ExistsXpath("//*[@id='objname']/span");

            //Assert.AreEqual("View Mode", fo.GetMode.Text, true.ToString(), "Form Saved and is opened in View Mode");

            Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

            Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");

            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Password Has data”");

            //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"), true.ToString(), "“Test passed for User - side - TextBox - Email”");

            Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
            Assert.AreEqual("187", (fo.TextBoxMultiLine.GetAttribute("value").Length).ToString(), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("4", fo.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - Max Length”");
            Assert.AreEqual("EXPR", fo.TextBoxMaxLength.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");

            Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
            Assert.AreEqual("Read Only Data", fo.TextboxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Read Only Has Data”");

            Assert.AreEqual("Test Data", fo.TextboxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Required”");

            Assert.AreEqual(UniqueId, fo.TextboxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Unique”");

            Assert.AreEqual("", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");



            Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBox.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBoxCurrency.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            //Assert.AreEqual("701-215-3871", fo.NumericBoxPhone.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_unique", fo.NumericBoxUnique.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreNotEqual(UniqueId, fo.NumericBoxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBoxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("123.00", fo.NumericBoxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");


            Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_decimal", fo.NumericBoxDecimal.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.5000", fo.NumericBoxDecimal.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("-123.00", fo.NumericBoxNegative.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_persist", fo.NumericBoxDonotpersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            //Assert.AreEqual("0.00", fo.NumericBoxDonotpersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");



            Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

            //Assert.AreEqual("Tool Tip", fo.BoolenSelectToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

            Assert.AreEqual("Ohoo yes", fo.BoolenSelectTrueTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

            Assert.AreEqual("Ohoo Noo", fo.BoolenSelectFalseTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");




            Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");

            Assert.AreEqual("true", fo.CheckBoxGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");

            Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");


            Assert.AreEqual("true", fo.LabelHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Label - Hidden”");

            Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.LabelHelpTextData)).ToString(), true.ToString(), "“Test passed for User - side - Label - HelpText”");

            //Assert.AreEqual("Tool Tip", fo.LabelToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - RadioButton - Tool Tip”");



            Assert.AreEqual("true", fo.BoolenHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean - Hidden”");

            Assert.AreEqual("true", fo.BoolenReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean - Read Only”");

            Assert.AreEqual("String", fo.BoolenString.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - String”");

            Assert.AreEqual("Int32", fo.BoolenInteger.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - Integer”");

        }
        
     //   [Test, Order(11)]
        public void EditFoam()
        {

            fo.MessageBoxClose.Click();
            fo.EditForm.Click();

            browserOps.implicitWait(2000);
            browserOps.DriverWait();

            Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");

            Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");

            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
            Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Password Has data”");

            //Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("email"), true.ToString(), "“Test passed for User - side - TextBox - Email”");

            Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
            Assert.AreEqual("187", (fo.TextBoxMultiLine.GetAttribute("value").Length).ToString(), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("4", fo.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - Max Length”");
            Assert.AreEqual("EXPR", fo.TextBoxMaxLength.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");

            Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");

            Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
            Assert.AreEqual("Read Only Data", fo.TextboxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Read Only Has Data”");

            Assert.AreEqual("Test Data", fo.TextboxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Required”");

            Assert.AreEqual(UniqueId, fo.TextboxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Unique”");

            Assert.AreEqual("", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");



            Assert.AreEqual("numeric_plain", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBox.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_currency", fo.NumericBoxCurrency.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBoxCurrency.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_phone", fo.NumericBoxPhone.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            //Assert.AreEqual("701-215-3871", fo.NumericBoxPhone.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_unique", fo.NumericBoxUnique.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreNotEqual(UniqueId, fo.NumericBoxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.00", fo.NumericBoxReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("123.00", fo.NumericBoxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");


            Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_decimal", fo.NumericBoxDecimal.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("123.5000", fo.NumericBoxDecimal.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_neg", fo.NumericBoxNegative.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("-123.00", fo.NumericBoxNegative.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_persist", fo.NumericBoxDonotpersist.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            Assert.AreEqual("0.00", fo.NumericBoxDonotpersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

            Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");



            Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

            //Assert.AreEqual("Tool Tip", fo.BoolenSelectToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

            Assert.AreEqual("Ohoo yes", fo.BoolenSelectTrueTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

            Assert.AreEqual("Ohoo Noo", fo.BoolenSelectFalseTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");




            Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");

            Assert.AreEqual("true", fo.CheckBoxGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");

            Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");


            Assert.AreEqual("true", fo.LabelHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Label - Hidden”");

            Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.LabelHelpTextData)).ToString(), true.ToString(), "“Test passed for User - side - Label - HelpText”");

            //Assert.AreEqual("Tool Tip", fo.LabelToolTip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - RadioButton - Tool Tip”");



            Assert.AreEqual("true", fo.BoolenHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean - Hidden”");

            Assert.AreEqual("true", fo.BoolenReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean - Read Only”");

            Assert.AreEqual("String", fo.BoolenString.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - String”");

            Assert.AreEqual("Int32", fo.BoolenInteger.GetAttribute("value-type"), true.ToString(), "“Test passed for User - side - Boolean - Integer”");

            SaveFoam();

        }

    }
}
