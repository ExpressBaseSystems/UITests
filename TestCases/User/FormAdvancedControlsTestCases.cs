using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
        }

        [Property("TestCaseId", "Form_ReviewControl_001")]
        [Test, Order(1)]
        public void ReviewControl()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                int val = elementOps.GetTableRowCount("//*[@id=\"nf-container\"]/li");
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
                int val1 = elementOps.GetTableRowCount("//*[@id=\"nf-container\"]/li");
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");
                Assert.True(val < val1, "Success", "Success");
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
                f.ReviewFormTextBox.SendKeys("Test"+Keys.Control+"s");
                //f.SaveButton.Click();

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

        //------------------- File Uploader

        [Property("TestCaseId", "Form_FileUploader_001")]
        [Test, Order(2)]
        public void ImageInImageUploader() //FileType Image
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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

        [Property("TestCaseId", "Form_FileUploader_002")]
        [Test, Order(3)]
        public void FileInImageUploader()         //FileType Image 
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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

        [Property("TestCaseId", "Form_FileUploader_003")]
        [Test, Order(4)]
        public void ImageUploader_ChangeCategory()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-100-100-100-100");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div/div/div[4]/select");
                var selectElement = new SelectElement(f.FileUploaderCategorySelect);
                selectElement.SelectByIndex(1);

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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

        [Property("TestCaseId", "Form_FileUploader_004")]
        [Test, Order(5)]
        public void FileUploader()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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

        [Property("TestCaseId", "Form_FileUploader_005")]
        [Test, Order(6)]
        public void FileUploader_ChangeCategory()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");

                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div/div/div[4]/select");
                var selectElement = new SelectElement(f.FileUploaderCategorySelect1);
                selectElement.SelectByIndex(1);

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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

        [Property("TestCaseId", "Form_FileUploader_006")]
        [Test, Order(7)]
        public void ImageInFileUploader()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");

                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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
        

        [Property("TestCaseId", "Form_FileUploader_007")]
        [Test, Order(8)]
        public void ImageUploader_Hidden()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121#");
                elementOps.ExistsId("cont_FileUploader2");
                Assert.AreEqual("true", f.FileUploader2.GetAttribute("eb-hidden").ToString(), "Success", "Success");
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_008")]
        [Test, Order(9)]
        public void ImageUploader_ReadOnly()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("cont_FileUploader3");
                Assert.AreEqual("true", f.FileUploader3.GetAttribute("eb-readonly").ToString(), "Success", "Success");
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_009")]
        [Test, Order(10)]
        public void ImageFileUploader_Multiple()         
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("cont_FileUploader1");
                Assert.AreEqual(true, elementOps.CheckForAttribute("FileUploader1-file-input", "multiple"), "Success", "Success");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code1.png");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                browserOps.implicitWait(500);
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_010")]
        [Test, Order(11)]
        public void ImageUploader_Tag()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("cont_FileUploader1");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");
                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/button[3]");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploaderTag).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploaderTag);
                actions.Perform();
                f.FileUploaderTag.Click();
                f.FileUploaderTagInput.SendKeys("girl" + Keys.Enter);
                f.FileUploaderTag.Click();

                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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
                Assert.AreEqual(true, (elementOps.GetTableRowCount("//*[@id=\"FileUploader1_FUP_GW\"]/div[1]/div[2]/ul/li") > 1) ? true : false, "Success", "Success");
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_011")]
        [Test, Order(12)]
        public void ImageUploader_Crop()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("cont_FileUploader1");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");
                elementOps.ExistsXpath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/button[3]");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploaderCrop).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploaderCrop);
                actions.Perform();
                f.FileUploaderCrop.Click();
                elementOps.ExistsXpath("//*[@id=\"container_crpcrp_modal\"]/div/div/div[2]/div[1]");
                elementOps.ChangeStyleByXpath(f.FileUploaderCropSlider, "aria-valuenow", "0.3569");
                f.FileUploaderCropButton.Click();
                f.FileUploaderSaveButton.Click();

                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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
                
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_012")]
        [Test, Order(13)]
        public void ImageUploader_DisableUpload()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("cont_FileUploader1");
                
                Assert.AreEqual("display: none;", f.FileUploaderDisableUpload.GetAttribute("style").ToString(), "Success", "Success");
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_013")]
        [Test, Order(14)]
        public void ImageUploader_CheckFileSize() //----------------------
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-104-104-104-104");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Downloads\\Ford.jpg");
                
                elementOps.ExistsId("FileUploader1-upload-lin");
                actions = new Actions(driver);
                actions.MoveToElement(f.FileUploadButton);
                actions.Perform();
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
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_014")]
        [Test, Order(15)]
        public void ImageUploader_HideEmptyCategory()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-121-121-121-121");
                elementOps.ExistsId("cont_FileUploader1");

                Assert.AreEqual("display: none;", f.FileUploaderHideEmptyCategory.GetAttribute("style").ToString(), "Success", "Success");
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_015")]
        [Test, Order(16)]
        public void ImageUploader_ViewMode()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-123-123-123-123#");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095060_0_0\"]/tbody/tr[3]/td[9]/a");
                f.FileUploaderActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                //var alert = driver.SwitchTo().Alert();
                //alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_016")]
        [Test, Order(17)]
        public void ImageUploader_EditMode() 
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-123-123-123-123#");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095060_0_0\"]/tbody/tr[3]/td[9]/a");
                f.FileUploaderActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                f.FormSaveEditButton.Click();
                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                elementOps.ExistsClass("eb_uplGal_thumbO_img");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!!", "Success!!");
                f.SaveButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                //var alert = driver.SwitchTo().Alert();
                //alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_FileUploader_017")]
        [Test, Order(18)]
        public void ImageUploader_Delete() //-----------------------
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-123-123-123-123#");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095060_0_0\"]/tbody/tr[3]/td[9]/a");
                f.FileUploaderActionButton.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                f.FileUploader1Toggle.Click();
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.FileUploader1Img1).ToString(), "Success!! Search  Compelte", "Success!! Search  Compelte");

                f.FormSaveEditButton.Click();
                elementOps.ExistsXpath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]");
                elementOps.ChangeStyleByXpath(f.FileUploaderImgToggleDiv, "class", "Col_head");
                elementOps.ChangeStyleByXpath(f.FileUploaderImgToggleDiv2, "class", "Col_apndBody collapse in");
                actions = new Actions(driver);
                actions.ContextClick(f.FileUploaderImgDiv);
                actions.Perform();

                elementOps.ExistsXpath("/html/body/ul/li[3]");
                f.FileUploaderImgDelete.Click();
                elementOps.ExistsXpath("//*[@id=\"eb_dlogBox_container\"]/div/div[3]/button[1]");
                f.FileUploaderImgDeleteYesButton.Click();
                //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_common_loader\" style=\"background-color: transparent; display: none;\"")));
                //wait.Until(webDriver => (driver.PageSource.Contains("id=\"eb_messageBox_container\" style=\"background-color: rgb(255, 0, 0); color: rgb(255, 255, 255); display: none;\"")));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                elementOps.ExistsId("FileUploader1_Upl_btn");
                f.FileUploadReqButton.Click();

                elementOps.ExistsId("FileUploader1-file-input");
                f.FileBrowser.SendKeys("C:\\Users\\user\\Pictures\\code.png");

                elementOps.ExistsId("FileUploader1-upload-lin");
                f.FileUploadButton.Click();
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"eb-upl-loader\" style=\"display: none;\"")));
                f.FileUploadOkButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                f.SaveButton.Click();
                elementOps.ExistsClass("eb_messageBox_container");
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
        
        //--------------Simple File Upload

        [Property("TestCaseId", "Form_SimpleFileUploader_001")]
        [Test, Order(19)]
        public void SimpleFileUploaderImage()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys("C:\\Users\\user\\Pictures\\code.png");
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check-circle-o success\" style=\"display: inline;\"")));
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("Success");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_002")]
        [Test, Order(20)]
        public void SimpleFileUploaderFile()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test File");

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys("C:\\Users\\user\\Pictures\\Hello.docx");
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check-circle-o success\" style=\"display: inline;\"")));
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("Success");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_003")]
        [Test, Order(21)]
        public void SimpleFileUploader_Required()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SaveButton.Click();

                elementOps.ExistsId("@name@errormsg");
                Console.WriteLine(f.SimpleFileUploaderReqMsg.GetAttribute("innerHTML"));
                Console.WriteLine("Success");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_004")]
        [Test, Order(22)]
        public void SimpleFileUploader_Hidden()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("cont_SimpleFileUploader2");
                Assert.AreEqual("true", f.SimpleFileUploader2.GetAttribute("eb-hidden").ToString(), "Success", "Success");
                Console.WriteLine("Success");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_005")]
        [Test, Order(23)]
        public void SimpleFileUploader_ReadOnly()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("cont_SimpleFileUploader3");
                Assert.AreEqual("true", f.SimpleFileUploader3.GetAttribute("eb-readonly").ToString(), "Success", "Success");
                Console.WriteLine("Success");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_006")]
        [Test, Order(24)]
        public void SimpleFileUploader_CheckMaxFiles()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys("C:\\Users\\user\\Pictures\\code.png");
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check-circle-o success\" style=\"display: inline;\"")));
                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys("C:\\Users\\user\\Pictures\\code.png");

                elementOps.ExistsClass("eb_messageBox_container");
                Assert.AreEqual("Maximum number of files reached ", f.Message.GetAttribute("innerHTML"), "Success", "Success");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
                browserOps.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_007")]
        [Test, Order(25)]
        public void SimpleFileUploader_CheckFileSize()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-114-114-114-114#");
                elementOps.ExistsId("TextBox1");
                f.TextBox1.SendKeys("Test Img");

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys("C:\\Users\\user\\Downloads\\Ford.jpg");
                
                elementOps.ExistsClass("eb_messageBox_container");
                Assert.AreEqual("Maximum file size is undefinedMB", f.Message.GetAttribute("innerHTML"), "Success", "Success");
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_008")]
        [Test, Order(26)]
        public void CheckSimpleFileUploaderImage_ViewMode()  // Act sep according to file type
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-116-116-116-116");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095208_0_0\"]/tbody/tr[3]/td[12]/a");
                f.SimpleFileUploaderEditLink1.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsId("TextBox1");
                string val = f.TextBox1.GetAttribute("value");
                Console.WriteLine(val);
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.SimpleFileUploaderImgViewMode).ToString(), "Success!!", "Success!!");
                f.SimpleFileUploaderImgViewMode.Click();
                if (val.Contains("File"))
                {
                    var alert = driver.SwitchTo().Alert();
                    alert.Dismiss();
                }
                else
                    Assert.AreEqual("True", elementOps.IsWebElementPresent(f.SimpleFileUploaderImgViewer).ToString(), "Success!!", "Success!!");
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_009")]
        [Test, Order(27)]
        public void CheckSimpleFileUploaderImage_EditMode()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-116-116-116-116");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095208_0_0\"]/tbody/tr[3]/td[12]/a");
                f.SimpleFileUploaderEditLink1.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsId("TextBox1");
                f.FormSaveEditButton.Click();
                Assert.AreEqual("Edit Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("Edit Mode");
                elementOps.ExistsId("TextBox1");
                Assert.AreEqual("True", elementOps.IsWebElementPresent(f.SimpleFileUploaderImg).ToString(), "Success!!", "Success!!");
                
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                //var alert = driver.SwitchTo().Alert();
                //alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "Form_SimpleFileUploader_010")]
        [Test, Order(28)]
        public void CheckSimpleFileUploader_DeleteImage()
        {
            try
            {
                CheckUsrLogin();
                f = new Form(driver);
                browserOps.Goto("https://uitesting.eb-test.cloud/DV/dv?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-16-116-116-116-116");
                elementOps.ExistsXpath("//*[@id=\"dvContainer_1228095208_0_0\"]/tbody/tr[3]/td[12]/a");
                f.SimpleFileUploaderEditLink1.Click();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Assert.AreEqual("View Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("View Mode");

                elementOps.ExistsId("TextBox1");
                f.FormSaveEditButton.Click();
                Assert.AreEqual("Edit Mode", f.FormMode.GetAttribute("innerHTML").ToString(), "Success", "Success");
                Console.WriteLine("Edit Mode");
                elementOps.ExistsId("TextBox1");
                string filetype = f.SimpleFileUploaderFileType.GetAttribute("innerHTML").Split(".")[1];
                string file = "C:\\Users\\user\\Pictures\\code.png";
                if (filetype == "docx")
                    file = "C:\\Users\\user\\Pictures\\Hello.docx";
                actions = new Actions(driver);
                actions.MoveToElement(f.SimpleFileUploaderImg);
                actions.Perform();
                var children = f.SimpleFileUploaderImgDelete.FindElements(By.XPath(".//*"));
                Console.WriteLine(children);
                f.SimpleFileUploaderImgDelete.Click();

                elementOps.ExistsId("SimpleFileUploader1_inputID");
                f.SimpleFileUploader.SendKeys(file);
                wait.Until(webDriver => (driver.PageSource.Contains("class=\"fa fa-check-circle-o success\" style=\"display: inline;\"")));
                f.SaveButton.Click();

                elementOps.ExistsClass("eb_messageBox_container");
                Console.WriteLine(f.Message.GetAttribute("innerHTML"));
                elementOps.ChangeStyle("eb_messageBox_container", "style", "display: none");

                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                //var alert = driver.SwitchTo().Alert();
                //alert.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

    }
}
