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

        //[Test, Order(2)]
        public void PowerSelect()
        {
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

            fo.DataGrid1DateInput.Click();
            //fo.DataGrid1DateInputSelect.Click();

            fo.DataGrid1BooleanInput.Click();

            fo.DataGrid1DropDownInput.Click();
            fo.DataGrid1DropDownSelect.Click();

            fo.DataGrid1BooleanSelectSelect.Click();
            fo.DataGrid1BooleanSelectInput.Click();

            fo.UserSelectClick.Click();
            fo.UserSelectItemClick.Click();


        }
    }
}
