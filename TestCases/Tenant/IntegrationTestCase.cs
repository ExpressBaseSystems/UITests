using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.Tenant;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.Tenant
{
    public class IntegrationTestCase
    {
        IWebDriver driver;
        TenantLogin tl;
        IntegrationObject io;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                tl = new TenantLogin(driver);
                io = new IntegrationObject(driver);
            }
        }

        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://myaccount.eb-test.cloud/");
            tl.UserName.SendKeys("kokic66909@mrisemail.com");
            tl.Password.SendKeys("@Qwerty123");
            tl.LoginButton.Click();
        }

        [TestCaseSource("Integrations"), Order(2)]
        public void NewIntegration(dynamic IntegrationObject)
        {
            browserOps.implicitWait(300);
            io.TenentToSetting.Click();

            browserOps.implicitWait(100);
            io.NewDB.Click();

            io.dbNickNameInput.SendKeys(IntegrationObject.NickName);
            io.dbDatabaseNameInput.SendKeys(IntegrationObject.DBName);
            io.dbIsSSLInput.Click();
            io.dbServerInput.SendKeys(IntegrationObject.Server);
            io.dbPortInput.SendKeys(IntegrationObject.Port);
            io.dbTimeoutInput.SendKeys(IntegrationObject.TimeOut);
            io.dbUserNameInput.SendKeys(IntegrationObject.UserName);
            io.dbPasswordInput.SendKeys(IntegrationObject.Password);

            browserOps.implicitWait(300);
            io.SaveDB.Click();


        }
        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }
        private static List<EbTestItem> Integrations()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\Tenant\IntegrationTestCase.xml");
        }
    }
}
