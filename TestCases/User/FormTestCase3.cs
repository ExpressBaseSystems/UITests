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
        FormTestCase1 BasicFuntion = new FormTestCase1();

        [Property("TestCaseId", "Form_PlatformControls_001")]
        [Test, Order(2)]
        public void PlatformControls()
        {
            BasicFuntion.Userlogin(driver);
            BasicFuntion.FormSelect(3, driver);
            fo = new FormObject(driver);
            UID = new GetUniqueId();

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
