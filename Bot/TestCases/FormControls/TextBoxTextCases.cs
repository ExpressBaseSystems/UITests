using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.Bot.ObjectRepository;
using UITests.DataDriven;

namespace UITests.Bot.TestCases.FormControls
{
    [TestFixture]
    public class TextBoxTextCases : BaseClass
    {
        ChatBot b;

        [Property("TestCaseId", "Bot_TextBoxCore_001")]
        [Test, Order(1)]
        public void TextBoxCore()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[3]");
                b.Form3ChooseButton.Click();
                elementOps.ExistsId("TextBox8");
                Assert.True(b.TextBoxNameIcon.GetAttribute("class").Contains("fa-user"), "Success!!", "Success!!");
                b.TextBox8.SendKeys("Test User" + Keys.Enter);

                elementOps.ExistsId("TextBox1");
                b.TextBox1.SendKeys("Test User 1" + Keys.Enter);

                elementOps.ExistsId("TextBox3");
                b.TextBox3.SendKeys("Test User" + Keys.Enter);
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[9]/div[1]/div");
                Assert.True(b.TextBoxUpperCase.GetAttribute("innerHTML").Contains("TEST USER"), "Success", "Success");

                elementOps.ExistsId("TextBox2");
                b.TextBox2.SendKeys("Test User" + Keys.Enter);
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[11]/div[1]/div");
                Assert.True(b.TextBoxLowerCase.GetAttribute("innerHTML").Contains("test user"), "Success", "Success");

                elementOps.ExistsId("TextBox4");
                Assert.True(b.TextBoxPasswordIcon.GetAttribute("class").Contains("fa-key"), "Success!!", "Success!!");
                b.TextBox4.SendKeys("password" + Keys.Enter);

                elementOps.ExistsId("TextBox5");
                Assert.True(b.TextBoxEmailIcon.GetAttribute("class").Contains("fa-envelope"), "Success!!", "Success!!");
                b.TextBox5.SendKeys("abc@lmn.xyz" + Keys.Enter);

                elementOps.ExistsId("TextBox7");
                Assert.True(elementOps.CheckForAttribute("TextBox7", "rows"), "Success!!", "Success!!");
                b.TextBox7.SendKeys("Test User Bio" + Keys.Enter);

                elementOps.ExistsId("TextBox6");
                elementOps.SetValue("TextBox6", "#b42727");
                b.ColorSubmitButton.Click();

                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_TextBoxBehaviour_001")]
        [Test, Order(2)]
        public void TextBoxBehaviour()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[4]");
                b.Form4ChooseButton.Click();
                elementOps.ExistsId("TextBox1");//Hidden
                b.TextBox1.SendKeys("Test User" + Keys.Enter);

                elementOps.ExistsId("TextBox2");//Autocomplete off
                Assert.True(b.TextBox2.GetAttribute("autocomplete").Contains("off"), "Success", "Success");
                b.TextBox2.SendKeys("Test User" + Keys.Enter);

                elementOps.ExistsId("TextBox9");//readonly
                Assert.True(b.TextBox9.GetAttribute("disabled").Contains("true"), "Success", "Success");
                b.ProceedButton.Click();
                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_TextBoxValidationAndHelp_001")]
        [Test, Order(3)]
        public void TextBoxValidationAndHelp()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.site/bots");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsXpath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[5]");
                b.Form5ChooseButton.Click();
                elementOps.ExistsId("TextBox1");
                Assert.Multiple(() =>
                {
                    Assert.True(elementOps.CheckForAttribute("TextBox1", "required"), "Success", "Success");
                    Assert.True(b.TextBoxHelpText.GetAttribute("innerHTML").Contains("(All books are classified as either fiction or nonfiction. Within these two types of books you’ll find dozens of more specific types, or genres.)"), "Success", "Success");
                    Assert.True(b.TextBox1.GetAttribute("placeholder") != "", "Success", "Success");
                });
                b.TextBox1.SendKeys("Test Book Category" + Keys.Enter);

                elementOps.ExistsId("TextBox2");//Unique
                b.TextBox2.SendKeys("Test Book" + Keys.Enter);

                elementOps.ExistsId("TextBox3");//validation
                b.TextBox3.SendKeys("Test Book Id" + Keys.Enter);
                b.ProceedButton.Click();
                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
    }
}
