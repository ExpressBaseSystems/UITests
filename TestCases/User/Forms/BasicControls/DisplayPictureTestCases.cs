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
            browserOps.Goto("https://uitesting.eb-test.site/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            d = new DisplayPicture(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.site/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.site/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-181-181-181-181");
        }

        public void InsertValue()
        {
            elementOps.ExistsId("displaypicture3");
            
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture3Change);
            actions.Perform();
            d.DisplayPicture3Change.Click();
            elementOps.ExistsId("cont_DisplayPicture3-file-input");
            d.DisplayPicture3Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture3UploadButton);
            actions.Perform();
            d.DisplayPicture3UploadButton.Click();
            elementOps.ExistsClass("eb_messageBox_container");
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));

            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture4Change);
            //actions.Perform();
            //d.DisplayPicture4Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture4-file-input");
            //d.DisplayPicture4Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //elementOps.ExistsId("cont_DisplayPicture4-upload-lin");
            //d.DisplayPicture4UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));
            
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture5Change);
            //actions.Perform();
            //d.DisplayPicture5Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture5-file-input");
            //d.DisplayPicture5Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture5UploadButton);
            //actions.Perform();
            //d.DisplayPicture5UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));

            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture6Change);
            //actions.Perform();
            //d.DisplayPicture6Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture6-file-input");
            //d.DisplayPicture6Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture6UploadButton);
            //actions.Perform();
            //d.DisplayPicture6UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));

            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture7Change);
            //actions.Perform();
            //d.DisplayPicture7Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture7-file-input");
            //d.DisplayPicture7Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture7UploadButton);
            //actions.Perform();
            //d.DisplayPicture7UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));

            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture8Change);
            //actions.Perform();
            //d.DisplayPicture8Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture8-file-input");
            //d.DisplayPicture8Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture8UploadButton);
            //actions.Perform();
            //d.DisplayPicture8UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));

            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture9Change);
            //actions.Perform();
            //d.DisplayPicture9Change.Click();
            //elementOps.ExistsId("cont_DisplayPicture9-file-input");
            //d.DisplayPicture9Input.SendKeys("C:\\Users\\user\\Pictures\\code.png");
            //actions = new Actions(driver);
            //actions.MoveToElement(d.DisplayPicture9UploadButton);
            //actions.Perform();
            //d.DisplayPicture9UploadButton.Click();
            //elementOps.ExistsClass("eb_messageBox_container");
            //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 0, 170); color: rgb(255, 255, 255); display: none;\"")));
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
        [Test, Order(3)]
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

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(4)]
        public void DisplayPicture_CropAspectRatioFree()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture6");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture6Change);
            actions.Perform();
            d.DisplayPicture6Change.Click();
            elementOps.ExistsId("cont_DisplayPicture6-file-input");
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture6CropResize), "Success", "Success");
            Assert.True(d.DisplayPicture6CropResize.GetAttribute("class")== "cr-resizer", "Success", "Success");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(5)]
        public void DisplayPicture_CropAspectRatioDP()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture7");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture7Change);
            actions.Perform();
            d.DisplayPicture7Change.Click();
            elementOps.ExistsId("cont_DisplayPicture7_cropy_container");
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture7CropResize), "Success", "Success");
            Assert.True(d.DisplayPicture7CropResize.GetAttribute("class") == "cr-viewport cr-vp-square", "Success", "Success");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(6)]
        public void DisplayPicture_CropAspectRatioLocation()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture8");
            actions = new Actions(driver);
            actions.MoveToElement(d.DisplayPicture8Change);
            actions.Perform();
            d.DisplayPicture8Change.Click();
            elementOps.ExistsId("cont_DisplayPicture8_cropy_container");
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture8CropResize), "Success", "Success");
            Assert.True(d.DisplayPicture8CropResize.GetAttribute("class") == "cr-viewport cr-vp-square", "Success", "Success");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(7)]
        public void DisplayPicture_EnableFullScreen()
        {
            CheckUsrLogin();

            elementOps.ExistsId("displaypicture9");
            d.DisplayPicture9.Click();
            elementOps.ExistsClass("ebDpFullscreen_inner");
            Assert.True(elementOps.IsWebElementPresent(d.DisplayPicture9FullScreen), "Success", "Success");
            Assert.True(d.DisplayPicture9FullScreen.GetAttribute("class") == "FupimgIcon", "Success", "Success");
        }

        [Property("TestCaseId", "DisplayPicture_Behaviour_001")]
        [Test, Order(7)]
        public void DisplayPicture_ViewMode()
        {
            CheckUsrLogin();

            InsertValue();
            d.SaveButton.Click();
            wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(0, 170, 0); color: rgb(255, 255, 255); display: none;\"")));

            Assert.AreEqual("View Mode", d.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
            Console.WriteLine("View Mode");
        }
    }
}
