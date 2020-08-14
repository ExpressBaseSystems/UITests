using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class Form
    {
        private IWebDriver driver;

        public Form(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Menu
        {
            get
            {
                return this.driver.FindElement(By.Id("quik_menu"));
            }
        }

        public IWebElement SelectApp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[8]/a"));
            }
        }

        public IWebElement SelectTableView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[3]"));
            }
        }

        public IWebElement SelectForm
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[1]"));
            }
        }

        public IWebElement SelectTableVisualizationDataPusherChild
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[10]"));

            }
        }

        public IWebElement SelectFormDataPusherParent
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[9]"));
            }
        }

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }

        public IWebElement Message
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"eb_messageBox_container\"]/span"));
            }
        }

        public IWebElement MessageClose
        {
            get
            {
                return this.driver.FindElement(By.Id("close-msg"));
            }
        }

        public IWebElement EBLoader
        {
            get
            {
                return this.driver.FindElement(By.Id("eb_common_loader"));
            }
        }

        //------------------


        public IWebElement ParentForm
        {
            get
            {
                return this.driver.FindElement(By.Id("WebForm_kayu90ek"));
            }
        }
        
        public IWebElement TextBox1
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement TextBox2
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }

        public IWebElement Numeric1
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }

        public IWebElement GridAddRowButton
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }

        public IWebElement GridAddRowButton1
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid2addrow"));
            }
        }

        public IWebElement GridFirstField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input"));
            }
        }

        public IWebElement GridSecondFieldNumeric
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div/div/input"));
            }
        }

        public IWebElement GridThirdFieldNumeric
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[4]/div/div/input"));
            }
        }

        public IWebElement GridCommitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[5]/button[2]"));
            }
        }
        
        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformsave"));
            }
        }

        //--------------------Disable Delete

        public IWebElement ActionButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[11]/a"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformdelete"));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformcancel"));
            }
        }

        public IWebElement NotificationCount
        {
            get
            {
                return this.driver.FindElement(By.Id("notification-count"));
            }
        }

        public IWebElement NotificationButton
        {
            get
            {
                return this.driver.FindElement(By.Id("eb-expand-nfWindow"));
            }
        }

        //------------Form Users

        public IWebElement UserSalary
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric2"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement UserDOB
        {
            get
            {
                return this.driver.FindElement(By.Id("Date1"));
            }
        }

        public IWebElement UserPhno
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }

        public IWebElement UserEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }

        public IWebElement UserDeptSelectButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect1_dd\"]/button"));
            }
        }

        public IWebElement UserDeptSelectOpt
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect1_dd\"]/div/div/ul/li[2]/a"));
            }
        }

        public IWebElement UserStatusSelectButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect2_dd\"]/button"));
            }
        }

        public IWebElement UserStatusSelectOpt
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect2_dd\"]/div/div/ul/li[2]/a"));
            }
        }

        public IWebElement UserRemark
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }
        }

        public IWebElement UserDGAddButton
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }

        public IWebElement UserDGCourseName
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input"));
            }
        }

        public IWebElement UserDGYear
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div/input"));
            }
        }

        public IWebElement UserDGCommit
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_DataGrid1\"]/tbody/tr/td[4]/button[2]"));
            }
        }

        //----------Form Jam

        public IWebElement JamTopic
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        //------------Form Course

        public IWebElement CourseName
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        //------------- Form PDF

        public IWebElement FormPDFDropDown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformprint-selbtn\"]/div/button"));
            }
        }

        public IWebElement FormPDFLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformprint-selbtn\"]/div/div/div/ul/li/a"));
            }
        }

        public IWebElement FormPDFModal
        {
            get
            {
                return this.driver.FindElement(By.Id("iFramePdfModal"));
            }
        }

        public IWebElement FormPDFPrint
        {
            get
            {
                return this.driver.FindElement(By.Id("webformprint"));
            }
        }

        //-----------Save

        public IWebElement FormSaveDropdownButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]"));
            }
        }

        public IWebElement FormSaveDropdownButton2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div"));
            }
        }

        public IWebElement FormSaveDropdown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/select"));
            }
        }

        public IWebElement FormSaveNew
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div/div/ul/li[1]/a"));
            }
        }

        public IWebElement FormSaveEditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }

        public IWebElement FormSaveEdit
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div/div/ul/li[2]/a"));
            }
        }

        public IWebElement FormSaveView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div/div/ul/li[3]/a"));
            }
        }

        public IWebElement FormSaveClose
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div/div/ul/li[4]/a"));
            }
        }

        //-----------Grid2

        public IWebElement Grid2Field1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/div/input"));
            }
        }

        public IWebElement Grid2Field2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[3]/div/div/input"));

            }
        }

        public IWebElement Grid2Field3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[4]/div/div/select"));
            }
        }

        public IWebElement Grid2Field4
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[5]/div/div/select"));
            }
        }

        public IWebElement Grid2Field5
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[6]/div/div/div/div/div/div/div/input"));
            }
        }

        public IWebElement Grid2Field5Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"WebForm_kbnm7hcy\"]/div[3]/div/div[2]/div[2]/table/tbody/tr/td"));
            }
        }

        public IWebElement Grid2Field6
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[7]/div/div/div"));
            }
        }

        public IWebElement Grid2Field7
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[8]/div/input"));
            }
        }

        public IWebElement Grid2Field8
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[9]/div/div/div"));
            }
        }

        public IWebElement Grid2Field9
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[10]/div/input"));
            }
        }

        public IWebElement Grid2Field10
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[11]/div/div/div/div[2]"));
            }
        }
        
        public IWebElement Grid2Field10Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[11]/div/div/div[2]/div[3]/div[2]"));
            }
        }

        public IWebElement Grid2Field11
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[12]/div/div/input"));
            }
        }

        public IWebElement Grid2Field12
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[13]/div/input"));
            }
        }

        public IWebElement Grid2Field13
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[14]/div/input"));
            }
        }

        public IWebElement Grid2CommitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[14]/button[2]"));
            }
        }

        //----------------------------Review Controller

        public IWebElement ReviewFormTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement ReviewFormStatusDropDownStage1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr/td[3]/div/div/select"));
            }
        }

        public IWebElement ReviewFormTextAreaStage1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr/td[5]/div/textarea"));
            }
        }

        public IWebElement ReviewFormStatusDropDownStage2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr[2]/td[3]/div/div/select"));
            }
        }

        public IWebElement ReviewFormTextAreaStage2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr[2]/td[5]/div/textarea"));
            }
        }

        public IWebElement ReviewFormStatusDropDownStage3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr[3]/td[3]/div/div/select"));
            }
        }

        public IWebElement ReviewFormTextAreaStage3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr[3]/td[5]/div/textarea"));
            }
        }

        public IWebElement ReviewFormButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Review1\"]/div[3]/button"));
            }
        }

        public IWebElement ReviewFormConfirmationOkButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"eb_dlogBox_container\"]/div/div[3]/button[1]"));
            }
        }

        public IWebElement ReviewFormStageProcessing
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl_Review1\"]/tbody/tr/td[3]"));
            }
        }

        //--------FileUpload

        public IWebElement FileUploadReqButton
        {
            get
            {
                return this.driver.FindElement(By.Id("FileUploader1_Upl_btn"));
            }
        }
        

        public IWebElement FileBrowser
        {
            get
            {
                return this.driver.FindElement(By.Id("FileUploader1-file-input"));
            }
        }
        
        public IWebElement FileUploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("FileUploader1-upload-lin"));
            }
        }
        
        public IWebElement FileUploadOkButton
        {
            get
            {
                return this.driver.FindElement(By.Id("FileUploader1-upl-ok"));
            }
        }
        

        public IWebElement FileUploadSuccessSpan
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/span[1]"));
            }
        }

        public IWebElement FileUploader1Toggle
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[1]/div[1]"));
            }
        }

        public IWebElement FileUploader2Toggle
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader2_GalleryUnq\"]/div[1]/div[1]"));
            }
        }

        public IWebElement FileUploader1Toggle2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_GalleryUnq\"]/div[2]/div[1]"));
            }
        }

        public IWebElement FileUploader1Img1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_GalleryUnq\"]/div/div[2]/div/div/div/img"));
            }
        }
        

        public IWebElement FileUploader1Img2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_G_one\"]/div/div/div/img"));
            }
        }

        public IWebElement FileUploaderCategorySelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div/div/div[4]/select"));
            }
        }

        public IWebElement FileUploaderCategorySelect1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/select"));
            }
        }

        public IWebElement SimpleFileUploader
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleFileUploader1_inputID"));
            }
        }

        public IWebElement SimpleFileUploaderReqMsg
        {
            get
            {
                return this.driver.FindElement(By.Id("@name@errormsg"));
            }
        }

        public IWebElement SimpleFileUploader2
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleFileUploader2"));
            }
        }

        public IWebElement SimpleFileUploader3
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleFileUploader3"));
            }
        }

        public IWebElement SimpleFileUploaderEditLink1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[12]/a"));
            }
        }

        public IWebElement SimpleFileUploaderImgViewMode
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleFileUploader1_SFUP\"]/div[2]/div/div/img"));
            }
        }

        public IWebElement SimpleFileUploaderImgViewer
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[6]/div[1]/img"));
                //*[@id="SimpleFileUploader1_SFUP"]/div[2]/div/div/img
            }
        }

        public IWebElement SimpleFileUploaderImg
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleFileUploader1_SFUP\"]/div[2]/div/div/img"));

            }
        }

        public IWebElement SimpleFileUploaderImgDelete
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleFileUploader1_SFUP\"]/div[2]/div/div/span/i"));
            }
        }

        public IWebElement SimpleFileUploaderFileType
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleFileUploader1_SFUP\"]/div[2]/div/div/div/p"));
            }
        }

        public IWebElement FileUploaderActionButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[9]/a"));
            }
        }

        public IWebElement FileUploaderImgDelete
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/ul/li[3]"));
            }
        }

        public IWebElement FileUploaderImgDeleteYesButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"eb_dlogBox_container\"]/div/div[3]/button[1]"));
            }
        }

        public IWebElement FileUploaderImgDiv
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb_uplGal_thumbO_img"));
            }
        }

        public IWebElement FileUploaderImgToggleDiv
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_GalleryUnq\"]/div/div[1]"));
            }
        }

        public IWebElement FileUploaderImgToggleDiv2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1_GalleryUnq\"]/div/div[2]"));
            }
        }

        public IWebElement FileUploader2
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_FileUploader2"));
            }
        }

        public IWebElement FileUploader3
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_FileUploader3"));
            }
        }

        public IWebElement FileUploader3UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("FileUploader3_Upl_btn"));
            }
        }

        public IWebElement FileUploaderMutlipleImg1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/span[1]"));
            }
        }

        public IWebElement FileUploaderMutlipleImg2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[3]/div/div[4]/span[1]"));
            }
        }

        public IWebElement FileUploaderTag
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/button[3]"));
            }
        }

        public IWebElement FileUploaderTagInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/div/div/input"));
            }
        }

        public IWebElement FileUploaderCrop
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader1-eb-upl-bdy\"]/div[2]/div/div[4]/button[4]"));
            }
        }
        
        public IWebElement FileUploaderCropModal
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"container_crpcrp_modal\"]/div/div/div[2]/div[1]"));
            }
        }
        
        public IWebElement FileUploaderCropSlider
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"container_crp_cropy_container\"]/div[2]/input"));
            }
        }

        public IWebElement FileUploaderCropButton
        {
            get
            {
                return this.driver.FindElement(By.Id("container_crp_crop"));
            }
        }
        
        public IWebElement FileUploaderSaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("container_crp_save"));
            }
        }
        
        public IWebElement FileUploaderDisableUpload
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader4_FUP_GW\"]/div[1]"));
            }
        }
        
        public IWebElement FileUploaderHideEmptyCategory
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"FileUploader3_GalleryUnq\"]/div[1]"));
            }
        }

        public IWebElement FileUploaderImgSelect
        {
            get
            {
                return this.driver.FindElement(By.Name("Mark"));
            }
        }
    }
}
