using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.Bot.ObjectRepository;

namespace UITests.Bot.TestCases
{
    [TestFixture]
    class BotAppearanceTestCases : BaseClass
    {
        ChatBot b;

        [Property("TestCaseId", "Bot_CheckBotRender_001")]
        [Test, Order(1)]
        public void CheckBotRender()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("True", elementOps.IsWebElementPresent(b.BotFrame).ToString(), "Success!!", "Success!!");
                    Assert.AreEqual("True", elementOps.IsWebElementPresent(b.BotHeader).ToString(), "Success!!", "Success!!");
                    Console.WriteLine("Header Present");
                    Assert.AreEqual("True", elementOps.IsWebElementPresent(b.BotBody).ToString(), "Success!!", "Success!!");
                    Console.WriteLine("Body Present");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotHeader_001")]
        [Test, Order(2)]
        public void CheckBotHeader()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("headerIcon7");
                Assert.Multiple(() =>
                {
                    Assert.True(elementOps.IsWebElementPresent(b.BotHeaderIcon), "Success!!", "Success!!");
                    Assert.True(elementOps.IsWebElementPresent(b.BotHeadText), "Success!!", "Success!!");
                    Assert.AreNotEqual("", b.BotHeadText.GetAttribute("innerHTML").ToString(), "Success", "Success");
                    Assert.AreEqual("Bot Application for UITesting", b.BotHeadSubText.GetAttribute("innerHTML").ToString(), "Success", "Success");
                    Assert.True(elementOps.IsWebElementPresent(b.BotMaximise), "Success!!", "Success!!");
                    Assert.True(elementOps.IsWebElementPresent(b.BotClose), "Success!!", "Success!!");
                });
                Console.WriteLine("Header Present");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_BotMaximise_001")]
        [Test, Order(3)]
        public void BotMaximise()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("maximizediv7");
                browserOps.ClickableWait(b.BotMaximise);
                b.BotMaximise.Click();
                Assert.AreEqual("display: flex; width: 50%;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
                b.BotMaximise.Click();
                Assert.AreEqual("display: flex;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_BotClose_001")]
        [Test, Order(4)]
        public void BotClose()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("closediv7");
                browserOps.ClickableWait(b.BotClose);
                b.BotClose.Click();
                Assert.AreEqual("display: none;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
                b.UITestBot1.Click();
                Assert.AreNotEqual("display: none;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotBody_001")]
        [Test, Order(5)]
        public void CheckBotBody()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsClass("eb-chatBox");
                Assert.Multiple(() =>
                {
                    Assert.True( elementOps.IsWebElementPresent(b.BotBodyDate), "Success!!", "Success!!");
                    Assert.True( elementOps.IsWebElementPresent(b.BotBodyStartOver), "Success!!", "Success!!");
                    Assert.True(elementOps.IsWebElementPresent(b.BotBodyMsgIcon), "Success!!", "Success!!");
                    Assert.True(elementOps.IsWebElementPresent(b.BotBodyMsg), "Success!!", "Success!!");
                    Assert.True(elementOps.IsWebElementPresent(b.BotBodyPoweredBy), "Success!!", "Success!!");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_BotStartOver_001")]
        //[Test, Order(6)]
        public void BotStartOver()
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
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                elementOps.ExistsClass("startOvercont");
                b.BotBodyStartOver.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
    }
}
