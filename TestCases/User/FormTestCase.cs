﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    class FormTestCase : BaseClass
    {
        UserLogin ulog;
        Form f;

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public void ChooseForm()
        {
            f = new Form(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[8]/a");
        }

        [Property("TestCaseId", "Form_DataPusher_001")]
        [Test, Order(1)]
        public void DataPusher()
        {
            try
            {
                UserLogin();
                ChooseForm();
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val);

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book");
                f.ChildBookDesc.SendKeys("Test Book Desc");
                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val1);
                Assert.AreEqual(val + 1, val1, "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DataPusherPushOnlyIf_001")]
        [Test, Order(2)]
        public void DataPusherPushOnlyIf()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val);

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book 1");
                f.ChildBookDesc.SendKeys("Test Book 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val1);
                Assert.AreEqual(val, val1, "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableDelete_001")]
        [Test, Order(3)]
        public void DisableDelete()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-88-88-88-88");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformdelete");
                Console.WriteLine("Success 1");
                Assert.AreEqual("False", f.DeleteButton.Enabled.ToString(), "Success", "Success");
                Console.WriteLine("Success 1");

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformdelete");
                Assert.AreEqual("True", f.DeleteButton.Enabled.ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableCancel_001")]
        [Test, Order(4)]
        public void DisableCancel()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-88-88-88-88");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformcancel");
                Console.WriteLine("Success 1");
                Assert.AreEqual("False", f.CancelButton.Enabled.ToString(), "Success", "Success");
                Console.WriteLine("Success 1");

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformcancel");
                Assert.AreEqual("True", f.CancelButton.Enabled.ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableCancel_001")]
        [Test, Order(5)]
        public void BeforeSaveRoutine()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book 1");
                f.ChildBookDesc.SendKeys("Test Book 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                var alert = driver.SwitchTo().Alert();
                Assert.AreEqual("Hello", alert.Text, "Success", "Success");
                alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_AfterSaveRoutine_001")]
        [Test, Order(6)]
        public void AfterSaveRoutine()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val);

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Form Test 1");
                f.ChildBookDesc.SendKeys("Form Test 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val1);
                Assert.AreEqual(val+1, val1, "Success", "Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_Notifications_001")]
        [Test, Order(7)]
        public void Notifications()
        {
            try
            {
                int val;
                int val1;
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsXpath("//*[@id=\"nf-container\"]/li");
                val = elementOps.GetTableRowCount("//*[@id=\"nf-container\"]/li");
                Console.WriteLine(val);
                
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Form Notification Test 1");
                f.ChildBookDesc.SendKeys("Form Notification Test 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                browserOps.Refresh();

                elementOps.ExistsId("notification-count");
                val1 = elementOps.GetTableRowCount("//*[@id=\"nf-container\"]/li");
                Console.WriteLine(val1);
                Assert.AreEqual(val+3, val1, "Success", "Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormModeAfterSave_001")]
        [Test, Order(8)]
        public void FormModeAfterSave()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-14-14-14-14");
                elementOps.ExistsId("Numeric2");
                elementOps.SetValue("Numeric2", "15000");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric2');" +
                    "element.dispatchEvent(e); ");
                f.UserName.SendKeys("Form Test User");
                f.UserDOB.SendKeys("25-04-1995" + Keys.Enter);
                Console.WriteLine("Date Entered");
                f.UserPhno.SendKeys("9400000028");
                f.UserDeptSelectButton.Click();
                elementOps.ExistsXpath("//*[@id=\"SimpleSelect1_dd\"]/div/div/ul/li[2]/a");
                f.UserDeptSelectOpt.Click();
                f.UserStatusSelectButton.Click();
                elementOps.ExistsXpath("//*[@id=\"SimpleSelect2_dd\"]/div/div/ul/li[2]/a");
                f.UserStatusSelectOpt.Click();
                f.UserRemark.SendKeys("No Remarks");
                f.UserDGAddButton.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input");
                f.UserDGCourseName.SendKeys("Test Course");
                f.UserDGYear.SendKeys("2015");
                f.UserDGCommit.Click();
                f.SaveButton.Click();
                
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-34-34-34-34");
                elementOps.ExistsId("TextBox1");
                f.JamTopic.SendKeys("Test Topic");
                f.SaveButton.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                
                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-31-31-31-31");
                elementOps.ExistsId("TextBox1");
                f.JamTopic.SendKeys("Test Course");
                f.SaveButton.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));

                Assert.AreEqual("Edit Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("Edit Mode");
                
                browserOps.NewTab("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-83-83-83-83");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Form Test 1");
                f.ChildBookDesc.SendKeys("Form Test 1 Desc");
                elementOps.SetValue("Numeric1", "125");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
                
                Assert.AreEqual("https://uitesting.eb-test.cloud/UserDashBoard", driver.Url, "Success", "Success");
                Console.WriteLine("Close Mode");
                //driver.Close();
                //driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormApperance_001")]
        [Test, Order(9)]
        public void FormApperance()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("WebForm_kayu90ek");
                string style = f.ParentForm.GetAttribute("style");
                Assert.AreEqual(style, "padding: 8px;", "Success", "Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormPDF_001")]
        [Test, Order(10)]
        public void FormPDF()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Form PDF Test 1");
                f.ChildBookDesc.SendKeys("Form PDF Test 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsId("webformprint");
                f.FormPDFPrint.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                
                Assert.AreEqual("display: block;", f.FormPDFModal.GetAttribute("style").ToString(), "Success", "Success");

                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_TitleExpression_001")]
        [Test, Order(11)]
        public void TitleExpression()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                string title_before = driver.Title;
                f.ChildBookName.SendKeys("TitlExp ");
                f.ChildBookDesc.SendKeys("Form Test 1 Desc");
                elementOps.SetValue("Numeric1", "175");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                string title_after = driver.Title;
                Assert.AreNotEqual(title_before, title_after, "Success", "Success");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_Validation_001")]
        [Test, Order(12)]
        public void Validation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                string title_before = driver.Title;
                f.ChildBookName.SendKeys("Form Test");
                f.ChildBookDesc.SendKeys("Nil");
                elementOps.SetValue("Numeric1", "125");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                var alert = driver.SwitchTo().Alert();
                alert.Accept();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                string title_after = driver.Title;
                Assert.AreNotEqual(title_before, title_after, "Success", "Success");
                browserOps.Refresh();

                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Nil");
                f.ChildBookDesc.SendKeys("Form Desc");
                elementOps.SetValue("Numeric1", "125");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();
                alert = driver.SwitchTo().Alert();
                alert.Accept();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_001")]
        [Test, Order(13)]
        public void FormGridNumericValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid1addrow");
                f.GridAddRowButton.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input");
                f.GridFirstField.SendKeys("Cash");
                string x = f.GridSecondFieldNumeric.GetAttribute("id");
                elementOps.SetValue(x, "125");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x + "');" +
                    "element.dispatchEvent(e); "+
                    "$(element).trigger('change');");
                browserOps.implicitWait(50);
                f.GridCommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_002")]
        [Test, Order(14)]
        public void FormGridBooleanValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "21-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); ");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("yes");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("true");
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_003")]
        [Test, Order(15)]
        public void FormGridDateValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                f.Grid2Field1.Click();
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "23-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); " +
                    "$(element).trigger('change');");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("yes");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("true");
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_004")]
        [Test, Order(16)]
        public void FormGridDropDownValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                f.Grid2Field1.Click();
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "21-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); ");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("no");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("true");
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_005")]
        [Test, Order(17)]
        public void FormGridBooleanSelectValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                f.Grid2Field1.Click();
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "21-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); ");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("yes");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("false");
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(18)]
        public void FormGridPowerSelectValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                f.Grid2Field1.Click();
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "21-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); ");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("yes");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("true");
                f.Grid2Field5.Click();
                f.Grid2Field5.SendKeys("A" + Keys.Enter);
                elementOps.ExistsXpath("//*[@id=\"WebForm_kbnm7hcy\"]/div[3]/div/div[2]/div[2]/table/tbody/tr/td");
                f.Grid2Field5.SendKeys(Keys.Enter);
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(19)]
        public void FormGridCreatedByValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                string x = f.Grid2Field6.GetAttribute("innerHTML");

                Assert.AreEqual("Anoopa Baby", x, "Success", "Success");
                Console.WriteLine("Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(20)]
        public void FormGridCreatedAtValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.Grid2Field7).ToString(), "Success", "Success");
                Console.WriteLine("Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(21)]
        public void FormGridModifiedByValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                string x = f.Grid2Field8.GetAttribute("innerHTML");

                Assert.AreEqual("Anoopa Baby", x, "Success", "Success");
                Console.WriteLine("Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(22)]
        public void FormGridModifiedAtValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.Grid2Field9).ToString(), "Success", "Success");
                Console.WriteLine("Success");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormGridValidation_006")]
        [Test, Order(23)]
        public void FormGridUserSelectValidation()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-97-97-97-97");
                elementOps.ExistsId("DataGrid2addrow");
                f.GridAddRowButton1.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input");
                f.Grid2Field1.Click();
                string x1 = f.Grid2Field2.GetAttribute("id");
                elementOps.SetValue(x1, "21-06-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#" + x1 + "');" +
                    "element.dispatchEvent(e); ");
                var selectElement = new SelectElement(f.Grid2Field3);
                selectElement.SelectByValue("yes");
                selectElement = new SelectElement(f.Grid2Field4);
                selectElement.SelectByValue("true");
                f.Grid2Field10.Click();
                elementOps.ExistsXpath("//*[@id='tbl_DataGrid2']/tbody/tr/td[11]/div/div/div[2]/div[3]/div[2]");
                f.Grid2Field10Value.Click();
                f.Grid2CommitButton.Click();
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("New Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("New Mode");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FormSave_001")]
        //[Test, Order(19)]
        public void FormSave()
        {
            try
            {
                UserLogin();
                ChooseForm();

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-34-34-34-34");
                elementOps.ExistsId("TextBox1");
                f.JamTopic.SendKeys("Test Topic");
                var selectElement = new SelectElement(f.FormSaveDropdown);
                selectElement.SelectByText("&Continue");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
