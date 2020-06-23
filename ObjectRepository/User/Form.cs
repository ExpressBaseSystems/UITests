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

        //------------------


        public IWebElement ParentForm
        {
            get
            {
                return this.driver.FindElement(By.Id("WebForm_kayu90ek"));
            }
        }

        public IWebElement ChildBookName
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement ChildBookDesc
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }

        public IWebElement ChildBookPrice
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

        public IWebElement FormSaveDropdown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/button"));
            }
        }

        public IWebElement FormSaveNew
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"webformsave-selbtn\"]/div/div/div/ul/li[1]/a"));
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

    }
}
