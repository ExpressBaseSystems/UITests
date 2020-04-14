using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class SupportTicketTestCase : BaseClass
    {
        SupportTicket st;
        string url = "https://uitesting.eb-test.cloud/UserDashBoard";
        string sprt_url = "https://uitesting.eb-test.cloud/SupportTicket/BugSupport";
        void UserLogin()
        {
            browserOps.Goto("https://uitesting.eb-test.cloud");           
            ul.UserName.SendKeys("josevin@expressbase.com");
            ul.Password.SendKeys("@Josevin123");
            ul.LoginButton.Click();
        }

        [Property("TestCaseId", "SuptTkt_NewTkt_001")]
        [Test]
        public void NewTicket()
        {
            UserLogin();
            st = new SupportTicket(driver);
            elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[1]/a");
            st.SupportTicketLink.Click();            
        }
    }
}
