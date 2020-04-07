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
    public class FormTestCase : BaseClass
    {
        [Test, Order(1)]
        public void SelectForm()
        {
            browserOps.implicitWait(1000);
            browserOps.Goto("https://hairocraft.eb-test.cloud/WebForm/Index?refid=hairocraft_stagging-hairocraft_stagging-0-427-531-427-531");
            browserOps.implicitWait(1000);
        }
    }
}
