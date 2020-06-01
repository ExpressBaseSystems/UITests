using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    public class FormTestCase3 : BaseClass
    {
        FormObject fo;
        GetUniqueId UID;
        string UniqueId;

        [Test, Order(1)]
        public void UserLogin()
        {
            try
            {
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ul.UserName.SendKeys("kurian@expressbase.com");
                ul.Password.SendKeys("@Kurian123");
                ul.LoginButton.Click();

                fo = new FormObject(driver);
                UID = new GetUniqueId();

                wait.Until(webDriver => (driver.PageSource.Contains("class=\"list-group-item inner_li Obj_link for_brd\"")));
                browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashboard");
                Console.WriteLine("Login Succesfull");

                browserOps.implicitWait(1);
                elementOps.ExistsXpath("//*[@id='appList']/div/ul/li/ul/li[7]/a");
                fo.MenuApplication.Click();
                browserOps.implicitWait(1);

                actions.MoveToElement(fo.MenuSelectFormMenu).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objtcontainer']/div[2]/div[1]");
                fo.MenuSelectFormMenu.Click();
                browserOps.implicitWait(1);
                actions.MoveToElement(fo.MenuSelectForm1).Perform();
                elementOps.ExistsXpath("//*[@id='ebm-objectcontainer']/div[2]/div[2]/a");
                fo.MenuSelectForm3.Click();
                Console.WriteLine("Test Form Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Test, Order(2)]
        public void PlatformControls()
        {
            fo.SysLocationSelectableClick.Click();
            fo.SysLocationSelectableItemSelect.Click();
            Assert.AreEqual("2", fo.SysLocationSelectableClick.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysLocation - Selectable”");

            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysCreatedBy), true.ToString(), "“Test passed for User - side - SysCreatedBy”");
            Assert.AreEqual("28-05-2020", fo.SysCreatedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysCreatedAt”");  
            
            Assert.AreEqual("Kurian Cherian", elementOps.GetValueFromJS(fo.SysModifiedBy), true.ToString(), "“Test passed for User - side - SysModifiedBy”");
            Assert.AreEqual("28-05-2020", fo.SysModifiedAt.GetAttribute("value"), true.ToString(), "“Test passed for User - side - SysModifiedAt”");

            fo.UserSelectClick.Click();
            fo.UserSelectItemClick.Click();
            //Assert.AreEqual("2", fo.UserSelectClick.GetAttribute("value"), true.ToString(), "“Test passed for User - side - UserSelect - Selectable”");

            fo.UserLocationGlobal.Click();
            fo.UserLocationSelect.Click();
            browserOps.implicitWait(100);
            fo.UserLocationKochi.Click();
        }

        [Test, Order(3)]
        public void SaveFoam()
        {
            fo.SaveForm.Click();
        }
    }
}
