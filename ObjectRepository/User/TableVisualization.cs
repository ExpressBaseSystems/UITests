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
                return this.driver.FindElement(By.XPath("//*[@id=\"appList\"]/div/ul/li/ul/li[7]/a"));
            }
        }

        public IWebElement SelectTableView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[3]"));
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

        public IWebElement SelectTableVisualizationCourseList
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[5]"));
            }
        }

        public IWebElement SelectTableVisualizationJamTopicList
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div[6]"));
            }
        }

        public IWebElement EBLoader
        {
            get
            {
                return this.driver.FindElement(By.Id("eb_common_loader"));
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

        public IWebElement Mode
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

        public IWebElement IdField1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement IdField2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[7]/td[3]/a"));
            }
        }

        public IWebElement NameField1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[4]/span"));
            }
        }

        public IWebElement NameField2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[7]/td[4]/span"));
            }
        }

        public IWebElement SortFieldTD
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[4]"));
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

        public IWebElement SearchTagClose
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\"]/div/i"));
            }
        }

        public IWebElement SearchTag
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"filterdisplayrowtd_dvContainer_1586780535084_0_0\"]/div"));
            }
        }

        public IWebElement NameOperatorDropDownButton
        {
            get
            {
                return this.driver.FindElement(By.Id("dvContainer_1586780535084_0_0_name_hdr_sel"));
            }
        }

        public IWebElement NameEqualToOperator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[3]/th[4]/div/div/ul/li[4]"));
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

        public IWebElement InlineTableAdditionalRow
        {
            get
            {
                return this.driver.FindElement(By.Id("containerrow2"));
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

        //-------custom column

        public IWebElement CustomColumnHeader
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[9]"));
            }
        }

        public IWebElement SalaryField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[8]"));
            }
        }

        public IWebElement NetSalaryField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[9]"));
            }
        }

        //----------approval column

        public IWebElement ApprovalColumnHeading
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[10]"));
            }
        }

        //---------action column

        public IWebElement ActionColumnHeading
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0_wrapper\"]/div[3]/div[1]/div/table/thead/tr[1]/th[11]"));
            }
        }

        public IWebElement ActionColumnEditLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[3]/td[11]/a"));
            }
        }

        //--------auto generate

        public IWebElement AutogenEntryFields
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement AutogenRowGroupingSelect
        {
            get
            {
                return this.driver.FindElement(By.Id("rowgroupDD_dvnull_0_0"));
            }
        }

        public IWebElement AutogenRowGroupingAdditionalRow
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[2]"));
            }
        }

        //--------fixed  column

        public IWebElement FixedColumnClass
        {
            get
            {
                return this.driver.FindElement(By.ClassName("DTFC_LeftWrapper"));
            }
        }

        //-----------pagination

        public IWebElement PaginationFirstField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[3]/td[3]/a"));
            }
        }

        public IWebElement PaginationFirstButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_first\"]/a"));
            }
        }

        public IWebElement PaginationFirstli
        {
            get
            {
                return this.driver.FindElement(By.Id("dvnull_0_0_first"));
            }
        }

        public IWebElement PaginationPrevButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_previous\"]/a"));
            }
        }

        public IWebElement PaginationPrevli
        {
            get
            {
                return this.driver.FindElement(By.Id("dvnull_0_0_previous"));
            }
        }

        public IWebElement PaginationNextButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_next\"]/a"));
            }
        }

        public IWebElement PaginationNextli
        {
            get
            {
                return this.driver.FindElement(By.Id("dvnull_0_0_next"));
            }
        }
        
        public IWebElement PaginationLastButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_last\"]/a"));
            }
        }

        public IWebElement PaginationLastli
        {
            get
            {
                return this.driver.FindElement(By.Id("dvnull_0_0_last"));
            }
        }

        public IWebElement PaginationTableInfo
        {
            get
            {
                return this.driver.FindElement(By.Id("dvnull_0_0_info"));
            }
        }

        public IWebElement PaginationSelectOption1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_length\"]/label/select/option[1]"));
            }
        }

        //-------row height

        public IWebElement FieldTd
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvContainer_1586780535084_0_0\"]/tbody/tr[4]/td[5]"));
            }
        }

        //-------appearence

        public IWebElement AppearenceChkColumn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0_wrapper\"]/div[3]/div[2]/div[1]/div/table/thead/tr[1]/th[2]"));
            }
        }

        //Multiline feature

        public IWebElement EMulitilineSpan
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"dvnull_0_0\"]/tbody/tr[1]/td[3]/span"));
            }
        }
    }
}
