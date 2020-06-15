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

        //------------------

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

        public IWebElement GridNameField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input"));
            }
        }

        public IWebElement GridAuthorField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div/input"));
            }
        }

        public IWebElement GridPriceField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[4]/div/input"));
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

    }
}
