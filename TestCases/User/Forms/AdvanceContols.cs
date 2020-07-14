using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User.Forms
{
    public class AdvanceContols : BaseClass
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
            if (FormID == "DataGrid")
            {
                actions.MoveToElement(fo.MenuSelectAdvanceControlsDataGrid).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectAdvanceControlsDataGrid.Click();
            }
            Console.WriteLine("Test Form Opened");
        }

        [Test, Order(3)]
        public void DataGrid1()
        {

            Userlogin("DataGrid");

            fo.DataGrid1AddRow.Click();
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);


            fo.DataGrid1StringInput.SendKeys("TestCase");

            elementOps.SetQueryValue(".numinput", "123");

            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td > div.ctrl-cover > div.input-group > input.date", "15-04-2020");
            //fo.DataGrid1DateInputSelect.Click();

            fo.DataGrid1BooleanInput.Click();

            fo.DataGrid1DropDownInput.Click();
            fo.DataGrid1DropDownSelect.Click();

            fo.DataGrid1BooleanSelectSelect.Click();
            fo.DataGrid1BooleanSelectInput.Click();

            fo.UserSelectClick.Click();
            fo.UserSelectItemClick.Click();


        }

        [Test, Order(4)]
        public void DataGridString()
        {
            Userlogin("DataGrid");

            fo.DataGridStringAddRow.Click();

            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);


            fo.DataGridStringRequired.SendKeys("TestCase");
            Assert.AreEqual("Read Only", fo.DataGridStringRO.GetAttribute("value"), true.ToString(), "“Test passed for User - side - Boolean - Hidden”");

            fo.DataGridStringUnique.SendKeys("Test");
            fo.DataGridStringDNP.SendKeys("Test");
            fo.DataGridStringMultiLine.SendKeys("EXPRESSbase is a Platform on the cloud to build & run business applications 10x faster. Get the best of both worlds – stability of Ready-Made software, and flexibility of Custom software.");
            fo.DataGridStringPassword.SendKeys("EXPRESS");
            fo.DataGridStringEmail.SendKeys("kurian@expressbase.com");
        }

        [Test, Order(5)]
        public void DataGridNumeric()
        {
            Userlogin("DataGrid");

            fo.DataGridNumericAddRow.Click();

            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);


            //elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(2) > div.ctrl-cover > div.input-group > input.numinput", "30");
            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(3) > div.ctrl-cover > div.input-group > input.numinput", "30.25");
            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(4) > div.ctrl-cover > div.input-group > input.numinput", "30");
            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(5) > div.ctrl-cover > div.input-group > input.numinput", "30.500");
            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(6) > div.ctrl-cover > div.input-group > input.numinput", "-30.50");
            //elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(7) > div.ctrl-cover > div.input-group > input.numinput", "30");
            Assert.AreEqual("true", fo.DataGridNumericHidden.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Read Only”");
            Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");
            Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");

        }

        [Test, Order(6)]
        public void DataGridBooleanSelectDropDown()
        {
            Userlogin("DataGrid");

            fo.DataGridDataGrid4AddRow.Click();

            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);


            Assert.AreEqual("true", fo.DataGridBooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");
            fo.DataGridBooleanSelectDNP.Click();

            fo.DataGridDropDownDNP.Click();
            fo.DataGridDropDownDNPSelect.Click();
            //Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");

            fo.DataGridBooleanSelectColumnDNP.Click();
            fo.DataGridBooleanSelectColumnDNPSelect.Click();
        }

        [Test, Order(7)]
        public void DataGridPowerSelect()
        {

            Userlogin("DataGrid");
            fo.DataGridPowerSelectAddRow.Click();

            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);

            fo.DataGridPowerSelectSimpleSelect.Click();
            fo.DataGridPowerSelectSimpleSelectItem.Click();
            Assert.AreEqual("true", fo.DataGridPowerSelectSimpleSelect.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");

            actions.DoubleClick(fo.DataGridPowerSelectMultiSelect).Perform();
            fo.DataGridPowerSelectSimpleSelectMultiItem1.Click();
            fo.DataGridPowerSelectSimpleSelectMultiItem2.Click();
            fo.DataGridPowerSelectSimpleSelectMultiItem3.Click();
            fo.DataGridPowerSelectSimpleSelectMultiItem4.Click();
            Assert.AreEqual("true", fo.DataGridBooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");


            fo.DataGridPowerReqMinSearch.SendKeys("lower");
            fo.DataGridPowerReqMinSearchItem.Click();
            Assert.AreEqual("true", fo.DataGridBooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");


            Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");

            fo.DataGridBooleanSelectColumnDNP.Click();
            fo.DataGridBooleanSelectColumnDNPSelect.Click();
        }

        [Test, Order(8)]
        public void DataGridDateTime()
        {
            Userlogin("DataGrid");
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-105-105-105-105");

            fo.DataGrid1AddRow.Click();

            browserOps.implicitWait(100);
            browserOps.implicitWait(100);
            browserOps.implicitWait(100);


            //actions.DoubleClick(fo.DataGridPowerSelectMultiSelect).Perform();


            Assert.AreEqual("15-02-2018", fo.DataGridDateTimeReadOnly.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - ReadOnly”");
            Assert.AreEqual("true", fo.DataGridDateTimeReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - ReadOnly”");

            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td:nth-child(3) > div.ctrl-cover > div.input-group > input.date", "15-04-2020");
            Assert.AreEqual("15-04-2020", fo.DataGridDateTimeRequired.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - Required”");

            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td:nth-child(4) > div.ctrl-cover > div.input-group > input.date", "15-05-2021");
            Assert.AreEqual("15-05-2021", fo.DataGridDateTimeDNP.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - DNP”");

            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td:nth-child(5) > div.ctrl-cover > div.input-group > input.date", "15-06-2020 07:00 PM");
            Assert.AreEqual("15-06-2020 07:00 PM", fo.DataGridDateTimeDateTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - DateTime”");

            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid1 > tbody > tr > td:nth-child(6) > div.ctrl-cover > div.input-group > input.date", "06:00 PM");
            Assert.AreEqual("06:00 PM", fo.DataGridDateTimeTime.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGrid DateTime - Time”");
        }
    }
}
