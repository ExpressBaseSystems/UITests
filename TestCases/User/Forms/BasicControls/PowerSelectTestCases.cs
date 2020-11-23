using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Forms.BasicControls;

namespace UITests.TestCases.User.Forms.BasicControls
{
    [TestFixture]
    class PowerSelectTestCases : BaseClass
    {
        UserLogin ulog;
        PowerSelect p;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            p = new PowerSelect(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-189-189-189-189");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(1)]
        public void PowerSelect_DataFromAPIPreload()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect1email");
            p.PowerSelect1Input.SendKeys("v");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect1tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 2, "Success", "Success");
            p.PowerSelect1Input.SendKeys(Keys.Backspace);
            elementOps.ExistsXpath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr[3]");
            val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect1tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 6, "Success", "Success");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect1Value);
            actions.Perform();
            p.PowerSelect1ValueClose.Click();
            Assert.True(p.PowerSelect1.GetAttribute("value") =="", "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(2)]
        public void PowerSelect_DataFromAPI()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect2email");
            p.PowerSelect2Input.SendKeys("v");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect2tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect2tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 6, "Success", "Success");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect2Value);
            actions.Perform();
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(3)]
        public void PowerSelect_PreloadItems()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect3name");
            p.PowerSelect3Input.SendKeys("v");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect3tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect3tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 3, "Success", "Success");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect3Value);
            actions.Perform();
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(4)]
        public void PowerSelect_PreloadItemsOff()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect4name");
            p.PowerSelect4Input.SendKeys("v");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect4tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect4tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 3, "Success", "Success");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect4Value);
            actions.Perform();
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(5)]
        public void PowerSelect_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("cont_PowerSelect5");
            Assert.Multiple(() =>
            {
                Assert.True(p.PowerSelect5Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(p.PowerSelect9Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(6)]
        public void PowerSelect_DropDownItemLimit()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect6name");
            p.PowerSelect6Input.SendKeys("f");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect6tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect6tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val == 3, "Success", "Success");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect6Value);
            actions.Perform();
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(7)]
        public void PowerSelect_HideExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect7name");
            p.PowerSelect7Input.SendKeys("r");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect7tbl\"]/tbody/tr");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect7Value);
            actions.Perform();
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"false\" style=\"margin: 4px; display: none;\"")));
            Assert.True(p.PowerSelect7Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(8)]
        public void PowerSelect_ReadOnlyExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect8name");
            p.PowerSelect8Input.SendKeys("r");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect8tbl\"]/tbody/tr");
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect8Value);
            actions.Perform();
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"true\" style=\"margin: 4px;\"")));
            Assert.True(p.PowerSelect8Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(9)]
        public void PowerSelect_MultiSelectMaxSelect()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect10name");
            p.PowerSelect10Input.SendKeys("r");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect10tbl\"]/tbody/tr");
            p.PowerSelect10Value1.Click();
            p.PowerSelect10Value1.SendKeys(Keys.Enter);
            elementOps.ExistsXpath("//*[@id=\"PowerSelect10name\"]/div/span");
            Assert.True(elementOps.IsWebElementPresent(p.PowerSelect10Span), "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(10)]
        public void PowerSelect_MultiSelect()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect10name");
            p.PowerSelect10Input.SendKeys("r");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect10tbl\"]/tbody/tr");
            p.PowerSelect10Value1.Click();
            p.PowerSelect10Value2.Click();
            p.PowerSelect10Value2.SendKeys(Keys.Enter);
            elementOps.ExistsXpath("//*[@id=\"PowerSelect10name\"]/div/span");
            Assert.True(elementOps.GetTableRowCount("//*[@id=\"PowerSelect10name\"]/div/span")==2, "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(11)]
        public void PowerSelect_Required()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect13name");
            p.PowerSelect13Input.SendKeys("r");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect13tbl\"]/tbody/tr");
            p.PowerSelect14Input.Click();
            Assert.True(p.PowerSelect13Div.GetAttribute("style").ToString() == "min-height: 34px; border: 1px solid rgb(255, 0, 0);", "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(12)]
        public void PowerSelect_MiniSearchLength()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect16name");
            p.PowerSelect16Input.SendKeys("ano");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect16tbl\"]/tbody/tr");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect16tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val > 0, "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_ValueExpression()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect19name");
            p.PowerSelect19Input.SendKeys("ano");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect19tbl\"]/tbody/tr");
            p.PowerSelect19Input.SendKeys(Keys.Enter);
            elementOps.ExistsXpath("//*[@id=\"PowerSelect19name\"]/div/span");
            Assert.True(p.PowerSelect19Span.GetAttribute("innerHTML").Contains("Josevin Kodiyan"), "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_OnChange()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect21name");
            p.PowerSelect21Input.SendKeys("ano");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect21tbl\"]/tbody/tr");
            p.PowerSelect21Input.SendKeys(Keys.Enter);
            elementOps.ExistsXpath("//*[@id=\"PowerSelect21name\"]/div/span");
            Assert.True(p.PowerSelect21Span.GetAttribute("innerHTML").Contains("Anoopa Baby"), "Success", "Success");
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"true\" eb-readonly=\"false\" style=\"margin: 4px; display: block;\"")));
            Assert.True(p.PowerSelect5Div.GetAttribute("style")== "margin: 4px; display: block;", "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_IsInsertable()
        {
            CheckUsrLogin();

            elementOps.ExistsId("PowerSelect22name");
            Assert.True(elementOps.IsWebElementPresent(p.PowerSelect22AddBtn), "Success", "Success");
            p.PowerSelect22AddBtn.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.True(driver.Title == "User Creation(New Mode)", "Success", "Success");
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        //-------------------

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_TestGetColumn()
        {
            CheckUsrLogin();
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-190-190-190-190");

            elementOps.ExistsId("PowerSelect1emailid");
            p.PowerSelect1Input1.SendKeys("a");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr");
            p.PowerSelect1Input1.SendKeys(Keys.Enter);
            p.TextBox4.Click();
            p.PowerSelect2Input1.SendKeys("a");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect2tbl\"]/tbody/tr");
            p.PowerSelect2Input1.SendKeys(Keys.Enter);
            p.TextBox6.Click();
            p.PowerSelect3Input1.SendKeys("a");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect3tbl\"]/tbody/tr");
            p.PowerSelect3Input1.SendKeys(Keys.Enter);
            p.TextBox10.Click();
            p.PowerSelect4Input1.SendKeys("f");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect4tbl\"]/tbody/tr");
            p.PowerSelect4Input1.SendKeys(Keys.Enter);
            p.TextBox13.Click();
            p.PowerSelect6Input1.SendKeys("1");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect6tbl\"]/tbody/tr");
            p.PowerSelect6Input1.SendKeys(Keys.Enter);
            p.Numeric2.Click();
            p.PowerSelect7Input1.SendKeys("1");
            elementOps.ExistsXpath("//*[@id=\"PowerSelect7tbl\"]/tbody/tr");
            p.PowerSelect7Input1.SendKeys(Keys.Enter);
            p.Date2.Click();
            
            int numeric1 = Int32.Parse(GetVal(p.PowerSelect6Input1Span.GetAttribute("innerHTML").Replace(",", "")));
            int numeric2 = Int32.Parse(GetVal(p.PowerSelect6Input2Span.GetAttribute("innerHTML").Replace(",", "")));
            int expected_result = numeric1 + numeric2;
            Console.WriteLine(numeric2);
            int result = Int32.Parse(p.Numeric2.GetAttribute("value").Split(".")[0].Replace(",",""));
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(p.TextBox4.GetAttribute("value"), p.TextBox5.GetAttribute("value"), "Success", "Success");
                Assert.AreEqual(p.TextBox6.GetAttribute("value"), p.TextBox9.GetAttribute("value"), "Success", "Success");
                Assert.AreEqual(p.TextBox10.GetAttribute("value"), p.TextBox12.GetAttribute("value"), "Success", "Success");
                Assert.AreEqual(p.TextBox13.GetAttribute("value"), p.TextBox14.GetAttribute("value"), "Success", "Success");
                Assert.True(p.TextBox13Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");
                Assert.AreEqual(expected_result, result, "Success", "Success");
            });
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_IsDataFromAPI()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric1");
            p.Numeric1.SendKeys("100"+Keys.Tab);
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect1);
            actions.Perform();
            elementOps.ExistsXpath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr[3]");
            int val = elementOps.GetTableRowCount("//*[@id=\"PowerSelect1tbl\"]/tbody/tr");
            Console.WriteLine(val);
            Assert.True(val>0, "Success", "Success");
        }

        [Property("TestCaseId", "PowerSelect_Behaviour_001")]
        [Test, Order(13)]
        public void PowerSelect_ImportDataFromAPI()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Numeric1");
            p.Numeric1.SendKeys("100" + Keys.Tab);
            actions = new Actions(driver);
            actions.DoubleClick(p.PowerSelect1);
            actions.Perform();
            elementOps.ExistsXpath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr[3]");
            p.PowerSelect1Value.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
        }

        public string GetVal(string str)
        {
            Regex regex = new Regex(@"\d+");
            MatchCollection matches = regex.Matches(str);
            return matches[0].ToString();
        }
    }
}
