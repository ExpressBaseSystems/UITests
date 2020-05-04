using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class ChartVisualization
    {
        private IWebDriver driver;

        public ChartVisualization(IWebDriver driver)
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

        public IWebElement SelectChartView
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objtcontainer\"]/div[2]/div[3]"));
            }
        }

        public IWebElement SelectChartVisualizationUsers
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ebm-objectcontainer\"]/div[2]/div"));
            }
        }

        public IWebElement ColumnCollapsedContainer
        {
            get
            {
                return this.driver.FindElement(By.Id("btnColumnCollapsedvContainer_1588221308998_0_0"));
            }
        }

        //--------------- properties

        public IWebElement Properties
        {
            get
            {
                return this.driver.FindElement(By.ClassName("stickBtn"));
            }
        }

        public IWebElement YaxisCollection
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"pp_inner_propGrid\"]/table/tbody/tr[7]/td[2]/button"));
            }
        }

        public IWebElement YaxisNewEntry
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"user_id\"]/button[3]"));
            }
        }

        public IWebElement YaxisOk
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"pp_inner\"]/div[5]/div/div[3]/button"));
            }
        }

        public IWebElement RunButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnGodvContainer_1588221308998_0_0"));
            }
        }

        public IWebElement YaxisEntries
        {
            get
            {
                return this.driver.FindElement(By.Id("Y_col_namedvContainer_1588221308998_0_0"));
            }
        }

        public IWebElement YAxisNewEntryli
        {
            get
            {
                return this.driver.FindElement(By.Id("liuser_id"));
            }
        }
    }
}
