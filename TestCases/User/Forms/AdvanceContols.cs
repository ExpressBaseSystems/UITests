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

        [Test, Order(1)]
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
            browserOps.implicitWait(100);
            fo.DataGrid1DropDownSelect.Click();

            fo.DataGrid1BooleanSelectInput.Click();
            browserOps.implicitWait(100);
            fo.DataGrid1BooleanSelectSelect.Click();

            fo.UserSelectClick.Click();
            elementOps.ExistsXpath("//*[@id='tbl_DataGrid1']/tbody/tr/td[13]/div[1]/div/div[2]/div[3]/div[1]/div[2]");
            fo.UserSelectItemClick.Click();


        }

        [Test, Order(2)]
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

        [Test, Order(3)]
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
            elementOps.SetQueryValue("div.Dg_body > table#tbl_DataGrid3 > tbody > tr > td:nth-child(7) > div.ctrl-cover > div.input-group > input.numinput", "30");
            Assert.AreEqual("true", fo.DataGridNumericHidden.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Read Only”");
            Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");
            Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");

        }

        [Test, Order(4)]
        public void DataGridBooleanSelectDropDown()
        {
           // Userlogin("DataGrid");

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

        [Test, Order(5)]
        public void DataGridPowerSelect()
        {
            try
            {
                Userlogin("DataGrid");
                fo.DataGridPowerSelectAddRow.Click();

                browserOps.implicitWait(100);
                browserOps.implicitWait(100);
                browserOps.implicitWait(100);

                //fo.DataGridPowerSelectSimpleSelect.Click();
                //elementOps.ExistsXpathClickable(fo.DataGridPowerSelectSimpleSelectItem);            
                //fo.DataGridPowerSelectSimpleSelectItem.Click();
                //Assert.AreEqual("true", fo.DataGridPowerSelectSimpleSelect.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");

                elementOps.ExistsXpath("//*[@id='DataGrid5_powerselectcolumn3textbox_unique']/div/input");
                //actions.DoubleClick(fo.DataGridPowerSelectMultiSelect);
                //actions.Perform();
                fo.DataGridPowerSelectMultiSelect.SendKeys("low" + Keys.Enter);
                //elementOps.ExistsXpath("//*[@id=\"WebForm_kckd7ze9\"]/div[2]/div/div[3]/div[2]/table/tbody/tr[1]/td[1]");
                fo.DataGridPowerSelectSimpleSelectMultiItem1.Click();
                fo.DataGridPowerSelectSimpleSelectMultiItem2.Click();
                Console.WriteLine("Did It ");
                //Assert.AreEqual("true", fo.DataGridPo.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");


                fo.DataGridPowerGriddnp.SendKeys("lower" + Keys.Enter);
                elementOps.ExistsXpath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[3]/div[2]/table/tbody/tr[1]/td[1]");
                actions.DoubleClick(fo.DataGridPowerGridDnpItem).Build();
                actions.Perform();
                //fo.DataGridPowerReqMinSearch.SendKeys("lower" + Keys.Enter);
                //elementOps.ExistsXpath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[3]/div[2]/table/tbody/tr[1]/td[1]");
                //actions.DoubleClick(fo.DataGridPowerReqMinSearchItem).Build();
                //actions.Perform();
                //Assert.AreEqual("true", fo.DataGridBooleanSelectReadOnly.GetAttribute("disabled"), true.ToString(), "“Test passed for User - side - DataGrid BooleanSelect ReadOnly- Read Only”");


                //Assert.AreEqual("10.00", fo.DataGridNumericHidden.GetAttribute("value"), true.ToString(), "“Test passed for User - side - DataGridNumeric - Default Value Expression”");

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message + e.StackTrace);
            }
        }

        [Test, Order(6)]
        public void DataGridDateTime()
        {
            //Userlogin("DataGrid");

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
