using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.Tenant;

namespace UITests.TestCases.Tenant
{
    [TestFixture]
    public class TenantNewSolutionTestCase : BaseClass
    {
        TenantLogin tl;
        TenantNewSolution l;
        
        [TestCaseSource("Login"), Order(1)]
        public void TenantLogin(dynamic data)
        {
            tl = new TenantLogin(driver);
            browserOps.Goto("https://myaccount.eb-test.cloud/");
            tl.UserName.SendKeys(data.username);
            tl.Password.SendKeys(data.password);
            tl.LoginButton.Click();
            browserOps.implicitWait(50);
        }

        [Test, Order(2)]
        public void CreateNewSolution()
        {
            l = new TenantNewSolution(driver);
            //browserOps.implicitWait(200);
            //l.SkipLink.Click();
            browserOps.implicitWait(50);
            l.NewSolutionButton.Click();
            browserOps.implicitWait(50);
            l.MessagePopUpClose.Click();
            Console.Write("New Solution Created");
        }
        
        private static List<EbTestItem> Login()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\Tenant\TenantNewSolutionTestCase.xml");
        }

    }
}
