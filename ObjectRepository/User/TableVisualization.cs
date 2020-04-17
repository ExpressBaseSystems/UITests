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

        public IWebElement SelectTableVisualizationUsers
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div"));
            }
        }

        public IWebElement SelectTableVisualizationAccountTree
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[2]"));
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

        public IWebElement SortIdField1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement SortIdField2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[3]/a"));
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

        public IWebElement SearchTag
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\"]/div"));
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

        //------------ Inline Table

        public IWebElement InlineTableButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[4]/a/i"));
            }
        }

        //------ Search

        public IWebElement SearchBar
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1553959320177_0_0_filter\"]/div/input"));
            }
        }

        public IWebElement TVRowStyle
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1553959320177_0_0\"]/tbody/tr[3]"));
            }
        }
        //--------- conditional formatting

        public IWebElement ConditionalFormattingField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[8]"));
            }
        }

        public IWebElement ConditionalFormattingDiv
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[5]/td[8]/div"));
            }
        }

        //------aggregate

        public IWebElement FooterAggregate
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[3]/div/table/tfoot/tr/th[8]/div"));
            }
        }
    }
}
