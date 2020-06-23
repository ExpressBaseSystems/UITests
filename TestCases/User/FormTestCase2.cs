using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class FormTestCase2 : BaseClass
    {
        FormObject fo;
        GetUniqueId UID;
        string UniqueId;

       
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

                browserOps.implicitWait(1);
                elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
                fo.MenuApplication.Click();
                browserOps.implicitWait(1);

                actions.MoveToElement(fo.MenuSelectFormMenu).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[1]");
                fo.MenuSelectFormMenu.Click();
                browserOps.implicitWait(1);
                actions.MoveToElement(fo.MenuSelectForm2).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectForm2.Click();
                Console.WriteLine("Test Form Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_BasicControls_PowerSelect_001")]
        [Test, Order(2)]
        public void PowerSelect()
        {
            UserLogin();
            fo.PowerSelectSimpleSelect.Click();
            fo.PowerSelectSimpleSelectitem.Click();

            Assert.AreEqual("true", fo.PowerSelectHidden.GetAttribute("eb-hidden"), true.ToString(), "“Test passed for User - side - Boolean Select - Hidden”");

            actions.DoubleClick(fo.PowerSelectMultiSelect).Perform();
            fo.PowerSelectMultiSelectItem1.Click();
            fo.PowerSelectMultiSelectItem2.Click();
            
            actions.DoubleClick(fo.PowerSelectRequired).Perform();
            fo.PowerSelectRequired.Click();
            
            actions.DoubleClick(fo.PowerSelectDNP).Perform();
            fo.PowerSelectDNPItem.Click();


            fo.PowerSelectSearch.SendKeys("Tes");
            fo.PowerSelectSearchItem.Click();
        }

        [Test, Order(3)]
        public void DataGrid1()
        {
           

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
            //UserLogin();

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
            UserLogin();

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
          
        }
        
        [Test, Order(6)]
        public void DataGridBooleanSelectDropDown()
        {
            UserLogin();

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
            UserLogin();

            fo.DataGridPowerSelectAddRow.Click();

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
    }
}
