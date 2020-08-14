using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User.Forms
{
    public class PlatformControls : BaseClass
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
            if (FormID == "PlatformControls")
            {
                actions.MoveToElement(fo.MenuSelectPlatformControls).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectPlatformControls.Click();
            }
            if (FormID == "PlatformControlsCalendar")
            {
                actions.MoveToElement(fo.MenuSelectPlatformControlCalender).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectPlatformControlCalender.Click();
            }
            Console.WriteLine("Test Form Opened");
        }

        [Property("TestCaseId", "Form_PlatformControls_001")]
        [Test, Order(1)]
        public void PlatformControl()
        {
            Userlogin("PlatformControls");

            TodaysDate = fo.SysCreatedAt.GetAttribute("value");

            
            

            //fo.SysLocationSelectableClick.Click();
            //fo.SysLocationSelectableItemSelect.Click();
            //Assert.AreEqual("3", fo.SysLocationSelectableClick.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysLocation - Selectable”");

            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysCreatedBy), true.ToString(), "“Test passed for User - side - SysCreatedBy”");
            Assert.AreEqual(TodaysDate, fo.SysCreatedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysCreatedAt”");

            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysModifiedBy), true.ToString(), "“Test passed for User - side - SysModifiedBy”");
            Assert.AreEqual(TodaysDate, fo.SysModifiedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysModifiedAt”");

            fo.UserSelectClick.Click();
            fo.UserSelectItemClick.Click();
            //Assert.AreEqual("2", fo.UserSelectClick.GetAttribute("value"), true.ToString(), "“Test passed for User - side - UserSelect - Selectable”");

            fo.UserLocationGlobal.Click();
            fo.UserLocationSelect.Click();
            browserOps.implicitWait(100);
            fo.UserLocationKochi.Click();
            fo.UserLocationSelect.Click();

            fo.SaveForm.Click();
            elementOps.ExistsClass("eb_messageBox_container");
            elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
            Assert.AreEqual("View Mode", fo.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            PlatformControlValidator();
        }

       
        public void PlatformControlValidator()
        {
            StringAssert.StartsWith("TC", fo.AutoId.GetAttribute("value"));
            //Assert.AreEqual("TC000", fo.AutoId.GetAttribute("value"), true.ToString(), 3.1);

            //Assert.AreEqual("default", fo.SysLocationReadOnly.GetAttribute("value"), true.ToString());

            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysCreatedBy), true.ToString(), "“Test passed for User - side - SysCreatedBy”");
            Assert.AreEqual(TodaysDate, fo.SysCreatedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysCreatedAt”");

            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysModifiedBy), true.ToString(), "“Test passed for User - side - SysModifiedBy”");
            Assert.AreEqual(TodaysDate, fo.SysModifiedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysModifiedAt”");
        }

        [Property("TestCaseId", "Form_PlatformControls_001")]
        [Test, Order(1)]
        public void PlatformControlCalender()
        {
            Userlogin("PlatformControlsCalendar");
            int count = 10;

            for (int i = 0; i < 30; i++)
            {
                
                UniqueId = UID.GetId;
                this.driver.FindElement(By.Id("TextBox1")).SendKeys(UniqueId);

                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");

                elementOps.SetValue("Date1", "15-04-2020");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Date1');" +
                    "element.dispatchEvent(e); ");

                fo.DataGrid1AddRow.Click();
                this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input")).SendKeys(UniqueId);
                this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div/div/input")).SendKeys(UniqueId);
                elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td:nth-child(4) > div.ctrl-cover > div.input-group > input.date", count++ + "- 03-2020");

                elementOps.ExecuteScripts("document.querySelector('#tbl_DataGrid1 > tbody > tr > td.ctrlstd > button.check-row.rowc').click();");
                this.driver.FindElement(By.Id("webformsave")).Click();
                elementOps.ExistsXpathClickable(this.driver.FindElement(By.Id("webformnew"))); 
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: block");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");


                this.driver.FindElement(By.Id("webformnew")).Click();
            }
            

        }

    }
}
