using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class LocationTestCase : BaseClass
    {
        Location loc;
        UserLogin ulog;
        string subloc = null;

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            loc = new Location(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
                browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            }
        }

        [Property("TestCaseId", "Location_AddRootLocation_001")]
        [Test, Order(1)]
        public void AddRootLocation()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr");
            elementOps.ExistsId("add_root_loc");
            loc.AddNewRootLocation.Click();
            elementOps.ExistsId("loc_type");
            var selectElement = new SelectElement(loc.LocType);
            selectElement.SelectByValue("3");
            loc.LocName.SendKeys("AATest Loc " + id.GetId);
            loc.LocShortName.SendKeys("TL");
            //elementOps.ExistsName("Logo");
            //loc.Logo.SendKeys("C:\\Users\\user\\Pictures\\kerala.jpg");
            loc.AddLocButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr") > val, "Success", "Success");
        }

        [Property("TestCaseId", "Location_AddSubLocation_001")]
        [Test, Order(2)]
        public void AddSubLocation()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr");
            loc.LocField6.Click();
            actions.ContextClick(loc.LocField6);
            actions.Perform();
            elementOps.ExistsXpath("/html/body/ul/li");
            loc.AddSubLoc.Click();
            elementOps.ExistsXpath("//*[@id=\"loc_type\"]/option[4]");
            var selectElement = new SelectElement(loc.LocType);
            selectElement.SelectByValue("3");
            subloc = "Test Loc" + id.GetId;
            loc.LocName.SendKeys(subloc);
            loc.LocShortName.SendKeys("TL");
            //elementOps.ExistsName("Logo");
            //loc.Logo.SendKeys("C:\\Users\\user\\Pictures\\kerala.jpg");
            loc.AddLocButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr") > val, "Success", "Success");
        }

        [Property("TestCaseId", "Location_EditLocation_001")]
        [Test, Order(3)]
        public void EditLocation()
        {
            CheckUsrLogin();
            elementOps.ExistsXpath("//*[@id=\"tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr");
            elementOps.ExistsXpath("//*[@id=\"tbl\"]/tbody/tr[7]/td[1]");
            wait.Until(webDriver => (driver.PageSource.Contains(subloc)));
            loc.LocField7.Click();
            actions = new Actions(driver);
            actions.ContextClick(loc.LocField7);
            actions.Perform();
            elementOps.ExistsXpath("/html/body/ul/li[2]");
            loc.EditSubLoc.Click();
            elementOps.ExistsId("loc_type");
            var selectElement = new SelectElement(loc.LocType);
            selectElement.SelectByValue("2");
            loc.LocName.Clear();
            loc.LocName.SendKeys("Test Loc 1" + id.GetId);
            loc.LocShortName.Clear();
            loc.LocShortName.SendKeys("TL");
            //elementOps.ExistsName("Logo");
            //loc.Logo.SendKeys("C:\\Users\\user\\Pictures\\kerala.jpg");
            loc.AddLocButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr") == val, "Success", "Success");
            browserOps.Refresh();
        }

        [Property("TestCaseId", "Location_MoveSubLocation_001")]
        [Test, Order(4)]
        public void MoveSubLocation()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr");
            browserOps.ClickableWait(loc.LocField7);
            loc.LocField7.Click();
            actions = new Actions(driver);
            actions.ContextClick(loc.LocField7).Build();
            actions.Perform();
            elementOps.ExistsXpath("/html/body/ul/li");
            loc.MoveSubLoc.Click();

            elementOps.ExistsClass("treemodalul");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("treemodalul")));
            loc.MoveGroupButton.Click();
            elementOps.ExistsXpath("/html/body/ul/li[5]");
            actions = new Actions(driver);
            actions.MoveToElement(loc.MoveGroup);
            actions.Perform();
            loc.MoveGroup.Click();
            loc.MoveButton.Click();

            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"tbl\"]/tbody/tr") == val, "Success", "Success");
            browserOps.Refresh();
        }

        [Property("TestCaseId", "Location_AddLocationType_001")]
        [Test, Order(5)]
        public void AddLocationType()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[2]/a");
            loc.LocationTypeTab.Click();
            elementOps.ExistsXpath("//*[@id=\"types-space\"]/table/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"types-space\"]/table/tbody/tr");
            elementOps.ExistsId("add_location_type");
            loc.AddLocationType.Click();
            elementOps.ExistsName("TypeName");
            loc.LocationTypeName.SendKeys("Test Location Type");
            loc.LocationTypeAddButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            var alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.True(elementOps.GetTableRowCount("//*[@id=\"types-space\"]/table/tbody/tr") > val, "Success", "Success");
        }

        [Property("TestCaseId", "Location_EditLocationType_001")]
        [Test, Order(6)]
        public void EditLocationType()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[2]/a");
            loc.LocationTypeTab.Click();
            elementOps.ExistsXpath("//*[@id=\"types-space\"]/table/tbody/tr[4]/td[4]/i");
            string LocTypeName = loc.LocationTypeNameVal.GetAttribute("innerHTML");
            loc.EditLocationType.Click();
            elementOps.ExistsName("TypeName");
            loc.LocationTypeName.Clear();
            loc.LocationTypeName.SendKeys("Test Location Type1");
            loc.LocationTypeAddButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
            Assert.True(loc.LocationTypeNameVal.GetAttribute("innerHTML") != LocTypeName, "Success", "Success");
        }

        [Property("TestCaseId", "Location_RemoveLocationType_001")]
        [Test, Order(7)]
        public void RemoveLocationType()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[2]/a");
            loc.LocationTypeTab.Click();
            elementOps.ExistsXpath("//*[@id=\"types-space\"]/table/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"types-space\"]/table/tbody/tr");
            elementOps.ExistsXpath("//*[@id=\"types-space\"]/table/tbody/tr[4]/td[4]/i");
            loc.RemoveLocationType.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id=\"types-space\"]/table/tbody/tr[4]")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"types-space\"]/table/tbody/tr") < val, "Success", "Success");
        }

        [Property("TestCaseId", "Location_AddCustomField_001")]
        [Test, Order(8)]
        public void AddCustomField()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[3]/a");
            loc.CustomizeTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
            elementOps.ExistsXpath("//*[@id=\"textspace\"]/table/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"textspace\"]/table/tbody/tr");
            elementOps.ExistsId("addkey");
            loc.AddCustomFieldButton.Click();
            elementOps.ExistsName("KeyName");
            browserOps.ClickableWait(loc.CustomFieldName);
            loc.CustomFieldName.SendKeys("Test Field " + id.GetId);
            loc.CustomFieldRequired.Click();
            var selectElement = new SelectElement(loc.CustomFieldType);
            selectElement.SelectByValue("Text");
            loc.CustomFieldAdd.Click();
            wait.Until(webDriver => (!driver.PageSource.Contains("class=\"modal-backdrop fade in\"")));
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"textspace\"]/table/tbody/tr") > val, "Success", "Success");
        }

        [Property("TestCaseId", "Location_CheckCustomField_001")]
        [Test, Order(9)]
        public void CheckCustomField()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsId("add_root_loc");
            loc.AddNewRootLocation.Click();
            elementOps.ExistsId("loc_type");

            Assert.True(elementOps.IsWebElementPresent(loc.CustomFieldInput), "Success", "Success");
        }

        [Property("TestCaseId", "Location_CustomFieldRequired_001")]
        [Test, Order(10)]
        public void CustomFieldRequired()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsId("add_root_loc");
            loc.AddNewRootLocation.Click();
            elementOps.ExistsId("loc_type");
            browserOps.ClickableWait(loc.AddLocButton);
            loc.AddLocButton.Click();
            var alert = driver.SwitchTo().Alert();
            Assert.True(alert.Text.Contains("Required field is empty"), "Success", "Success");
            alert.Accept();
        }

        [Property("TestCaseId", "Location_RemoveCustomField_001")]
        [Test, Order(11)]
        public void RemoveCustomField()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsXpath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[3]/a");
            loc.CustomizeTab.Click();
            elementOps.ExistsXpath("//*[@id=\"textspace\"]/table/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"textspace\"]/table/tbody/tr");
            elementOps.ExistsXpath("//*[@id=\"textspace\"]/table/tbody/tr[4]/td[4]/i");
            loc.RemoveCustomField.Click();
        }

        [Property("TestCaseId", "Location_LocationSwitcher_001")]
        [Test, Order(12)]
        public void LocationSwitcher()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsId("switch_loc");
            string loc1 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationKochi.Click();
            loc.LocationSubmitButton.Click();
            string loc2 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            Assert.True(loc1 != loc2, "Success", "Success");
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationDefault.Click();
            loc.LocationSubmitButton.Click();
        }

        [Property("TestCaseId", "Location_LocationSwitcher_002")]
        [Test, Order(13)]
        public void LocationSwitcherTree()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsId("switch_loc");
            string loc1 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationSwitcherTreei.Click();
            elementOps.ExistsXpath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[2]/ul/li[1]/a");
            loc.LocationSwitcherTreeLoc.Click();
            loc.LocationSubmitButton.Click();
            string loc2 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            Assert.True(loc1 != loc2, "Success", "Success");
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationDefault.Click();
            loc.LocationSubmitButton.Click();
        }

        [Property("TestCaseId", "Location_LocationSwitcher_003")]
        [Test, Order(14)]
        public void LocationSwitcherSearch()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/TenantUser/EbLocations");
            elementOps.ExistsId("switch_loc");
            string loc1 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationSearch.SendKeys("Tri");
            loc.LocationDefault.Click();
            loc.LocationSubmitButton.Click();
            string loc2 = loc.CurrentLocationName.GetAttribute("innerHTML").ToString();
            Assert.True(loc1 != loc2, "Success", "Success");
            loc.LocationSwitcherTab.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"loc_switchModal\" style=\"display: block;\"")));
            loc.LocationDefault.Click();
            loc.LocationSubmitButton.Click();
        }

    }
}
