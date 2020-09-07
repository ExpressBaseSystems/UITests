using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Forms.BasicControls;

namespace UITests.TestCases.User.Forms.BasicControls
{
    [TestFixture]
    class DisplayPictureTestCases : BaseClass
    {
        UserLogin ulog;
        DisplayPicture d;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            d = new DisplayPicture(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-181-181-181-181");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(1)]
        public void DisplayPicture_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture1");
            Assert.Multiple(() =>
            {
                Assert.True(d.DisplayPicture1Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(d.DisplayPicture2Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(2)]
        public void DisplayPicture_Multiple()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture5");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture5Change);
            actions.Perform();
            d.DisplayPicture5Change.Click();
            elementOps.ExistsId("cont_DisplayPicture5-file-input");
            d.DisplayPicture5Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            d.DisplayPicture5UploadButton.Click();
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture5), "Success", "Success");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(2)]
        public void DisplayPicture_Crop()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture6");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture6Change);
            actions.Perform();
            d.DisplayPicture6Change.Click();
            elementOps.ExistsId("cont_DisplayPicture6-file-input");
            d.DisplayPicture6Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture6CropResize), "Success", "Success");
            elementOps.ChangeStyleByXpath(d.DisplayPicture6CropResize,"style", "width: 256px; height: 216px;");
            d.DisplayPicture6CropButton.Click();
            d.DisplayPicture6UploadButton.Click();
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture6), "Success", "Success");
        }
    }
}
