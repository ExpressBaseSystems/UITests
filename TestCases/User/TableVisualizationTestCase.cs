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
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
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

        [Property("TestCaseId", "TableVisualization_AddNewForm_001")]
        [Test, Order(1)]
        public void AddNewForm()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsId("NewFormButtondvContainer_1586780535084_0_0");
                tv.NewFormButton.Click();
                string url = driver.Url;
                tv.NewFormUserCreation.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Assert.AreNotEqual(url, driver.Url, "New Form Success", "New Form Success");
                Console.WriteLine("New Form Success");
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_EditForm_002")]
        [Test, Order(2)]
        public void EditForm()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[3]/a");
                tv.DataEntryLinkClick.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                tv.WebFormEditButton.Click();
                browserOps.implicitWait(50);
                string txt = tv.Mode.GetAttribute("innerHTML");
                Assert.AreEqual(txt, "Edit Mode", "Success!!! Form iin Edit Mode !!!", "Success!!! Form iin Edit Mode !!!");
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_SortColumns_003")]
        [Test, Order(3)]
        public void SortColumns()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
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
                browserOps.Refresh();

                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]");
                tv.SortSMSField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"tdheight dt-left sorting_asc\"")));

                if (tv.SMSField1.GetAttribute("innerHTML") == "0")
                    Console.WriteLine("Success!! Ascending Order");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_CheckSMS_003")]
        [Test, Order(4)]
        public void CheckSMS()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[12]/div/button");
                tv.SMSButton.Click();
                elementOps.ExistsXpath("/html/body/ul[6]/li");
                tv.SendSMS.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SMSTemplate).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_CheckOperator_020")]
        [Test, Order(5)]
        public void CheckOperator()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                string opr = tv.CheckOperatorField.GetAttribute("innerHTML");
                Assert.AreEqual("=", opr, "Success!! Search  Complete", "Success!! Search  Complete");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_SearchBoxes_004")]
        [Test, Order(6)]
        public void SearchBoxes()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                browserOps.implicitWait(100);
                tv.NameEqualToOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("Anoopa Baby" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                elementOps.ExistsId("dvContainer_1586780535084_0_0_phno_hdr_txt1");
                tv.PhoneNumberSearch.SendKeys("9400176451" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                elementOps.ExistsId("dvContainer_1586780535084_0_0_dept_hdr_txt1");
                tv.DeptSearch.SendKeys("production" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.SalSearch.SendKeys("15000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                elementOps.ExistsId("dvContainer_1586780535084_0_0_eb_phone6_hdr_txt1");
                tv.SMSSearch.SendKeys("9400176451" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                elementOps.ExistsId("dvContainer_1586780535084_0_0_user_id_hdr_txt1");
                tv.UsrIdSearch.SendKeys("USER0001" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_RowGrouping_005")]
        [Test, Order(7)]
        public void RowGrouping()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsId("rowgroupDD_dvContainer_1586780535084_0_0");
                var selectElement = new SelectElement(tv.RowGroupingSelect);
                selectElement.SelectByValue("SingleLevelRowGroup2");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[2]");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.RowGroupingAdditionalRow).ToString(), "Success!!! Row Grouping Done!!", "Success!!! Row Grouping Done!!");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ToolTip_006")]
        [Test, Order(8)]
        public void ToolTip()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[4]/span");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.RowEntryName).ToString(), "Success!!! Have Tool Tip", "Success!!! Have Tool Tip");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_InlineTable_007")]
        [Test, Order(9)]
        public void InlineTable()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[4]/a/i");
                tv.InlineTableButton.Click();
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.InlineTableAdditionalRow).ToString(), "Success!!! Have Inline Table", "Success!!! Have Inline Table");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ConditionalFormatting_009")]
        [Test, Order(10)]
        public void ConditionalFormatting()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.SortSalField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-right sorting_asc\"")));
                Assert.AreEqual("conditionformat", tv.ConditionalFormattingDiv.GetAttribute("class"), "Success!!! Conditional Formatting", "Success!!! Conditional Formatting");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_Aggrigate_010")]
        [Test, Order(11)]
        public void Aggrigate()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[3]/div/table/tfoot/tr/th[8]/div");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.FooterAggregate).ToString(), "Success!! Have Aggregate", "Success!! Have Aggregate");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_CustomColumn_011")]
        [Test, Order(12)]
        public void CustomColumn()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                if (elementOps.IsWebElementPresent(tv.CustomColumnHeader))
                {
                    Console.WriteLine(tv.CustomColumnHeader.GetAttribute("innerHTML"));
                    string c = (int.Parse(tv.SalaryField.GetAttribute("innerHTML").Replace(",", "")) * 12).ToString();
                    string net = int.Parse(tv.NetSalaryField.GetAttribute("innerHTML").Replace(",", "")).ToString();
                    Assert.AreEqual(c, net, "Success", "Success");
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
        [Test, Order(13)]
        public void ApprovalColumn()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.SortUserIdField.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"null tdheight dt-left sorting_asc\"")));

                if (elementOps.IsWebElementPresent(tv.ApprovalColumnHeading))
                {
                    Assert.AreEqual("stage_actions_cont", tv.ApprovalColumnDiv.GetAttribute("class"), "Success", "Success");
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
        [Test, Order(14)]
        public void ActionColumn()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                browserOps.implicitWait(100);
                if (elementOps.IsWebElementPresent(tv.ActionColumnHeading))
                {
                    tv.ActionColumnEditLink.Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    Assert.AreEqual("View Mode", tv.Mode.GetAttribute("innerHTML"), "Success", "Success");
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                }
                else
                    Console.WriteLine("Faliure");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_RowHeight_017")]
        [Test, Order(15)]
        public void RowHeight()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[5]");
                Assert.AreEqual("height: 15px;", tv.FieldTd.GetAttribute("style"), "Row " + tv.FieldTd.GetAttribute("style"), "Row " + tv.FieldTd.GetAttribute("style"));
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_OperatorsCheck_022")]
        [Test, Order(16)]
        public void OperatorsCheckForString()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                //--------Starts With
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[4]/div/div/ul/li[1]");
                tv.StartsWithOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("a" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                Console.WriteLine("Starts With");
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //------Ends With
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[4]/div/div/ul/li[1]");
                tv.EndsWithOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("a" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //-----Contains
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[4]/div/div/ul/li[1]");
                tv.ContainsOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("o" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //-----Equal
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_sel");
                tv.NameOperatorDropDownButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[4]/div/div/ul/li[1]");
                tv.NameEqualToOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_name_hdr_txt1");
                tv.SearchBoxNameField.SendKeys("Anoopa Baby" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_OperatorsCheck_022")]
        [Test, Order(17)]
        public void OperatorsCheckForDate()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);
                //Equal
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateEqualToOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("25-04-1995" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //LessThan
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateLessThanOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("25-04-1995" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //Greater Than
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateGreaterThanOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("25-04-1995" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //LessThanOrEqual
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateLessThanorEqualOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("25-04-1995" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //GreaterThanOrEqual
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateGreaterThanorEqualOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("25-04-1995" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //---Between
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_sel");
                tv.DateChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[5]/div/div/ul/li[6]");
                tv.DateBetweenOpt.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_dob_hdr_txt1");
                tv.FrmDate.SendKeys("28-07-1994");
                tv.ToDate.SendKeys("19-08-1994" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_OperatorsCheck_022")]
        [Test, Order(18)]
        public void OperatorsCheckForNumeric()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17#");
                }
                tv = new TableVisualization(driver);

                //Equal
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[1]");
                tv.NumericEqualToOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //LessThan
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[2]");
                tv.NumericLessThanOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //Greater Than
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[3]");
                tv.NumericGreaterThanOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //LessThanOrEqual
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[4]");
                tv.NumericLessThanorEqualOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //GreaterThanOrEqual
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[5]");
                tv.NumericGreaterThanorEqualOperator.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

                //---Between
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_sel");
                tv.NumericChkButton.Click();
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[8]/div/div/ul/li[6]");
                tv.NumericBetweenOpt.Click();
                elementOps.ExistsId("dvContainer_1586780535084_0_0_salary_hdr_txt1");
                tv.NumericTextField1.SendKeys("10000");
                tv.NumericTextField2.SendKeys("18000" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTag).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
                tv.SearchTagClose.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\" colspan=\"13\" style=\"padding: 2px !important; display: none;\"></td>")));

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        [Property("TestCaseId", "TableVisualization_TreeSearch_008")]
        [Test, Order(19)]
        public void TreeSearch()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=hairocraft_stagging-ebdbjiwavi72zy20200413071346-16-24-24-302-384");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1553959320177_0_0_filter\"]/div/input");
                tv.SearchBar.SendKeys("m");
                Assert.AreEqual("display: none;", tv.TVRowStyle.GetAttribute("style"), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(20)]
        public void AutoDeploy()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
            tv = new TableVisualization(driver);

            elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
            tv.AutogenEntryFields.Click();
            Console.WriteLine("Link Clicked");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            tv.WebFormEditButton.Click();
            Console.WriteLine("Edit Button Clicked");
            browserOps.implicitWait(50);
            string txt = tv.Mode.GetAttribute("innerHTML");
            Assert.AreEqual(txt, "Edit Mode", "Success!! In Edit Mode", "Success!! In Edit Mode");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(21)]
        public void AutoDeployRowGrouping()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
            tv = new TableVisualization(driver);
            
            elementOps.ExistsId("rowgroupDD_dvnull_0_0");
            var selectElement = new SelectElement(tv.AutogenRowGroupingSelect);
            selectElement.SelectByValue("groupbycreatedby");
            browserOps.implicitWait(100);
            Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.AutogenRowGroupingAdditionalRow).ToString(), "Row Grouping Success", "Row Grouping Success");
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(22)]
        public void AutoDeploySearching()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
            tv = new TableVisualization(driver);

            elementOps.ExistsId("dvnull_0_0_course_name_hdr_txt1");
            tv.CourseSearch.SendKeys("B.Tech CSE" + Keys.Enter);
            browserOps.implicitWait(100);
            Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTagCourse).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
            tv.SearchTagCourseClose.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvnull_0_0\" colspan=\"11\" style=\"padding: 2px !important; display: none;\"></td>")));

            elementOps.ExistsId("dvnull_0_0_eb_created_by_hdr_txt1");
            tv.CreatedBySearch.SendKeys("Anoopa Baby" + Keys.Enter);
            browserOps.implicitWait(100);
            Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTagCourse).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
            tv.SearchTagCourseClose.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvnull_0_0\" colspan=\"11\" style=\"padding: 2px !important; display: none;\"></td>")));

            elementOps.ExistsId("dvnull_0_0_eb_created_at_hdr_txt1");
            tv.CreatedAtSearch.SendKeys("05-07-2020" + Keys.Enter);
            browserOps.implicitWait(100);
            Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTagCourse).ToString(), "Success!! Search  Complete", "Success!! Search  Complete");
            tv.SearchTagCourseClose.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("<td id=\"filterdisplayrowtd_dvnull_0_0\" colspan=\"11\" style=\"padding: 2px !important; display: none;\"></td>")));
            Console.WriteLine("AutoDeployed Table search success");
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(23)]
        public void AutoDeployActionColumn()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
            tv = new TableVisualization(driver);

            elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[10]/a");
            tv.AutoGenActionColumnLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            elementOps.ExistsXpath("//*[@id=\"objname\"]/span");
            Assert.AreEqual("View Mode", tv.Mode.GetAttribute("innerHTML"), "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "TableVisualization_PaginationCheck_016")]
        [Test, Order(24)]
        public void PaginationCheck()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0_length\"]/label/select/option[1]");
                if (int.Parse(tv.PaginationSelectOption1.GetAttribute("innerHTML")) == 5)
                {
                    elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                    Console.WriteLine(elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr"));
                    int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr") - 3;
                    Assert.AreEqual(5, val, "Pagination Success", "Pagination Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(25)]
        public void PaginationNext()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
                }
                tv = new TableVisualization(driver);
                string id;
                string table_info;
                int value;
                int last_value;

                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                id = tv.PaginationFirstField.GetAttribute("innerHTML");
                tv.PaginationNextButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button previous\"")));
                Assert.AreNotEqual(id, tv.PaginationFirstField.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[1].Trim());
                last_value = int.Parse(table_info.Split('-', '/')[2].Trim());
                if (value == last_value)
                {
                    Assert.AreEqual("paginate_button next disabled", tv.PaginationNextli.GetAttribute("class"), "Next Button Success", "Next Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button next", tv.PaginationNextli.GetAttribute("class"), "Next Button Success", "Next Button Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(26)]
        public void PaginationPrev()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
                }
                tv = new TableVisualization(driver);
                string id;
                string table_info;
                int value;

                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.PaginationNextButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button previous\"")));
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                id = tv.PaginationFirstField.GetAttribute("innerHTML");
                tv.PaginationPrevButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button previous disabled\"")));
                Assert.AreNotEqual(id, tv.PaginationFirstField.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[0].Trim());
                if (value == 1)
                {
                    Assert.AreEqual("paginate_button previous disabled", tv.PaginationPrevli.GetAttribute("class"), "Previous Button Success", "Previous Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button previous", tv.PaginationPrevli.GetAttribute("class"), "Previous Button Success", "Previous Button Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(27)]
        public void PaginationLast()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-110-110-110-110#");
                }
                tv = new TableVisualization(driver);
                string id;
                string table_info;
                int value;
                int last_value;

                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                id = tv.PaginationFirstField.GetAttribute("innerHTML");
                tv.PaginationLastButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button first\"")));
                Assert.AreNotEqual(id, tv.PaginationFirstField.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[1].Trim());
                last_value = int.Parse(table_info.Split('-', '/')[2].Trim());
                if (value == last_value)
                {
                    Assert.AreEqual("paginate_button last disabled", tv.PaginationLastli.GetAttribute("class"), "Last Button Success", "Last Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button last", tv.PaginationLastli.GetAttribute("class"), "Last Button Success", "Last Button Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(28)]
        public void PaginationFirst()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-33-33-33-33");
                }
                tv = new TableVisualization(driver);
                string id;
                string table_info;
                int value;

                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                tv.PaginationLastButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button first\"")));
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a");
                id = tv.PaginationFirstField.GetAttribute("innerHTML");
                tv.PaginationFirstButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"paginate_button first disabled\"")));
                Assert.AreNotEqual(id, tv.PaginationFirstField.GetAttribute("innerHTML"));
                table_info = tv.PaginationTableInfo.GetAttribute("innerHTML");
                value = int.Parse(table_info.Split('-', '/')[0].Trim());
                if (value == 1)
                {
                    Assert.AreEqual("paginate_button first disabled", tv.PaginationFirstli.GetAttribute("class"), "First Button Success", "First Button Success");
                }
                else
                {
                    Assert.AreEqual("paginate_button first", tv.PaginationFirstli.GetAttribute("class"), "First Button Success", "First Button Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AutoDeploy_014")]
        [Test, Order(29)]
        public void ActionColumnLink()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-33-33-33-33");
                }
                tv = new TableVisualization(driver);
                
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[10]/a");
                tv.AutoGenActionColumnLink.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsXpath("//*[@id=\"objname\"]/span");
                Assert.AreEqual("New Mode", tv.Mode.GetAttribute("innerHTML"), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------

        [Property("TestCaseId", "TableVisualization_FixedColumn_015")]
        [Test, Order(30)]
        public void FixedColumn()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                elementOps.ExistsClass("DTFC_LeftWrapper");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.FixedColumnClass).ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_AppearenceCheck_018")]
        [Test, Order(31)]
        public void AppearenceCheck()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0_wrapper\"]/div[3]/div[2]/div[1]/div/table/thead/tr[1]/th[2]");

                string cls_name = tv.AppearenceChkColumn.GetAttribute("class");
                if (cls_name.Contains("Questrial") && cls_name.Contains("15"))
                    Console.WriteLine("Success!!! Same Font");
                else
                    Console.WriteLine("Faliure!! Change in Font");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_ExtendedMulitline_019")]
        [Test, Order(32)]
        public void ExtendedMulitline()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[1]/td[3]/span");

                Assert.AreEqual("columntooltip", tv.EMulitilineSpan.GetAttribute("class"), "Success!! Extended Mulitiline Feature", "Success!! Extended Mulitiline Feature");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_CheckCreatedBy_021")]
        [Test, Order(33)]
        public void CheckCreatedBy()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                    browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-36-36-36-36");
                }
                tv = new TableVisualization(driver);
                elementOps.ExistsId("dvnull_0_0_eb_created_by_hdr_txt1");
                actions.MoveToElement(tv.CreatedBy);
                actions.Perform();
                tv.CreatedBy.Click();
                tv.CreatedBy.SendKeys("Josevin" + Keys.Enter);
                elementOps.ExistsXpath("//*[@id=\"filterdisplayrowtd_dvnull_0_0\"]/div");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTagCourse).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-99-99-99-99");
                elementOps.ExistsId("dvnull_0_0_eb_created_by_hdr_txt1");
                tv.CreatedBy.SendKeys("Anoopa" + Keys.Enter);
                browserOps.implicitWait(100);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.SearchTagCourse).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_FD_020")]
        [Test, Order(34)]
        public void TVHavingFD()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-64-64-64-64");
                elementOps.ExistsId("name");
                tv.PSName.Click();
                tv.PSName.SendKeys("A" + Keys.Enter);
                elementOps.ExistsXpath("//*[@id=\"filterWindow_dvContainer_1589865744873_0_0_PowerSelect1tbl\"]/tbody/tr[1]/td");
                tv.PSName.SendKeys(Keys.Enter);

                elementOps.ExistsXpath("//*[@id=\"filterWindow_dvContainer_1589865744873_0_0_PowerSelect1name\"]/div/span");
                tv.FDNameTxt.Click();
                tv.FDNameTxt.SendKeys("Anoopa Baby");

                elementOps.SetValue("filterWindow_dvContainer_1589865744873_0_0_Numeric1", "10000");

                string date = elementOps.GetValue("filterWindow_dvContainer_1589865744873_0_0_Date2");
                tv.FDRadioLast_month.Click();
                string date1 = elementOps.GetValue("filterWindow_dvContainer_1589865744873_0_0_Date2");
                Assert.AreNotEqual(date, date1, "Success", "Success");

                //elementOps.SetValue("filterWindow_dvContainer_1589865744873_0_0_Date2", "15-04-2020");
                tv.FDLocationOptionGlobal.Click();
                tv.FDLocationOptionSelect.Click();
                elementOps.ExistsXpath("//*[@id=\"filterWindow_dvContainer_1589865744873_0_0_UserLocation1Wraper\"]/span/div/ul/li[3]/a/label");
                tv.FDLocationOptionKochi.Click();

                elementOps.ExistsId("btnGo");
                tv.RunButton.Click();

                elementOps.ExistsTagName("table");
                int val = int.Parse(elementOps.GetTableRowCountFromJSusingTag("tbody").ToString());
                Console.WriteLine(val);
                Assert.AreEqual("True", (val > 0) ? "True" : "False", "Success", "Success");
                Console.WriteLine(browserOps.ShowConsoleError());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_FDAutoRun_022")]
        [Test, Order(35)]
        public void TVHavingFDAutorun()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-72-72-72-72");

                elementOps.ExistsTagName("table");
                int val = int.Parse(elementOps.GetTableRowCountFromJSusingTag("tbody").ToString());
                Assert.AreEqual("True", (val > 0) ? "True" : "False", "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_FDAutoRun_022")]
        [Test, Order(36)]
        public void TVHavingAPI()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-113-113-113-113");

                elementOps.ExistsId("btnGo");
                tv.RunButton.Click();
                elementOps.ExistsId("dvContainer_1594035574765_0_0");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvContainer_1594035574765_0_0\"]/tbody/tr");
                Console.WriteLine(val);
                Assert.AreEqual("True", (val > 0) ? "True" : "False", "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "TableVisualization_FDAutoRun_022")]
        [Test, Order(36)]
        public void RenderAsImage()
        {
            try
            {
                if (login_status == false)
                {
                    UserLogin();
                    login_status = true;
                }
                tv = new TableVisualization(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-116-116-116-116");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[4]/img");
                
                Assert.AreEqual("True", elementOps.IsWebElementPresent(tv.RenderAsImg).ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        

    }
}
