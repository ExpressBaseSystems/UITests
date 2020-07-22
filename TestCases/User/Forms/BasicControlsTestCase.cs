using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User.Forms
{
    [TestFixture]
    public class BasicControlsTestCase : BaseClass
    {
        FormObject fo;
        GetUniqueId UID;
        string UniqueId;
        string TodaysDate;

        public void Userlogin(string FormId)
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
                Console.WriteLine("Login Succesfull");

                FormSelect(FormId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!  " + e.Message + "Stack Trace" + e.StackTrace);
            }
        }
        public void FormSelect(string FormID)
        {


            browserOps.implicitWait(1);
            elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
            fo.MenuApplication.Click();
            browserOps.implicitWait(1);

            actions.MoveToElement(fo.MenuSelectFormMenu).Perform();
            elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[1]");
            fo.MenuSelectFormMenu.Click();
            browserOps.implicitWait(1);
            if (FormID == "BasicControlsTextBox")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsTextBox).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsTextBox.Click();
            }
            else if (FormID == "BasicControlsNumeric")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsNumeric).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsNumeric.Click();
            }
            else if (FormID == "BasicControlsDateTime")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsDateTime).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsDateTime.Click();
            }
            else if (FormID == "BasicControlsBoolenSelect")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsBooleanSelect).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsBooleanSelect.Click();
            }
            else if (FormID == "BasicControlsCheckBoxGroup")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsCheckBoxGroup).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsCheckBoxGroup.Click();
            }
            else if (FormID == "BasicControlsRadioButton")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsRadioButton).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsRadioButton.Click();
            }
            else if (FormID == "BasicControlsRadioButton")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsRadioButton).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsRadioButton.Click();
            }
            else if (FormID == "BasicControlsPowerSelect")
            {
                actions.MoveToElement(fo.MenuSelectBasicControlsPowerSelect).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectBasicControlsPowerSelect.Click();
            }
            Console.WriteLine("Test Form Opened");
        }


        [Property("TestCaseId", "Form_BasicControls_TextBox_001")]
        [Test, Order(2)]
        public void TextBox()
        {
            try
            {
                Userlogin("BasicControlsTextBox");
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("", fo.TextboxVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Value Expression”");
                    Assert.AreEqual("margin: 4px;", fo.TextBoxOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                    Assert.AreEqual(null, fo.TextBoxOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion EnableDiable”");
                });


                fo.TextboxOnChangeTrigger.SendKeys("Hi");
                fo.TextBoxDVE.Click();

                fo.TextBoxLowerCase.SendKeys("LOWERCASE");
                fo.TextBoxUpperCase.SendKeys("uppercase");
                fo.TextBoxPassword.SendKeys("password");
                fo.TextBoxEmail.SendKeys("kurian@expressbase.com");
                fo.TextBoxMultiLine.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
                fo.TextBoxMaxLength.SendKeys("EXPRESSbase");

                fo.TextboxAutosuggestion.SendKeys("T");
                Assert.AreEqual("True", (elementOps.IsWebElementPresent(fo.TextboxAutosuggestionItem)).ToString(), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");
                fo.TextboxAutosuggestionItem.Click();

                fo.TextboxRequired.Click();
                fo.TextboxRequired.SendKeys("Test Data");
                fo.TextboxDoNotPersist.SendKeys("Test Data");
                UniqueId = UID.GetId;
                fo.TextboxUnique.SendKeys(UniqueId);



                Assert.AreEqual("Test Data", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");


                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();

                elementOps.ChangeStyle("cont_TextBox17", "style", "display: none");
                TextBoxValidation();


                fo.EditForm.Click();
                browserOps.DriverWait();
                browserOps.implicitWait(2000);
                
                Assert.AreEqual("", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");
                TextBoxValidation();

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();

                Assert.AreEqual("", fo.TextboxDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Do Not Persist”");
                TextBoxValidation();
                Console.Write("“Test passed for User - side - TextBox - Form_BasicControls_TextBox_001”");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
        public void TextBoxValidation()
        {
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("true", fo.TextboxHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - TextBox - Hide”");
                    Assert.AreEqual("lowercase", fo.TextBoxLowerCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - lowercase”");
                    Assert.AreEqual("UPPERCASE", fo.TextBoxUpperCase.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Uppercase”");
                    Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
                    Assert.AreEqual("password", fo.TextBoxPassword.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Password”");
                    Assert.AreEqual("email", fo.TextBoxEmail.GetAttribute("type"), true.ToString(), "“Test passed for User - side - TextBox - Email”");
                    Assert.AreEqual("3", fo.TextBoxMultiLine.GetAttribute("rows"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
                    Assert.AreEqual("187", (fo.TextBoxMultiLine.GetAttribute("value").Length).ToString(), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");
                    Assert.AreEqual("EXP", fo.TextBoxMaxLength.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine Has Data”");
                    Assert.AreEqual("3", fo.TextBoxMaxLength.GetAttribute("maxlength"), true.ToString(), "“Test passed for User - side - TextBox - MultiLine”");
                    Assert.AreEqual("ui-autocomplete-input", fo.TextboxAutosuggestion.GetAttribute("class"), true.ToString(), "“Test passed for User - side - TextBox - Auto Suggestion”");
                    Assert.AreEqual("true", fo.TextboxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - Read Only”");
                    Assert.AreEqual("DVE", fo.TextBoxDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Default Value Expression”");
                    Assert.AreEqual("Test Data", fo.TextboxRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Required”");
                    Assert.AreEqual(UniqueId, fo.TextboxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Unique”");

                    Assert.AreEqual("Done", fo.TextboxVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Value Expression”");
                    Assert.AreEqual("Hi", fo.TextboxOnChangeTrigger.GetAttribute("value"), true.ToString(), "“Test passed for User - side - TextBox - Value Expression”");
                    Assert.AreEqual("none", fo.TextBoxOnChangeHideShow.GetCssValue("display"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                    Assert.AreEqual("true", fo.TextBoxOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - OnChange Funtion EnableDiable”");
                });
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
                Userlogin("BasicControlsNumeric");

                elementOps.SetValue("Numeric13", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric13');" +
                    "element.dispatchEvent(e); ");

                fo.NumericBox.Click();

                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric2", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric2');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric3", "7012153871");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric3');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric6", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric6');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric7", "123456");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric7');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric8", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric8');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric9", UniqueId);
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric9');" +
                    "element.dispatchEvent(e); ");


                elementOps.SetValue("Numeric10", "123.5431");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric10');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Numeric11", "-123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric11');" +
                    "element.dispatchEvent(e); ");


                elementOps.SetValue("Numeric12", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric12');" +
                    "element.dispatchEvent(e); ");


                //elementOps.SetValue("Numeric14", "123");
                //elementOps.ExecuteScripts("const e = new Event('change');" +
                //    "const element = document.querySelector('#Numeric14');" +
                //    "element.dispatchEvent(e); ");
                //Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”"); 

                //elementOps.SetValue("Numeric13", "123");
                //elementOps.ExecuteScripts("const e = new Event('change');" +
                //    "const element = document.querySelector('#Numeric13');" +
                //    "element.dispatchEvent(e); ");
                //Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                Assert.Multiple(() =>
                {
                    Assert.AreEqual("123.00", fo.NumericBox.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("123.00", fo.NumericBoxCurrency.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("fa fa-money aria-hidden=", fo.NumericBoxCurrencyIcon.GetAttribute("class"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    // Assert.AreEqual("7012153871", fo.NumericBoxPhone.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("fa fa-phone aria-hidden=", fo.NumericBoxPhoneIcon.GetAttribute("class"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("true", fo.NumericBoxHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - NumericBox - Hidden”");
                    Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("true", fo.NumericBoxRequired.GetAttribute("required"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    // Assert.AreEqual(UniqueId + .00, fo.NumericBoxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("123.5431", fo.NumericBoxDecimal.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("-123.00", fo.NumericBoxNegative.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("123.00", fo.NumericBoxDonotpersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("110.00", fo.NumericDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("123.00", fo.NumericVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("margin: 4px; display: none;", fo.NumericOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Numeric OnChange- Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                    Assert.AreEqual("true", fo.NumericOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Numeric - OnChangeFuntion EnableDiable”");
                });
                Console.Write("“Test passed for User - side - NumericBox - Plain -  Form_BasicControls_NumericBox_001”");

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();

                NumericFormValidation();

                fo.EditForm.Click();
                browserOps.implicitWait(2000);
                browserOps.DriverWait();

                NumericFormValidation();

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");                
                browserOps.Refresh();

                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();

                NumericFormValidation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        public void NumericFormValidation()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("123.00", fo.NumericBox.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("123.00", fo.NumericBoxCurrency.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("fa fa-money aria-hidden=", fo.NumericBoxCurrencyIcon.GetAttribute("class"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                // Assert.AreEqual("7012153871", fo.NumericBoxPhone.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("fa fa-phone aria-hidden=", fo.NumericBoxPhoneIcon.GetAttribute("class"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("true", fo.NumericBoxHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - NumericBox - Hidden”");
                Assert.AreEqual("true", fo.NumericBoxReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("true", fo.NumericBoxRequired.GetAttribute("required"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("5", fo.NumericBoxMax.GetAttribute("max"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("5", fo.NumericBoxMin.GetAttribute("min"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                // Assert.AreEqual(UniqueId + .00, fo.NumericBoxUnique.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");            
                Assert.AreEqual("123.5431", fo.NumericBoxDecimal.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("-123.00", fo.NumericBoxNegative.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                //Assert.AreEqual("0.00", fo.NumericBoxDonotpersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("110.00", fo.NumericDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                //Assert.AreEqual("Tool Tip", fo.NumericBoxTooltip.GetAttribute("data-original-title"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”"); 
                //Assert.AreEqual("numeric_help", fo.NumericBoxHelpText.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("123.00", fo.NumericVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                //Assert.AreEqual("margin: 4px; display: none;", fo.NumericOnChangeHideShow.GetAttribute("style"), true.ToString(), "“Test passed for User - side - Numeric OnChange- Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                Assert.AreEqual("true", fo.NumericOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Numeric - OnChangeFuntion EnableDiable”");
            });
        }

        [Property("TestCaseId", "Form_BasicControls_DateTimePicker_001")]
        [Test, Order(4)]
        public void dateTimePicker()
        {
            try
            {
                Userlogin("BasicControlsDateTime");

                TodaysDate = fo.Date.GetAttribute("value");

                elementOps.SetValue("Date1", "15-04-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date1');" +
                    "element.dispatchEvent(e); ");
                elementOps.SetValue("Date18", "15-06-2020");
               

                elementOps.SetValue("Date3", "2:00 PM");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date3');" +
                    "element.dispatchEvent(e); ");
                

                elementOps.SetValue("Date2", "15-04-2020 2:00 PM");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date2');" +
                    "element.dispatchEvent(e); ");
                


                //Assert.AreEqual("numeric_plain", fo.DateTimeToolTip.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                //Assert.AreEqual("numeric_plain", fo.DateTimeReadOnly.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");


                fo.DateTimenullableSelect.Click();
                elementOps.SetValue("Date17", "15-04-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date17');" +
                    "element.dispatchEvent(e); ");
                

                //elementOps.SetValue("Date18", "15-06-2020");

                elementOps.SetValue("Date13", "15-04-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date13');" +
                    "element.dispatchEvent(e); ");

                //browserOps.implicitWait(2000);
                fo.DateTimeTigger.SendKeys("15-06-2020" + Keys.Enter);
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date18');" +
                    "element.dispatchEvent(e); ");
                elementOps.InvisibleWait(By.Id("cont_Date19"));
                Assert.AreEqual("15-06-2020", fo.DateTimeTigger.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-06-2020", fo.DateTimeVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("none", fo.DateTimeHideExpression.GetCssValue("display"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("true", fo.DateTimeReadOnlyExpression.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                elementOps.SetValue("Date18", "15-07-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date18');" +
                    "element.dispatchEvent(e); ");
                elementOps.ExistsXpathClickable(fo.DateTimeHideExpression);
                fo.DateTimeFormClick.Click();
                Assert.AreEqual("15-07-2020", fo.DateTimeTigger.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-01-2020", fo.DateTimeVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("block", fo.DateTimeHideExpression.GetCssValue("display"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual(null, fo.DateTimeReadOnlyExpression.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                //elementOps.SetValue("Date6", "15-05-2020");
                //Assert.AreEqual("15-05-2020", fo.NumericBox.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                //elementOps.SetValue("Date8", "15-06-2020");
                //Assert.AreEqual("15-06-2020", fo.NumericBox.GetAttribute("name"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");

                Assert.Multiple(() =>
                {


                    Assert.AreEqual("15-04-2020", fo.Date.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("2:00 PM", fo.Time.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("15-04-2020 2:00 PM", fo.DateTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("true", fo.DateTimeHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("true", fo.DateTimeReadOnly.GetAttribute("eb-readonly"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("15-04-2020", fo.DateTimenullable.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("20-04-2015", fo.DateTimeDNP.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                    Assert.AreEqual("20-04-2015", fo.DateTimeDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                });

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                Assert.AreEqual("2:00 PM", fo.Time.GetAttribute("value"), true.ToString(), 2.20);
                Assert.AreEqual("15-04-2020 2:00 PM", fo.DateTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-04-2020", fo.DateTimeDNP.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                DateTimePickerValidation();

                fo.EditForm.Click();

                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                Assert.AreEqual("02:00 PM", fo.Time.GetAttribute("value"), true.ToString(), 2.20);
                Assert.AreEqual("15-04-2020 02:00 PM", fo.DateTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual(TodaysDate, fo.DateTimeDNP.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                DateTimePickerValidation();

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.Refresh();

                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                Assert.AreEqual("2:00 PM", fo.Time.GetAttribute("value"), true.ToString(), 2.20);
                Assert.AreEqual("15-04-2020 2:00 PM", fo.DateTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual(TodaysDate, fo.DateTimeDNP.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                DateTimePickerValidation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        public void DateTimePickerValidation()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("15-04-2020", fo.Date.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("true", fo.DateTimeHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("true", fo.DateTimeReadOnly.GetAttribute("eb-readonly"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-04-2020", fo.DateTimenullable.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("20-04-2015", fo.DateTimeDVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-07-2020", fo.DateTimeTigger.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("15-01-2020", fo.DateTimeVE.GetAttribute("value"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual("block", fo.DateTimeHideExpression.GetCssValue("display"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
                Assert.AreEqual(null, fo.DateTimeReadOnlyExpression.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - NumericBox - Plain”");
            });
            
        }

        [Property("TestCaseId", "Form_BasicControls_BoolenSelect_001")]
        [Test, Order(5)]
        public void BoolenSelect()
        {
            try
            {
                Userlogin("BasicControlsBoolenSelect");


                

                browserOps.implicitWait(10);
                fo.BoolenSelectTrueText.Click();
                Assert.AreEqual("Yesss", fo.BoolenSelectTrueTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                fo.BoolenSelectTrueTextSelect.Click();
               

                fo.BoolenSelectFalseText.Click();
                Assert.AreEqual("Nooo", fo.BoolenSelectFalseTextSelect.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                fo.BoolenSelectFalseTextSelect.Click();
               

                fo.BoolenSelectDNP.Click();
                fo.BoolenSelectDNPSelect.Click();
                

                

                fo.BoolenSelectTrigger.Click();
                fo.BoolenSelectTriggerSelect.Click();
                Assert.AreEqual("Yes", fo.BoolenSelectTriggerAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");

                elementOps.InvisibleWait(By.Id("cont_BooleanSelect8"));
                Assert.AreEqual("Yes", fo.BooleanSelectVE.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("margin: 4px; display: none;", fo.BooleanSelectHideExpression.GetAttribute("style"), true.ToString(), "“Test passed for User - side - BooleanSelect OnChange - Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                Assert.AreEqual("true", fo.BooleanSelectDisableExpression.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - BooleanSelect OnChange- Funtion EnableDiable”");






                Assert.Multiple(() =>
                {
                    Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");
                    Assert.AreEqual("Yesss", fo.BoolenSelectTrueTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                    Assert.AreEqual("Nooo", fo.BoolenSelectFalseTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                    Assert.AreEqual("Yes", fo.BooleanSelectDVE.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                    Assert.AreEqual("Yes", fo.BoolenSelectDNPAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                    Assert.AreEqual("true", fo.BooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - BooelanSelect - Funtion EnableDiable”");
                });
                

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                BooleanSelectValidation();

                fo.EditForm.Click();

                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                BooleanSelectValidation();

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.Refresh();

                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                BooleanSelectValidation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        public void BooleanSelectValidation()
        {
            browserOps.implicitWait(2000);
            elementOps.InvisibleWait(By.Id("cont_BooleanSelect8"));

            Assert.Multiple(() =>
            {
                Assert.AreEqual("true", fo.BoolenSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");
                Assert.AreEqual("Yesss", fo.BoolenSelectTrueTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("Nooo", fo.BoolenSelectFalseTextAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                //elementOps.ExistsTextToBePresentInElement(fo.BoolenSelectDNPAfterSave, "No");
                // Assert.AreEqual("No", fo.BoolenSelectDNPAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("Yes", fo.BooleanSelectDVE.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("Yes", fo.BoolenSelectTriggerAfterSave.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("Yes", fo.BooleanSelectVE.Text, true.ToString(), "“Test passed for User - side - Boolean Select - Title”");
                Assert.AreEqual("none", fo.BooleanSelectHideExpression.GetCssValue("display"), true.ToString(), "“Test passed for User - side - BooleanSelect OnChange - Funtion Hide”", "“Test passed for User - side - TextBox - OnChange Funtion Hide”");
                Assert.AreEqual("true", fo.BooleanSelectDisableExpression.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - TextBox - BooleanSelect OnChange- Funtion EnableDiable”");
                Assert.AreEqual("true", fo.BooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - BooelanSelect - Funtion EnableDiable”");
            });
            
        }

        [Property("TestCaseId", "Form_BasicControls_CheckBoxGroup_001")]
        [Test, Order(6)]
        public void CheckBoxGroup()
        {
            try
            {

                Userlogin("BasicControlsCheckBoxGroup");

                Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");

                Assert.AreEqual("true", fo.CheckBoxGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");

                //Assert.AreEqual("checkboxgrouprequired", fo.CheckBoxGroupRequired.GetAttribute("name"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                fo.CheckBoxGroupRequiredSelect.Click();
                Assert.AreEqual("1", elementOps.GetValue("CheckBoxGroup3_Rd0"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                fo.CheckBoxGroupDoNotPersist.Click();
                Assert.AreEqual("1", elementOps.GetValue("CheckBoxGroup4_Rd0"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", fo.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                CheckBoxGroupValidation();

                fo.MessageBoxClose.Click();
                fo.EditForm.Click();

                Assert.AreEqual("Edit Mode", fo.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                CheckBoxGroupValidation();

                fo.SaveForm.Click();
                browserOps.Refresh();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", fo.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.implicitWait(2000);
                browserOps.DriverWait();
                browserOps.DriverWait();
                CheckBoxGroupValidation();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        public void CheckBoxGroupValidation()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("true", fo.CheckBoxGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Hidden”");
                Assert.AreEqual("true", fo.CheckBoxGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - ReadOnly”");
                Assert.AreEqual(null, fo.CheckBoxGroupRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
                Assert.AreEqual("1", fo.CheckBoxGroupDoNotPersist.GetAttribute("value"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
                Assert.AreEqual("1", elementOps.GetValue("CheckBoxGroup3_Rd0"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
                Assert.AreEqual("0", elementOps.GetValue("CheckBoxGroup4_Rd0"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
            });
            
        }

        [Property("TestCaseId", "Form_BasicControls_RadioButton_001")]
        [Test, Order(7)]
        public void RadioButton()
        {
            try
            {
                Userlogin("BasicControlsRadioButton");

                Assert.AreEqual("true", fo.RadioButtonGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton - Hidden”");

                Assert.AreEqual("true", fo.RadioButtonGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton - ReadOnly”");
                fo.RadioButtonGroupDoNotPersist.Click();
                Assert.AreEqual("2", elementOps.RadioButtonCheckValidator("RadioGroup3"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                fo.RadioButtonOnChangeTrigger.Click();

                Assert.AreEqual("false", fo.RadioButtonnChangeHideShow.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange Hidden”");
                Assert.AreEqual("true", fo.RadioButoonOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange ReadOnly”");

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("1", elementOps.RadioButtonCheckValidator("RadioGroup3"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                RadioButtonGroupValidator();
                fo.EditForm.Click();
                Assert.AreEqual("1", elementOps.RadioButtonCheckValidator("RadioGroup3"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");
                RadioButtonGroupValidator();

                fo.SaveForm.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("1", elementOps.RadioButtonCheckValidator("RadioGroup3"), true.ToString(), "“Test passed for User - side - CheckBoxGroup - Required”");

                RadioButtonGroupValidator();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }

        }

        public void RadioButtonGroupValidator()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("true", fo.RadioButtonGroupHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton - Hidden”");
                Assert.AreEqual("true", fo.RadioButtonGroupReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton - ReadOnly”");
                Assert.AreEqual("false", fo.RadioButtonnChangeHideShow.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange Hidden”");
                Assert.AreEqual("true", fo.RadioButoonOnChangeEnableDisable.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - RadioButton -OnChange ReadOnly”");
            });            
        }

        [Property("TestCaseId", "Form_BasicControls_PowerSelect_001")]
        [Test, Order(8)]
        public void PowerSelect()
        {
            try
            {
                Userlogin("BasicControlsPowerSelect");

                fo.PowerSelectSimpleSelect.Click();
                fo.PowerSelectSimpleSelectitem.Click();

                Assert.AreEqual("true", fo.PowerSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

                Assert.AreEqual("true", fo.PowerSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

                elementOps.ExistsXpathClickable(fo.PowerSelectMultiSelect);
                //actions.MoveToElement(fo.PowerSelectMultiSelect).DoubleClick().Build().Perform();
                elementOps.ExecuteScripts("var Clickevent = new MouseEvent('dblclick', {'view': window});document.getElementById('PowerSelect4textbox_unique').dispatchEvent(Clickevent); ");
                elementOps.ExistsXpathClickable(fo.PowerSelectMultiSelectItem1);
                fo.PowerSelectMultiSelectItem1.Click();
                fo.PowerSelectMultiSelectItem2.Click();

                //actions.DoubleClick(fo.PowerSelectRequired).DoubleClick().Build().Perform();
                elementOps.ExecuteScripts("var Clickevent = new MouseEvent('dblclick', {'view': window});document.getElementById('PowerSelect5textbox_unique').dispatchEvent(Clickevent); ");
                elementOps.ExistsXpathClickable(fo.PowerSelectRequiredItem);
                //actions.MoveToElement(fo.PowerSelectRequiredItem).Perform();
                elementOps.ExecuteScripts("var Clickevent = new MouseEvent('dblclick', {'view': window});document.querySelector('#PowerSelect5tbl > tbody > tr.even > td:nth-child(1)').dispatchEvent(Clickevent); ");
                


                int count = 0;
                bool clicked = false;
                while (count < 100 && !clicked)
                {
                    try
                    {
                        //actions.DoubleClick(fo.PowerSelectDNP).DoubleClick().Build().Perform();
                        fo.PowerSelectDNP.Click();
                        clicked = true;
                    }
                    catch (StaleElementReferenceException e)
                    {
                        e.ToString();
                        Console.WriteLine("Trying to recover from a stale element :" + e.Message + count);
                        count = count + 1;
                    }
                }

                //actions.DoubleClick(fo.PowerSelectRequiredItem).DoubleClick().Build().Perform();
                //fo.PowerSelectRequiredItem.Click();

                //elementOps.ExecuteScripts("var Clickevent = new MouseEvent('dblclick', {'view': window});document.getElementById('PowerSelect7textbox_unique').dispatchEvent(Clickevent); ");
                //actions.DoubleClick(fo.PowerSelectDNP).DoubleClick().Build().Perform();
                actions.MoveToElement(fo.PowerSelectDNPItem).Perform();
                actions.DoubleClick(fo.PowerSelectDNPItem).Perform();
                //fo.PowerSelectDNPItem.Click();


                fo.PowerSelectSearch.SendKeys("ysr");
                fo.PowerSelectSearchItem.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
    }
}
