using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class TableVisualizationTestCase : BaseClass
    {
        UserLogin ulog;
        TableVisualization tv;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public void ChooseTV()
        {
            tv = new TableVisualization(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[6]/a");
            tv.SelectApp.Click();
            Console.WriteLine("SelectApp");
            elementOps.ExistsXpath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[2]");
            actions.MoveToElement(tv.SelectTableView).Perform();
            tv.SelectTableView.Click();
            Console.WriteLine("SelectTableView");
            elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div");
            actions.MoveToElement(tv.SelectTableVisualization).Perform();
            tv.SelectTableVisualization.Click();
        }

        [Property("TestCaseId", "TableVisualization_AddNewForm_001")]
        [Test]
        public void AddNewForm()
        {
            UserLogin();
            ChooseTV();
            tv = new TableVisualization(driver);
            tv.NewFormButton.Click();
            elementOps.ExistsXpath("//*[@id=\"NewFormdddvContainer_1586780535084_0_0\"]/div/ul/li/a");
            string url = driver.Url;
            tv.NewFormUserCreation.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (driver.Url != url)
                Console.WriteLine("Success!!");
            else
                Console.WriteLine("Faliure!!");
        }

        [Property("TestCaseId", "TableVisualization_EditForm_002")]
        [Test]
        public void EditForm()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.DataEntryLinkClick.Click();
                Console.WriteLine("Link Clicked");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                tv.WebFormEditButton.Click();
                Console.WriteLine("Edit Button Clicked");
                browserOps.implicitWait(50);
                string txt = tv.EditMode.GetAttribute("innerHTML");
                Assert.AreEqual(txt, "Edit Mode");
                Console.WriteLine("Success!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_SortColumns_003")]
        [Test]
        public void SortColumns()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                string srt;
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]");
                tv.SortNameField.Click();
                browserOps.implicitWait(50);

                srt = tv.SortNameField.GetAttribute("aria-label");
                Console.WriteLine(srt);
                Assert.AreEqual("Name: activate to sort column descending", srt);
                Console.WriteLine("Success!! Ascending Order");
                browserOps.implicitWait(100);

                tv.SortNameField.Click();
                browserOps.implicitWait(100);
                srt = tv.SortNameField.GetAttribute("aria-label");
                Console.WriteLine(srt);
                Assert.AreEqual("Name: activate to sort column ascending", srt);
                Console.WriteLine("Success!! Descending Order");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_SearchBoxes_004")]
        [Test]
        public void SearchBoxes()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("Anoopa Baby" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("padding: 2px !important; display: table-cell;", tv.SearchTagRow.GetAttribute("style"));
                Console.WriteLine("Search Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_RowGrouping_005")]
        [Test]
        public void RowGrouping()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsId("rowgroupDD_dvContainer_1586780535084_0_0");
                var selectElement = new SelectElement(tv.RowGroupingSelect);
                selectElement.SelectByValue("SingleLevelRowGroup2");
                browserOps.implicitWait(100);
                Assert.AreEqual("True", IsElementPresent(tv.RowGroupingAdditionalRow).ToString());
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ToolTip_006")]
        [Test]
        public void ToolTip()
        {
            UserLogin();
            ChooseTV();
            tv = new TableVisualization(driver);
            elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[4]/span");
            //actions.MoveToElement(tv.RowEntryName).Perform();
            //Thread.Sleep(200);
            //string txt = tv.RowEntryName.GetAttribute("aria-describedby");
            //Console.WriteLine(txt);
            if(IsElementPresent(tv.RowEntryName))
                Console.WriteLine("Success");
            else
                Console.WriteLine("Failure");
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
    }
}
