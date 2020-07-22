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
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno7");
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
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsClass("eb-chat-head");
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

        [Property("TestCaseId", "Bot_CheckBotHeader_001")]
        [Test, Order(3)]
        public void BotMaximise()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("maximizediv7");
                b.BotMaximise.Click();
                Assert.AreEqual("min-width: inherit; display: flex; width: 50%;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
                b.BotMaximise.Click();
                Assert.AreEqual("min-width: inherit; display: flex;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotHeader_001")]
        [Test, Order(4)]
        public void BotClose()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("closediv7");
                b.BotClose.Click();
                Assert.AreEqual("min-width: inherit; display: none; opacity: 1;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
                b.UITestBot.Click();
                Assert.AreEqual("min-width: inherit; display: flex; opacity: 1;", b.BotFrame.GetAttribute("style").ToString(), "Success", "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_CheckBotHeader_001")]
        [Test, Order(5)]
        public void CheckBotBody()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
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

        [Property("TestCaseId", "Bot_CheckBotHeader_001")]
        [Test, Order(6)]
        public void BotStartOver()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsClass("eb_botStartover");
                b.BotBodyStartOver.Click();
                elementOps.ExistsClass("msg-cont");
                Assert.True(elementOps.IsWebElementPresent(b.BotBodyMsgEmail), "Success!!", "Success!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
    }
}
