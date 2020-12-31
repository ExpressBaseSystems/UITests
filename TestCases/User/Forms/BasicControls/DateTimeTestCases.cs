using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Forms.BasicControls;

namespace UITests.TestCases.User.Forms.BasicControls
{
    [TestFixture]
    class DateTimeTestCases : BaseClass
    {
        UserLogin ulog;
        DateTimes d;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.site/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            d = new DateTimes(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.site/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-173-173-173-173");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(1)]
        public void DateTime_Type()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date1");
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string datetime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            string time = DateTime.Now.ToString("hh:mm tt");
            Console.WriteLine(date + "\n" + datetime + "\n" + time);
            Assert.Multiple(() =>
            {
                Assert.True(d.Date1.GetAttribute("value").ToString() == date, "Success", "Success");
                Assert.True(d.Date2.GetAttribute("value").ToString() == datetime, "Success", "Success");
                Assert.True(d.Date3.GetAttribute("value").ToString() == time, "Success", "Success");
            });
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(2)]
        public void DateTime_Date()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date1");
            d.Date1.Clear();
            elementOps.SetValue("Date1", "29-02-2019");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");

            d.Date1.Clear();
            elementOps.SetValue("Date1", "00-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");

            d.Date1.Clear();
            elementOps.SetValue("Date1", "31-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");

            d.Date1.Clear();
            elementOps.SetValue("Date1", "31-00-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");

            d.Date1.Clear();
            elementOps.SetValue("Date1", "31-13-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");

