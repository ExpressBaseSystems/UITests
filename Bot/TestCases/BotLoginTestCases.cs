using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UITests.Bot.ObjectRepository;
using UITests.DataDriven;

namespace UITests.Bot.TestCases
{
    [TestFixture]
    public class BotLoginTestCases : BaseClass
    {
        ChatBot b;

        [Property("TestCaseId", "Bot_LoginWithEmail_001")]
        [Test, Order(1)]
        public void LoginWithEmail()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno7");
                b.UITestBot1.Click();
                elementOps.ExistsId("ebbot_iframe7");
                driver.SwitchTo().Frame("ebbot_iframe7");
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine( driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_LoginWithPhoneNumber_001")]
        [Test, Order(2)]
        public void LoginWithPhoneNumber()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno10");
                b.UITestBot2.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_iframecont10\" appid=\"10\" class=\"eb_iframecont eb__-bot___-eb_iframecont10\" style=\"display: flex;\"")));
                elementOps.ExistsId("ebbot_iframe10");
                driver.SwitchTo().Frame("ebbot_iframe10");
                elementOps.ExistsId("anon_phno");
                b.BotBodyMsgPhoneNumber.SendKeys("8123456789");
                b.PhoneNumberSubmitButton.Click();
                elementOps.ExistsId("TextBox1");
                b.TextBox1.SendKeys("Test User" + Keys.Enter);
                elementOps.ExistsName("formsubmit");
                b.FormSubmitButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine(driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_LoginWithEmailandPhoneNumber_001")]
        [Test, Order(3)]
        public void LoginWithEmailandPhoneNumber()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno12");
                b.UITestBot4.Click();
                elementOps.ExistsId("ebbot_iframe12");
                driver.SwitchTo().Frame("ebbot_iframe12");

                elementOps.ExistsId("anon_name");
                b.BotBodyMsgName.SendKeys("Anoopa Baby");
                b.NameSubmitButton.Click();
                elementOps.ExistsId("anon_mail");
                b.BotBodyMsgEmail.SendKeys("testuser@expressbase.com");
                b.MailSubmitButton.Click();
                elementOps.ExistsId("anon_phno");
                b.BotBodyMsgPhoneNumber.SendKeys("8123456789");
                b.PhoneNumberSubmitButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine(driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_LoginWithPassword_001")]
        [Test, Order(4)]
        public void LoginWithPassword()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno13");
                b.UITestBot5.Click();
                elementOps.ExistsId("ebbot_iframe13");
                driver.SwitchTo().Frame("ebbot_iframe13");

                elementOps.ExistsId("username_id");
                b.UserId.SendKeys("anoopa.baby@expressbase.com");
                elementOps.ExistsId("password_id");
                b.Password.SendKeys("Qwerty@123");
                b.PasswordSubmitButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine(driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_LoginWithOTP_001")]
        [Test, Order(5)]
        public void LoginWithOTP()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/bots");
                elementOps.ExistsId("botno14");
                b.UITestBot6.Click();
                elementOps.ExistsId("ebbot_iframe14");
                driver.SwitchTo().Frame("ebbot_iframe14");

                elementOps.ExistsId("otp_login_id");
                b.OTPLoginId.SendKeys("anoopa.baby@expressbase.com");
                b.OTPIdSubmitButton.Click();

                browserOps.NewTab("https://accounts.zoho.in/signin?servicename=VirtualOffice&signupurl=https://www.zoho.in/mail/zohomail-pricing.html&serviceurl=https://mail.zoho.in");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("login_id");
                b.ZohoMailId.SendKeys("anoopa.baby@expressbase.com");
                b.MailIdNextButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"login_id_container\" style=\"display: none;\"")));
                elementOps.ExistsId("password");
                b.ZohoPassword.SendKeys("@n00p@95");
                b.MailIdNextButton.Click();
                elementOps.ExistsXpath("//*[@id=\"zm_centerHolder\"]/div/div/div/div[2]/div/div/div[5]/i");
                b.Mail1.Click();
                elementOps.ExistsXpath("//*[@id=\"zm_centerHolder\"]/div[1]/div/div/div[3]/div[1]/div[1]/div[2]/div[3]/div/div/div");
                string str = b.Mail1Msg.GetAttribute("innerHTML");
                Regex regex = new Regex(@"\d{6}");
                MatchCollection matches = regex.Matches(str);
                string otp = matches[0].ToString().Trim();
                Console.WriteLine(otp);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("ebbot_iframe14");
                driver.SwitchTo().Frame("ebbot_iframe14");

                elementOps.ExistsId("partitioned");
                b.OTPField.Click();
                b.OTPField.SendKeys(otp);
                b.OTPValidateButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine(driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Bot_LoginWith2FactorAuth_001")]
        [Test, Order(6)]
        public void LoginWith2FactorAuth()
        {
            try
            {
                b = new ChatBot(driver);
                browserOps.Goto("https://demo.eb-test.cloud/bots");
                elementOps.ChangeStyle("eb_iframecont6", "style", "display: none; opacity: 0;");
                elementOps.ExistsId("botno5");
                b.UITestBot7.Click();
                elementOps.ExistsId("ebbot_iframe5");
                driver.SwitchTo().Frame("ebbot_iframe5");

                elementOps.ExistsId("username_id");
                b.UserId.SendKeys("anoopa.baby@expressbase.com");
                elementOps.ExistsId("password_id");
                b.Password.SendKeys("Qwerty@123");
                b.PasswordSubmitButton.Click();

                browserOps.NewTab("https://accounts.zoho.in/signin?servicename=VirtualOffice&signupurl=https://www.zoho.in/mail/zohomail-pricing.html&serviceurl=https://mail.zoho.in");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("login_id");
                b.ZohoMailId.SendKeys("anoopa.baby@expressbase.com");
                b.MailIdNextButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"login_id_container\" style=\"display: none;\"")));
                elementOps.ExistsId("password");
                b.ZohoPassword.SendKeys("@n00p@95");
                b.MailIdNextButton.Click();
                elementOps.ExistsXpath("//*[@id=\"zm_centerHolder\"]/div/div/div/div[2]/div/div/div[5]/i");
                b.Mail1.Click();
                elementOps.ExistsXpath("//*[@id=\"zm_centerHolder\"]/div[1]/div/div/div[3]/div[1]/div[1]/div[2]/div[3]/div/div/div");
                string str = b.Mail1Msg.GetAttribute("innerHTML");
                Regex regex = new Regex(@"\d{6}");
                MatchCollection matches = regex.Matches(str);
                string otp = matches[0].ToString().Trim();
                Console.WriteLine(otp);
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                elementOps.ExistsId("ebbot_iframe5");
                driver.SwitchTo().Frame("ebbot_iframe5");

                elementOps.ExistsId("partitioned");
                b.OTPField.Click();
                b.OTPField.SendKeys(otp);
                b.OTPValidateButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("Click to explore")));
                Console.WriteLine(driver.Manage().Cookies.AllCookies.Count);
                driver.Manage().Cookies.DeleteCookieNamed("bot_rToken");
                driver.Manage().Cookies.DeleteCookieNamed("bot_bToken");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
