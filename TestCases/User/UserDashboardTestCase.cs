using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class UserDashBoardTestCase : BaseClass
    {
        UserLogin ulog;
        UserDashBoard u;

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            u = new UserDashBoard(driver);
            elementOps.ExistsId("quik_menu");
            u.Menu.Click();
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
        }

        [Property("TestCaseId", "UserDashBoard_CheckTV_001")]
        [Test, Order(1)]
        public void CheckTV()
        {
            CheckUsrLogin();
            elementOps.ExistsId("t0");
            elementOps.ExistsXpath("//*[@id=\"tb1tile0\"]/tbody/tr");
            int headings_count = elementOps.GetTableRowCount("//*[@id=\"tb1tile0_wrapper\"]/div[3]/div[1]/div/table/thead/tr/th");
            Assert.AreEqual(true, headings_count > 0 ? true : false, "Success", "Success");
            int row_count = elementOps.GetTableRowCount("//*[@id=\"tb1tile0\"]/tbody/tr");
            Assert.AreEqual(true, row_count > 0 ? true : false, "Success", "Success");
            Console.WriteLine("Table Visualization Present");
        }

        [Property("TestCaseId", "UserDashBoard_CheckChart_001")]
        [Test, Order(2)]
        public void CheckChart()
        {
            CheckUsrLogin();
            elementOps.ExistsId("t1");
            elementOps.ExistsXpath("//*[@id=\"canvasDivtb1tile1\"]/iframe");
            Assert.AreEqual("True", elementOps.IsWebElementPresent(u.ChartIFrame).ToString(), "Success", "Success");
            Console.WriteLine("Chart Present");
        }

        [Property("TestCaseId", "UserDashBoard_CheckDataLabel_001")]
        [Test, Order(3)]
        public void CheckDataLabel()
        {
            CheckUsrLogin();
            elementOps.ExistsId("t2");
            Assert.AreEqual("fa fa-users", u.DataLabelIcon.GetAttribute("class"), "Success", "Success");
            Assert.AreEqual("True", elementOps.IsWebElementPresent(u.DataLabelDiv).ToString(), "Success", "Success");
            Assert.AreEqual("Users", u.DataLabelStatic.GetAttribute("innerHTML"), "Success", "Success");
            Assert.AreEqual("", u.DataLabelDesc.GetAttribute("innerHTML"), "Success", "Success");
            Assert.AreNotEqual("", u.DataLabelDynamic.GetAttribute("innerHTML"), "Success", "Success");
            Assert.AreEqual("True", elementOps.IsWebElementPresent(u.DataLabelFooter).ToString(), "Success", "Success");
            Console.WriteLine("Data Label Present");
        }

        [Property("TestCaseId", "UserDashBoard_CheckLinkToWebForm_001")]
        [Test, Order(4)]
        public void CheckLinkToWebForm()
        {
            CheckUsrLogin();
            elementOps.ExistsId("t3");
            Assert.AreEqual("fa fa-external-link-square", u.LinkToWebFormIcon.GetAttribute("class"), "Success", "Success");
            Assert.AreEqual("True", elementOps.IsWebElementPresent(u.LinkToWebFormLink).ToString(), "Success", "Success");
            u.LinkToWebFormLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            elementOps.ExistsClass("fmode");
            Assert.AreEqual("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-14-14-14-14", driver.Url, "Success", "Success");
            Assert.AreEqual("New Mode", u.FormMode.GetAttribute("innerHTML"), "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Console.WriteLine("Link To WebForm Working");
        }

        [Property("TestCaseId", "UserDashBoard_CheckAppearance_001")]
        [Test, Order(5)]
        public void CheckAppearance()
        {
            CheckUsrLogin();
            elementOps.ExistsId("layout_div");
            Assert.AreEqual("background-image: linear-gradient(to right bottom, rgb(140, 138, 255), rgb(255, 255, 255));", u.LayoutDiv.GetAttribute("style"), "Success", "Success");
        }

        [Property("TestCaseId", "UserDashBoard_BrowseTV_001")]
        [Test, Order(6)]
        public void BrowseTV()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_link_tile0");
            u.TVBrowseLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-17-17-17-17", driver.Url, "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "UserDashBoard_RefreshTV_001")]
        [Test, Order(7)]
        public void RefreshTV()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_restart_tile0");
            u.UDTVRefresh.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"tb1tile0_processing\" class=\"dataTables_processing panel panel-default\" style=\"display: none;\"")));
            int headings_count = elementOps.GetTableRowCount("//*[@id=\"tb1tile0_wrapper\"]/div[3]/div[1]/div/table/thead/tr/th");
            Assert.AreEqual(true, headings_count > 0 ? true : false, "Success", "Success");
            int row_count = elementOps.GetTableRowCount("//*[@id=\"tb1tile0\"]/tbody/tr");
            Assert.AreEqual(true, row_count > 0 ? true : false, "Success", "Success");
            Console.WriteLine("Table Visualization Present");
        }

        [Property("TestCaseId", "UserDashBoard_BrowseChart_001")]
        [Test, Order(8)]
        public void BrowseChart()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_link_tile1");
            u.ChartBrowseLink.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-17-37-37-37-37", driver.Url, "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "UserDashBoard_RefreshChart_001")]
        [Test, Order(9)]
        public void RefreshChart()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_restart_tile1");
            u.ChartRefresh.Click();
            elementOps.ExistsXpath("//*[@id=\"canvasDivtb1tile1\"]/iframe");
            Console.WriteLine("Chart Present");
        }

        [Property("TestCaseId", "UserDashBoard_LinkDashBoard_001")]
        [Test, Order(10)]
        public void LinkDashBoard()
        {
            CheckUsrLogin();
            elementOps.ExistsId("tbundefinedLinks1_link");
            actions = new Actions(driver);
            actions.MoveToElement(u.LinkToDashBoard);
            actions.Perform();
            u.LinkToDashBoard.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://uitesting.eb-test.cloud/DashBoard/DashBoardView?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-22-128-128-128-128", driver.Url, "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "UserDashBoard_LinkDashBoardHavingFD_001")]
        [Test, Order(11)]
        public void LinkDashBoardHavingFD()
        {
            CheckUsrLogin();
            elementOps.ExistsId("tbundefinedLinks2_link");
            actions = new Actions(driver);
            actions.MoveToElement(u.LinkToDashBoardFD);
            actions.Perform();
            u.LinkToDashBoardFD.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://uitesting.eb-test.cloud/DashBoard/DashBoardView?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-22-130-130-130-130", driver.Url, "Success", "Success");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            elementOps.ExistsId("filter-dg");
            u.FDButton.Click();
            elementOps.ExistsId("paramdiv_PowerSelect1name");
            elementOps.ExistsId("btnGo");
            browserOps.ClickableWait(u.RunButton);
            u.RunButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"tb1tile0_processing\" class=\"dataTables_processing panel panel-default\" style=\"display: none;\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"tb1tile0\"]/tbody/tr") > 0, "Success", "Success");

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "UserDashBoard_CheckGoogleMap_001")]
        [Test, Order(12)]
        public void CheckGoogleMap()
        {
            CheckUsrLogin();
            elementOps.ExistsId("t6");
            Assert.AreEqual("True", elementOps.IsWebElementPresent(u.GoogleMapDiv).ToString(), "Success", "Success");
            Console.WriteLine("Map Present");
        }

        [Property("TestCaseId", "UserDashBoard_BrowseGoogleMap_001")]
        [Test, Order(13)]
        public void BrowseGoogleMap()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_link_tile6");
            u.GoogleMapBrowser.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-21-134-134-134-134", driver.Url, "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Property("TestCaseId", "UserDashBoard_RefreshGoogleMap_001")]
        [Test, Order(14)]
        public void RefreshGoogleMap()
        {
            CheckUsrLogin();
            elementOps.ExistsId("undefined_restart_tile6");
            u.GoogleMapRefreshButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            elementOps.ExistsXpath("//*[@id=\"tile6\"]/div[2]");
            Console.WriteLine("Map Present");
        }

        [Property("TestCaseId", "UserDashBoard_SwitchDashBoard_001")]
        [Test, Order(15)]
        public void SwitchDashBoard()
        {
            CheckUsrLogin();
            elementOps.ExistsId("UserDashBoardSwitchBtn");
            u.DashBoardDropDownButton.Click();
            elementOps.ExistsId("UserDashBoardSwitchList");
            u.DropDownDashBoard2.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            Assert.Multiple(() =>
            {
                Assert.True(elementOps.IsWebElementPresent(u.DashBoard2DataLabel), "Success", "Success");
                Assert.True(elementOps.IsWebElementPresent(u.TV1), "Success", "Success");
            });
        }
    }
}
