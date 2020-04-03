using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        GetUniqueId id = new GetUniqueId();
        WebDriverWait wait;

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
            wait = browserOps.DriverWait();
        }

        public void UserLogin()
        {
            browserOps.Goto("https://hairocraft.eb-test.cloud/");
            ul.UserName.SendKeys("josevin@expressbase.com");
            ul.Password.SendKeys("Qwerty@1");
            ul.LoginButton.Click();
        }

        [TestCaseSource("Locations")]
        public void AddLocation(dynamic loc_data)
        {
            
            UserLogin();          
            
            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/UserDashboard");           
            browserOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[4]/a");

            loc.LocationLink.Click();
            browserOps.UrlToBe("https://hairocraft.eb-test.cloud/TenantUser/EbLocations");
            loc.BtnNewLoc.Click();
            browserOps.implicitWait(50);
            loc.LongName.SendKeys(loc_data.longname + id.GetId);
            loc.ShortName.SendKeys(loc_data.shortname + id.GetId);
            loc.test.SendKeys(loc_data.tst);

            loc.BtnAddLoc.Click();
            Console.WriteLine("New Location Added....");
            browserOps.Refresh();
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }

        private static List<EbTestItem> Locations()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\AddLocationTestCase.xml");
        }
    }
}
