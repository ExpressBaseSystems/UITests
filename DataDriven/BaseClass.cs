﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.ObjectRepository.User;

namespace UITests.DataDriven
{
    [TestFixture]
    public class BaseClass
    {
        public IWebDriver driver;
        public UserLogin ul;       
        public BrowserOps browserOps = new BrowserOps();
        public GetUniqueId id = new GetUniqueId();
        public WebDriverWait wait;
        public WebElementOps elementOps;

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
            }
            wait = browserOps.DriverWait();
            elementOps = new WebElementOps(driver, wait);
        }

        public void UserLogin()
        {
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("josevin@expressbase.com");
            ul.Password.SendKeys("Qwerty@1");
            ul.LoginButton.Click();
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }
    }
}