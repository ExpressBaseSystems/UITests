using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    [TestFixture]
    class FormAdvancedControlsTestCases : BaseClass
    {
        UserLogin ulog;
        UserLogOut lo;
        Form f;

        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void UserLogOut()
        {
            lo = new UserLogOut(driver);
            lo.ProfileImageDropDown.Click();
            browserOps.implicitWait(50);
            lo.LogoutButton.Click();
            browserOps.implicitWait(50);
            Console.WriteLine("LogOut Success");
        }
        

        [Property("TestCaseId", "Form_DataPusher_001")]
        [Test, Order(1)]
        public void ReviewControlUser()
        {
            try
            {
                UserLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                f.ReviewFormTextBox.SendKeys("Test");
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                //---------Stage 1
                
                var selectElement = new SelectElement(f.ReviewFormStatusDropDownStage1);
                selectElement.SelectByValue("ebreviewstage1_ebreviewaction2");
                f.ReviewFormTextAreaStage1.SendKeys("Test1");
                f.ReviewFormButton.Click();

                elementOps.ExistsClass("cnfrmBox-btnc");
                f.ReviewFormConfirmationOkButton.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerText"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                //------------ Stage 2

                selectElement = new SelectElement(f.ReviewFormStatusDropDownStage2);
                selectElement.SelectByValue("ebreviewstage2_ebreviewaction2");
                f.ReviewFormTextAreaStage2.SendKeys("Test2");
                f.ReviewFormButton.Click();

                elementOps.ExistsClass("cnfrmBox-btnc");
                f.ReviewFormConfirmationOkButton.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerText"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                //----------Stage 3

                selectElement = new SelectElement(f.ReviewFormStatusDropDownStage3);
                selectElement.SelectByValue("ebreviewstage3_ebreviewaction2");
                f.ReviewFormTextAreaStage3.SendKeys("Test3");
                f.ReviewFormButton.Click();

                elementOps.ExistsClass("cnfrmBox-btnc");
                f.ReviewFormConfirmationOkButton.Click();

                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerText"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExecuteScripts("$('#eb_messageBox_container').hide();");

                UserLogOut();
                ulog = new UserLogin(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/");
                ulog.UserName.SendKeys("testuser1@gmail.com");
                ulog.Password.SendKeys("Qwerty@123");
                ulog.LoginButton.Click();
                Console.WriteLine("Login Success");
                browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                f.ReviewFormTextBox.SendKeys("Test");
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");
                elementOps.ExistsXpath("//*[@id=\"tbl_Review1\"]/tbody/tr/td[3]");
                Assert.AreEqual("Stage in Processing", f.ReviewFormStageProcessing.GetAttribute("innerHTML").ToString(), "Success", "Success");

                UserLogOut();
                UserLogin();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(2)]
        public void ImageFileUploader()
        {
            try
            {
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Little_girls_Guitar_462552_2560x1440.jpg");

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(3)]
        public void FileInImageUploader()
        {
            try
            {
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(4)]
        public void ImageFileUploaderCategory()
        {
            try
            {
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Little_girls_Guitar_462552_2560x1440.jpg");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div/div/div[4]/select");
                var selectElement = new SelectElement(f.FileUploaderCategorySelect);
                selectElement.SelectByIndex(1);

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[2]/div[1]");
                f.FileUploader1Toggle2.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img2).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(5)]
        public void FileUploader()
        {
            try
            {
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(6)]
        public void FileUploaderCategory()
        {
            try
            {
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div/div/div[4]/select");
                var selectElement = new SelectElement(f.FileUploaderCategorySelect1);
                selectElement.SelectByIndex(1);

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[2]/div[1]");
                f.FileUploader1Toggle2.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img2).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(7)]
        public void ImageInFileUploader()
        {
            try
            {
                UserLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Little_girls_Guitar_462552_2560x1440.jpg");

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
