using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    class FormTestCase : BaseClass
    {
        UserLogin ulog;
        Form f;

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public void ChooseForm()
        {
            f = new Form(driver);
            elementOps.ExistsXpath("//*[@id=\"appList\"]/div/ul/li/ul/li[8]/a");
            f.SelectApp.Click();
            elementOps.ExistsXpath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[3]");
            actions.MoveToElement(f.SelectTableView).Perform();
            f.SelectTableView.Click();
            elementOps.ExistsXpath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[10]");
            actions.MoveToElement(f.SelectTableVisualizationDataPusherChild).Perform();
            f.SelectTableVisualizationDataPusherChild.Click();
        }

        [Property("TestCaseId", "Form_DataPusher_001")]
        [Test, Order(1)]
        public void DataPusher()
        {
            try
            {
                UserLogin();
                ChooseForm();
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val);

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book");
                f.ChildBookDesc.SendKeys("Test Book Desc");
                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val1);
                Assert.AreEqual(val + 1, val1, "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DataPusherPushOnlyIf_001")]
        [Test, Order(2)]
        public void DataPusherPushOnlyIf()
        {
            try
            {
                UserLogin();
                ChooseForm();
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val);

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book 1");
                f.ChildBookDesc.SendKeys("Test Book 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"dvnull_0_0\"]/tbody/tr");
                Console.WriteLine(val1);
                Assert.AreEqual(val, val1, "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableDelete_001")]
        [Test, Order(3)]
        public void DisableDelete()
        {
            try
            {
                UserLogin();
                ChooseForm();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-88-88-88-88");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformdelete");
                Console.WriteLine("Success 1");
                Assert.AreEqual("False", f.DeleteButton.Enabled.ToString(), "Success", "Success");
                Console.WriteLine("Success 1");

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformdelete");
                Assert.AreEqual("True", f.DeleteButton.Enabled.ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableCancel_001")]
        [Test, Order(4)]
        public void DisableCancel()
        {
            try
            {
                UserLogin();
                ChooseForm();

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-88-88-88-88");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformcancel");
                Console.WriteLine("Success 1");
                Assert.AreEqual("False", f.CancelButton.Enabled.ToString(), "Success", "Success");
                Console.WriteLine("Success 1");

                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-85-85-85-85");
                elementOps.ExistsXpath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a");
                f.ActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("webformcancel");
                Assert.AreEqual("True", f.CancelButton.Enabled.ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_DisableCancel_001")]
        [Test, Order(4)]
        public void BeforeSaveRoutine()
        {
            try
            {
                UserLogin();
                ChooseForm();

                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-86-86-86-86");
                elementOps.ExistsId("TextBox1");
                f.ChildBookName.SendKeys("Test Book 1");
                f.ChildBookDesc.SendKeys("Test Book 1 Desc");
                elementOps.SetValue("Numeric1", "25");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); ");
                browserOps.implicitWait(50);
                f.SaveButton.Click();

                var alert = driver.SwitchTo().Alert();
                Assert.AreEqual("Hello", alert.Text, "Success", "Success");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
