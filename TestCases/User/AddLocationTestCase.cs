using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    public class AddLocationTestCase
    {
        IWebDriver driver;
        UserLogin ul;
        Location loc;
        BrowserOps browserOps = new BrowserOps();

        [SetUp]
        public void Initialize()
        {
            if (driver == null)
            {
                browserOps.Init_Browser();
                driver = browserOps.getDriver;
                ul = new UserLogin(driver);
                loc = new Location(driver);
            }
        }

        [Test, Order(1)]
        public void UserLogin()
        {
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("josevin@expressbase.com");
            ul.Password.SendKeys("Qwerty@1");
            ul.LoginButton.Click();
        }

        [TestCaseSource("Locations"), Order(2)]
        public void AddLocation(dynamic loc_data)
        {                      
            browserOps.implicitWait(200);
            loc.LocationLink.Click();
            browserOps.implicitWait(5);
            loc.NewLocation.Click();
            browserOps.implicitWait(5);
            loc.LongName.SendKeys(loc_data.longname);
            loc.ShortName.SendKeys(loc_data.shortname);
            loc.CreateLocation.Click();
            Console.WriteLine("New Loc Added....");
            driver.Navigate().GoToUrl("https://hairocraft.eb-test.cloud/TenantUser/EbLocations");
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> Locations()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\AddLocations.xml");
        }
    }
}
