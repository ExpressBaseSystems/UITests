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
        UserLogOut lo;
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

        public void UserLogOut()
        {
            lo = new UserLogOut(driver);
            lo.ProfileImageDropDown.Click();
            browserOps.implicitWait(50);
            lo.LogoutButton.Click();
            browserOps.implicitWait(50);
            Console.WriteLine("LogOut Success");
        }

        public void ChooseTV(int c = 0)
        {
            tv = new TableVisualization(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[6]/a");
            tv.SelectApp.Click();
            Console.WriteLine("SelectApp");
            elementOps.ExistsXpath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[2]");
            actions.MoveToElement(tv.SelectTableView).Perform();
            tv.SelectTableView.Click();
            Console.WriteLine("SelectTableView");
            if (c == 0)
            {
                elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div");
                actions.MoveToElement(tv.SelectTableVisualizationUsers).Perform();
                tv.SelectTableVisualizationUsers.Click();
            }
            else if (c == 1)
            {
                elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[2]");
                actions.MoveToElement(tv.SelectTableVisualizationAccountTree).Perform();
                tv.SelectTableVisualizationAccountTree.Click();
            }
            else if (c == 2)
            {
                elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[5]");
                actions.MoveToElement(tv.SelectTableVisualizationCourseList).Perform();
                tv.SelectTableVisualizationCourseList.Click();
            }
        }

        [Property("TestCaseId", "TableVisualization_AddNewForm_001")]
        [Test]
        public void AddNewForm()
        {
            UserLogin();
            ChooseTV();
            tv = new TableVisualization(driver);
            elementOps.ExistsId("NewFormButtondvContainer_1586780535084_0_0");
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
                string txt = tv.Mode.GetAttribute("innerHTML");
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

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.SortNameField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-left sorting_asc\"")));
                
                Console.WriteLine(tv.SortIdField1.GetAttribute("innerHTML"));
                Console.WriteLine(tv.SortIdField2.GetAttribute("innerHTML"));
                if ("USER0001" == tv.SortIdField1.GetAttribute("innerHTML") || "USER0004" == tv.SortIdField2.GetAttribute("innerHTML"))
                    Console.WriteLine("Success!! Ascending Order");

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]");
                tv.SortNameField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-left sorting_desc\"")));

                Console.WriteLine(tv.SortIdField1.GetAttribute("innerHTML"));
                Console.WriteLine(tv.SortIdField2.GetAttribute("innerHTML"));
                if ("USER0004" == tv.SortIdField1.GetAttribute("innerHTML") || "USER0005" == tv.SortIdField2.GetAttribute("innerHTML"))
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
                //Assert.AreEqual("padding: 2px !important; display: table-cell;", tv.SearchTagRow.GetAttribute("style"));
                if (IsElementPresent(tv.SearchTag))
                    Console.WriteLine("Success");
                else
                    Console.WriteLine("Failure");
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
            if (IsElementPresent(tv.RowEntryName))
                Console.WriteLine("Success");
            else
                Console.WriteLine("Failure");
        }

        [Property("TestCaseId", "TableVisualization_InlineTable_007")]
        [Test]
        public void InlineTable()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[4]/a/i");
                tv.InlineTableButton.Click();
                Assert.AreEqual("fa fa-caret-up", tv.InlineTableButton.GetAttribute("class"));
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_TreeSearch_008")]
        [Test]
        public void TreeSearch()
        {
            try
            {
                int c = 1;
                UserLogin();
                ChooseTV(c);
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1553959320177_0_0_filter\"]/div/input");
                tv.SearchBar.SendKeys("m");
                Assert.AreEqual("display: none;", tv.TVRowStyle.GetAttribute("style"));
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ConditionalFormatting_009")]
        [Test]
        public void ConditionalFormatting()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]");
                tv.SortNameField.Click();
                browserOps.implicitWait(100);
                Assert.AreEqual("conditionformat", tv.ConditionalFormattingDiv.GetAttribute("class"));
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_Aggrigate_010")]
        [Test]
        public void Aggrigate()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[3]/div/table/tfoot/tr/th[8]/div");
                if (IsElementPresent(tv.FooterAggregate))
                    Console.WriteLine("Success");
                else
                    Console.WriteLine("Faliure");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_CustomColumn_011")]
        [Test]
        public void CustomColumn()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                browserOps.implicitWait(100);
                if (IsElementPresent(tv.CustomColumnHeader))
                {
                    Console.WriteLine(tv.CustomColumnHeader.GetAttribute("innerHTML"));
                    string c = (int.Parse(tv.SalaryField.GetAttribute("innerHTML").Replace(",", "")) * 12).ToString();
                    string net = int.Parse(tv.NetSalaryField.GetAttribute("innerHTML").Replace(",", "")).ToString();
                    Assert.AreEqual(c, net);
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Faliure");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ApprovalColumn_012")]
        [Test]
        public void ApprovalColumn()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                browserOps.implicitWait(100);
                if (IsElementPresent(tv.ApprovalColumnHeading))
                {
                    Assert.AreEqual("Approval Column", tv.ApprovalColumnHeading.GetAttribute("innerHTML"));
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Faliure");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ActionColumn_013")]
        [Test]
        public void ActionColumn()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                browserOps.implicitWait(100);
                if (IsElementPresent(tv.ActionColumnHeading))
                {
                    tv.ActionColumnEditLink.Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    Assert.AreEqual("View Mode", tv.Mode.GetAttribute("innerHTML"));
                    Console.WriteLine("Success");
                }
                else
                    Console.WriteLine("Faliure");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test]
        public void AutoDeploy()
        {
            int c = 2;
            UserLogin();
            ChooseTV(c);
            tv = new TableVisualization(driver);
            //--- row grouping
            elementOps.ExistsId("rowgroupDD_dvnull_0_0");
            var selectElement = new SelectElement(tv.AutogenRowGroupingSelect);
            selectElement.SelectByValue("groupbycreatedby");
            browserOps.implicitWait(100);
            Assert.AreEqual("True", IsElementPresent(tv.AutogenRowGroupingAdditionalRow).ToString());
            Console.WriteLine("Row Grouping Success");
            //------
            elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
            tv.AutogenEntryFields.Click();
            Console.WriteLine("Link Clicked");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            tv.WebFormEditButton.Click();
            Console.WriteLine("Edit Button Clicked");
            browserOps.implicitWait(50);
            string txt = tv.Mode.GetAttribute("innerHTML");
            Assert.AreEqual(txt, "Edit Mode");
            Console.WriteLine("Success!!");
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
