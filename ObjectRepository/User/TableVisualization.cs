using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class TableVisualization
    {
        private IWebDriver driver;

        public TableVisualization(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SelectApp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[7]/a"));
            }
        }

        public IWebElement SelectTableView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[2]"));
            }
        }

        public IWebElement SelectTableVisualization
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div"));
            }
        }

        //-------------- Table Visulization

        public IWebElement NewFormButton
        {
            get
            {
                return this.driver.FindElement(By.Id("NewFormButtondvContainer_1586780535084_0_0"));
            }
        }

        public IWebElement NewFormUserCreation
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"NewFormdddvContainer_1586780535084_0_0\"]/div/ul/li/a"));
            }
        }

        public IWebElement DataEntryLinkClick
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement WebFormEditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }

        public IWebElement EditMode
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"objname\"]/span"));
            }
        }

        //----------------- Sorting

        public IWebElement SortNameField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[4]"));
            }
        }

        //--------------- Searching

        public IWebElement SearchBoxNameField
        {
            get
            {
                return this.driver.FindElement(By.Id("dvContainer_1586780535084_0_0_name_hdr_txt1"));
            }
        }

        public IWebElement SearchTagRow
        {
            get
            {
                return this.driver.FindElement(By.Id("filterdisplayrowtd_dvContainer_1586780535084_0_0"));
            }
        }

        //-----------Row Grouping

        public IWebElement RowGroupingSelect
        {
            get
            {
                return this.driver.FindElement(By.Id("rowgroupDD_dvContainer_1586780535084_0_0"));
            }
        }

        public IWebElement RowGroupingAdditionalRow
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[2]"));
            }
        }

        //------------ToolTip

        public IWebElement RowEntryName
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[4]/span"));
            }
        }

        public IWebElement RowEntryNameDiv
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[4]"));
            }
        }
    }
}