            d.Date1.Clear();
            elementOps.SetValue("Date1", "31-08-0000");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date1.SendKeys(Keys.Tab);
            //Assert.True(d.Date1.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");
            
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(3)]
        public void DateTime_Time()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date3");
            d.Date3.Clear();
            elementOps.SetValue("Date3", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date3');" +
                "element.dispatchEvent(e); ");
            d.Date3.SendKeys(Keys.Tab);
            Assert.True(d.Date3.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");

            d.Date3.Clear();
            elementOps.SetValue("Date3", "00:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date3');" +
                "element.dispatchEvent(e); ");
            d.Date3.SendKeys(Keys.Tab);
            Assert.True(d.Date3.GetAttribute("value").ToString() == "12:00 AM", "Success", "Success");

            d.Date3.Clear();
            elementOps.SetValue("Date3", "25:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date3');" +
                "element.dispatchEvent(e); ");
            d.Date3.SendKeys(Keys.Tab);
            Assert.True(d.Date3.GetAttribute("value").ToString() == DateTime.Now.ToString("hh:mm tt"), "Success", "Success");

            d.Date3.Clear();
            elementOps.SetValue("Date3", "02:60 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date3');" +
                "element.dispatchEvent(e); ");
            d.Date3.SendKeys(Keys.Tab);
            Assert.True(d.Date3.GetAttribute("value").ToString() == DateTime.Now.ToString("hh:mm tt"), "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(4)]
        public void DateTime_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date4");
            Assert.Multiple(() =>
            {
                Assert.True(d.Date4Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(d.Date5Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(5)]
        public void DateTime_Required()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date6");
            Assert.True(elementOps.HasAttribute("Date6", "required"), "Success", "Success");
            d.Date6.Clear();
            d.Date6.SendKeys(Keys.Tab);
            Assert.True(elementOps.HasAttribute("Date6Wraper", "style"), "Success", "Success");
            Assert.True(d.Date6Div.GetAttribute("style").ToString() == "box-shadow: inherit;", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(6)]
        public void DateTime_Validators()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date7");
            elementOps.SetValue("Date7", "01-01-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date7');" +
                "element.dispatchEvent(e); ");
            d.Date7.SendKeys(Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("width: 100%; display: inline-block; padding: 7px 10px; background-color: rgb(255, 255, 255); color: rgb(51, 51, 51); pointer-events: inherit;\"")));
            Assert.True(d.Date7.GetAttribute("value").ToString() == "02-04-2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(7)]
        public void DateTime_AutoCompleteOff()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date8");
            Assert.True(d.Date8.GetAttribute("autocomplete").ToString() == "off", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(8)]
        public void DateTime_IsNullable()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date9");
            Assert.True(d.Date9.GetAttribute("value").ToString() == "", "Success", "Success");
            d.Date9Check.Click();
            Assert.True(d.Date9.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(9)]
        public void DateTime_MaskPattern()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date10");
            Assert.True(d.Date10.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(10)]
        public void DateTime_TimeAsHMS12hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date11");
            elementOps.SetValue("Date11", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date11');" +
                "element.dispatchEvent(e); ");
            d.Date11.SendKeys(Keys.Tab);
            Assert.True(d.Date11.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(11)]
        public void DateTime_TimeAsHMS24hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date12");
            elementOps.SetValue("Date12", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date12');" +
                "element.dispatchEvent(e); ");
            d.Date12.SendKeys(Keys.Tab);
            Assert.True(d.Date12.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(12)]
        public void DateTime_TimeAsHM12hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date13");
            elementOps.SetValue("Date13", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date13');" +
                "element.dispatchEvent(e); ");
            d.Date13.SendKeys(Keys.Tab);
            Assert.True(d.Date13.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(13)]
        public void DateTime_TimeAsHM24hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date14");
            elementOps.SetValue("Date14", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date14');" +
                "element.dispatchEvent(e); ");
            d.Date14.SendKeys(Keys.Tab);
            Assert.True(d.Date14.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(14)]
        public void DateTime_TimeAs12hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date15");
            elementOps.SetValue("Date15", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date15');" +
                "element.dispatchEvent(e); ");
            d.Date15.SendKeys(Keys.Tab);
            Assert.True(d.Date15.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(15)]
        public void DateTime_TimeAs24hr()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date16");
            elementOps.SetValue("Date16", "13:00 AM");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date16');" +
                "element.dispatchEvent(e); ");
            d.Date16.SendKeys(Keys.Tab);
            Assert.True(d.Date16.GetAttribute("value").ToString() == "01:00 PM", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(16)]
        public void DateTime_DateAsYMD()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date17");
            Assert.True(d.Date17.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");
            elementOps.SetValue("Date17", "11-11-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date17');" +
                "element.dispatchEvent(e); ");
            d.Date17.SendKeys(Keys.Tab);
            Assert.True(d.Date17.GetAttribute("value").ToString() == "11-11-2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(17)]
        public void DateTime_DateAsYM()
        {
            CheckUsrLogin();

            elementOps.ExistsId("Date18");
            Assert.True(d.Date18.GetAttribute("value").ToString() == DateTime.Now.ToString("MM/yyyy"), "Success", "Success");
            d.Date18.Click();
            d.Date18MonthPicker.Click();
            d.Date18.SendKeys(Keys.Tab);
            Assert.True(d.Date18.GetAttribute("value").ToString() == "01/2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(18)]
        public void DateTime_DateAsY()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date19");
            Assert.True(d.Date19.GetAttribute("value").ToString() == DateTime.Now.ToString("yyyy"), "Success", "Success");
            d.Date19.Click();
            d.Date19YearPicker.Click();
            d.Date19.SendKeys(Keys.Tab);
            Assert.True(d.Date19.GetAttribute("value").ToString() == "2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(19)]
        public void DateTime_DoNotPersist()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date1");
            d.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", d.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.True(d.Date20.GetAttribute("value").ToString() == DateTime.Now.ToString("dd-MM-yyyy"), "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(20)]
        public void DateTime_DefaultValueExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date21");
            Assert.True(d.Date21.GetAttribute("value").ToString() == "20-01-2001", "Success", "Success");
            elementOps.SetValue("Date21", "11-11-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date21');" +
                "element.dispatchEvent(e); ");
            d.Date21.SendKeys(Keys.Tab);
            Assert.True(d.Date21.GetAttribute("value").ToString() == "11-11-2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(21)]
        public void DateTime_ValueExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date22");
            elementOps.SetValue("Date1", "15-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date22.SendKeys(Keys.Tab);
            Assert.True(d.Date22.GetAttribute("value").ToString() == "11-09-2020", "Success", "Success");

            elementOps.SetValue("Date1", "15-07-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date1');" +
                "element.dispatchEvent(e); ");
            d.Date22.SendKeys(Keys.Tab);
            Assert.True(d.Date22.GetAttribute("value").ToString() == "18-01-2020", "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(22)]
        public void DateTime_OnChange()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date23");
            elementOps.SetValue("Date23", "15-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date23');" +
                "element.dispatchEvent(e); ");
            d.Date23.SendKeys(Keys.Tab);
            Assert.True(d.Date4Div.Displayed, "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(23)]
        public void DateTime_HideExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date24");
            elementOps.SetValue("Date24", "15-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date24');" +
                "element.dispatchEvent(e); ");
            d.Date24.SendKeys(Keys.Tab);
            wait.Until(webDriver => (driver.PageSource.Contains("eb-hidden=\"false\" eb-readonly=\"false\" style=\"margin: 4px; display: none;\"")));
            Assert.True(d.Date24Div.GetAttribute("style").ToString() == "margin: 4px; display: none;", "Success", "Success");

        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(24)]
        public void DateTime_ReadOnlyExpression()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date25");
            elementOps.SetValue("Date25", "15-06-2020");
            elementOps.ExecuteScripts("const e = new Event('change');" +
                "const element = document.querySelector('#Date25');" +
                "element.dispatchEvent(e); ");
            wait.Until(webDriver => (driver.PageSource.Contains("<div id=\"Date25Wraper\" class=\"ctrl-cover\" eb-readonly=\"false\" style=\"pointer-events: none;\" disabled=\"disabled\">")));
            Assert.True(elementOps.HasAttribute("Date25", "disabled"), "Success", "Success");
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(25)]
        public void DateTime_ViewMode()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date1");
            d.Date9Check.Click();
            d.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", d.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");

            Assert.Multiple(() =>
            {
                Assert.True(d.Date1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date4.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date5.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date6.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date12.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date14.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date16.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date17.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date18.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date19.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date20.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date21.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date22.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date23.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date24.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date25.GetAttribute("value").ToString() != "", "Success", "Success");
            });
        }

        [Property("TestCaseId", "DateTime_Type_001")]
        [Test, Order(26)]
        public void DateTime_EditMode()
        {
            CheckUsrLogin();
            elementOps.ExistsId("Date1");
            d.Date9Check.Click();
            d.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", d.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            d.EditButton.Click();
            elementOps.ExistsId("Date1");

            Assert.Multiple(() =>
            {
                Assert.True(d.Date1.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date2.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date3.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date4.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date5.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date6.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date7.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date8.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date9.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date10.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date11.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date12.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date13.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date14.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date15.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date16.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date17.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date18.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date19.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date20.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date21.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date22.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date23.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date24.GetAttribute("value").ToString() != "", "Success", "Success");
                Assert.True(d.Date25.GetAttribute("value").ToString() != "", "Success", "Success");
            });
            d.SaveButton.Click();
        }
    }
}
