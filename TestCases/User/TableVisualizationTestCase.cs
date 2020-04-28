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
            else if (c == 3)
            {
                elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[6]");
                actions.MoveToElement(tv.SelectTableVisualizationJamTopicList).Perform();
                tv.SelectTableVisualizationJamTopicList.Click();
            }
        }

        [Property("TestCaseId", "TableVisualization_AddNewForm_001")]
        [Test]
        public void AddNewForm()
        {
            try
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
                Assert.AreNotEqual(url, driver.Url);
                Console.WriteLine("New Form Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
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

                Console.WriteLine(tv.IdField1.GetAttribute("innerHTML"));
                Console.WriteLine(tv.IdField2.GetAttribute("innerHTML"));
                if ("USER0001" == tv.IdField1.GetAttribute("innerHTML") || "USER0004" == tv.IdField2.GetAttribute("innerHTML"))
                    Console.WriteLine("Success!! Ascending Order");

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]");
                tv.SortNameField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-left sorting_desc\"")));

                Console.WriteLine(tv.IdField1.GetAttribute("innerHTML"));
                Console.WriteLine(tv.IdField2.GetAttribute("innerHTML"));
                if ("USER0004" == tv.IdField1.GetAttribute("innerHTML") || "USER0005" == tv.IdField2.GetAttribute("innerHTML"))
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
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                browserOps.implicitWait(100);
                tv.NameEqualToOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("Anoopa Baby" + Keys.Enter);
                browserOps.implicitWait(100);
                if (elementOps.IsWebElementPresent(tv.SearchTag))
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
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.RowGroupingAdditionalRow).ToString());
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
            if (elementOps.IsWebElementPresent(tv.RowEntryName))
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
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.InlineTableAdditionalRow).ToString());
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

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.SortNameField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-left sorting_asc\"")));

                //Assert.AreEqual("conditionformat", tv.ConditionalFormattingDiv.GetAttribute("class"));
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.ConditionalFormattingDiv).ToString());
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
                if (elementOps.IsWebElementPresent(tv.FooterAggregate))
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
                if (elementOps.IsWebElementPresent(tv.CustomColumnHeader))
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
                if (elementOps.IsWebElementPresent(tv.ApprovalColumnHeading))
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
                if (elementOps.IsWebElementPresent(tv.ActionColumnHeading))
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
            selectElement.SelectByValue("SingleLevelRowGroup4");
            browserOps.implicitWait(100);
            Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.AutogenRowGroupingAdditionalRow).ToString());
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

        [Property("TestCaseId", "TableVisualization_FixedColumn_015")]
        [Test]
        public void FixedColumn()
        {
            try
            {
                int c = 3;
                UserLogin();
                ChooseTV(c);
                elementOps.ExistsClass("DTFC_LeftWrapper");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.FixedColumnClass).ToString());
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_PaginationCheck_016")]
        [Test]
        public void PaginationCheck()
        {
            try
            {
                UserLogin();
                ChooseTV();
                tv = new TableVisualization(driver);
                string id;
                string table_info;
                int value;
                int last_value;

                //----next
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_next\"]/a");
                id = tv.IdField1.GetAttribute("innerHTML");
                tv.PaginationNextButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button previous\"")));
                Assert.AreNotEqual(id, tv.IdField1.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[1].Trim());
                last_value = int.Parse(table_info.Split('-', '/')[2].Trim());
                if (value == last_value)
                {
                    Assert.AreEqual("paginate_button next disabled", tv.PaginationNextli.GetAttribute("class"));
                    Console.WriteLine("Next Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button next", tv.PaginationNextli.GetAttribute("class"));
                    Console.WriteLine("Next Button Success");
                }

                //----prev

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_previous\"]/a");
                id = tv.IdField1.GetAttribute("innerHTML");
                tv.PaginationPrevButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button previous disabled\"")));
                Assert.AreNotEqual(id, tv.IdField1.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[0].Trim());
                if (value == 1)
                {
                    Assert.AreEqual("paginate_button previous disabled", tv.PaginationPrevli.GetAttribute("class"));
                    Console.WriteLine("Previous Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button previous", tv.PaginationPrevli.GetAttribute("class"));
                    Console.WriteLine("Previous Button Success");
                }

                //--------last

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_last\"]/a");
                id = tv.IdField1.GetAttribute("innerHTML");
                tv.PaginationLastButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button first\"")));
                Assert.AreNotEqual(id, tv.IdField1.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[1].Trim());
                last_value = int.Parse(table_info.Split('-', '/')[2].Trim());
                if (value == last_value)
                {
                    Assert.AreEqual("paginate_button last disabled", tv.PaginationLastli.GetAttribute("class"));
                    Console.WriteLine("Last Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button last", tv.PaginationLastli.GetAttribute("class"));
                    Console.WriteLine("Last Button Success");
                }

                //---------first
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_first\"]/a");
                id = tv.IdField1.GetAttribute("innerHTML");
                tv.PaginationFirstButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button first disabled\"")));
                Assert.AreNotEqual(id, tv.IdField1.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[0].Trim());
                if (value == 1)
                {
                    Assert.AreEqual("paginate_button first disabled", tv.PaginationFirstli.GetAttribute("class"));
                    Console.WriteLine("First Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button first", tv.PaginationFirstli.GetAttribute("class"));
                    Console.WriteLine("First Button Success");
                }

                //-------

                if(int.Parse(tv.PaginationSelectOption1.GetAttribute("innerHTML")) == 3)
                {
                    int val = int.Parse(elementOps.GetTableRowCountFromJS("dvContainer_1586780535084_0_0").ToString())-7;
                    Assert.AreEqual(3, val);
                    Console.WriteLine("Pagination Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
    }
}
