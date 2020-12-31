using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.Bot.ObjectRepository;
using UITests.DataDriven;

namespace UITests.Bot.TestCases
{
    [TestFixture]
    class BotFormTestCases : BaseClass
    {
        ChatBot b;

        [Property("TestCaseId", "Bot_CheckBotWebformIcon_001")]
        [Test, Order(1)]
        public void CheckBotWebformIcon()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button");
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("fa fa-users", b.Form1Icon.GetAttribute("class").ToString(), "Success", "Success");
                    Assert.True(b.Form1ChooseButton.GetAttribute("innerHTML").Contains("User Location Bot "), "Success!!", "Success!!");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotWebform_001")]
        [Test, Order(2)]
        public void CheckBotWebform()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button");
                b.Form1ChooseButton.Click();
                elementOps.ExistsId("TextBox1");
                b.TextBox1.Clear();
                b.TextBox1.SendKeys("Test User");
                //html/body/div[2]/div[3]/div/div/div/div/div[2]/button
                b.TextBoxSubmitButton.Click();
                elementOps.ExistsId("InputGeoLocation1address");
                b.LocationAddress.SendKeys("Mulan" + Keys.Down + Keys.Enter);
                b.LocationAddressButton.Click();
                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotTV_001")]
        [Test, Order(3)]
        public void CheckBotTV()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[2]");
                b.Form2ChooseButton.Click();
                elementOps.ExistsXpath("//*[@id=\"TVcontrol1\"]/tbody/tr[1]");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"TVcontrol1\"]/tbody/tr");
                Assert.True(val1 > 0, "Success!!", "Success!!");
                b.TVcontrol1SubmitButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotWebForm1_001")]
        [Test, Order(4)]
        public void CheckBotWebForm1()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[6]");
                b.Form6ChooseButton.Click();

                elementOps.ExistsId("cont_Image1");
                Assert.True(elementOps.IsWebElementPresent(b.Image1), "Success!!", "Success!!");
                b.Image1Button.Click();
                elementOps.ExistsId("cont_Video1");
                Assert.True(elementOps.IsWebElementPresent(b.Video1), "Success!!", "Success!!");
                b.Video1Button.Click();
                elementOps.ExistsId("cont_Rating1");
                elementOps.ChangeStyleByClassNameJQuery("jq-ry-rated-group", "style", "width: 57.8947%");
                b.Rating1Button.Click();
                elementOps.ExistsId("TextBox1");
                b.TextBox1.SendKeys("Test User" + Keys.Enter);
                elementOps.ExistsId("SimpleFileUploader1_inputID");
                b.ImageInput1.SendKeys("C:\\Users\\user\\Pictures\\code1.png");
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check-circle-o success\" style=\"display: inline;\"")));
                b.ImageInput1Button.Click();
                elementOps.ExistsId("EmailControl1");
                b.EmailControl1.SendKeys("uitest@gmail.com");
                b.EmailControl1Button.Click();
                elementOps.ExistsId("BooleanSelect1");
                var selectElement = new SelectElement(b.BooleanSelect1);
                selectElement.SelectByValue("true");
                b.BooleanSelect1Button.Click();
                elementOps.ExistsId("Locations1");
                var selectElement2 = new SelectElement(b.LocationsSelect);
                selectElement2.SelectByValue("kochi");
                elementOps.ExistsXpath("//*[@id=\"cont_Locations1\"]/following-sibling::div/div");
                b.Locations1SubmitButton.Click();
                elementOps.ExistsId("InputGeoLocation1address");
                b.LocationAddress.Clear();
                b.LocationAddress.SendKeys("Mulan");
                browserOps.implicitWait(100);
                b.LocationAddress.SendKeys(Keys.Down + Keys.Enter);
                actions.MoveToElement(b.LocationAddressButton);
                actions.Perform();
                b.LocationAddressButton.Click();
                elementOps.ExistsId("Phone1");
                b.Phone1.SendKeys("8123456789");
                b.Phone1Button.Click();
                elementOps.ExistsId("Date1");
                b.Date1.Click();
                b.Date1.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace);
                b.Date1.SendKeys("23-03-1994");
                b.Date1Button.Click();
                elementOps.ExistsId("RadioGroup1");
                b.RadioGroup1Value.Click();
                b.RadioGroup1Button.Click();
                elementOps.ExistsXpath("//*[@id=\"ButtonSelect1\"]/div[1]");
                b.ButtonSelect1.Click();
                elementOps.ExistsId("SimpleSelect1");
                var selectElement1 = new SelectElement(b.SimpleSelect1);
                selectElement1.SelectByValue("eggitarian");
                b.SimpleSelect1Button.Click();
                elementOps.ExistsId("RadioButton2");
                b.RadioButton2.Click();
                b.RadioButton2Button.Click();
                elementOps.ExistsClass("slick-next");
                b.StaticCardSet2NextButton.Click();
                actions = new Actions(driver);
                actions.MoveToElement(b.StaticCardSet2SubmitButton);
                actions.Perform();
                b.StaticCardSet2SubmitButton.Click();
                elementOps.ExistsId("Numeric1");
                elementOps.SetValue("Numeric1", "123");
                elementOps.ExecuteScripts("const e = new Event('change');" +
                    "const element = document.querySelector('#Numeric1');" +
                    "element.dispatchEvent(e); " +
                    "$(element).trigger('change');");
                b.Numeric1Button.Click();

                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[4]/div/div/div/button[6]");
                Assert.True(b.FormSubmitSuccessMsg.GetAttribute("innerHTML").Contains("Your User Registration submitted successfully"), "Success!!", "Success!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotWebForm1Visualizations_001")]
        [Test, Order(4)]
        public void CheckBotWebForm1Visualizations()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[7]");
                b.Form7ChooseButton.Click();

                elementOps.ExistsXpath("//*[@id=\"TVcontrol1\"]/tbody/tr[1]");
                int val1 = elementOps.GetTableRowCount("//*[@id=\"TVcontrol1\"]/tbody/tr");
                Assert.True(val1 > 0, "Success!!", "Success!!");
                b.TVcontrol1SubmitButton.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
