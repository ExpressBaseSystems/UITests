﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class UserDashBoard
    {
        private IWebDriver driver;

        public UserDashBoard(IWebDriver driver)
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

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }

        public IWebElement LayoutDiv
        {
            get
            {
                return this.driver.FindElement(By.Id("layout_div"));
            }
        }

        public IWebElement ChartIFrame
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"canvasDivtb1tile1\"]/iframe"));
            }
        }

        public IWebElement DataLabelIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbundefinedDataLabel0_icon\"]/i"));
            }
        }

        public IWebElement DataLabelDiv
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel0_Data_pane"));
            }
        }

        public IWebElement DataLabelStatic
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel0_static"));
            }
        }

        public IWebElement DataLabelDesc
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel0_description"));
            }
        }

        public IWebElement DataLabelDynamic
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel0_dynamic"));
            }
        }

        public IWebElement DataLabelFooter
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel0_footer"));
            }
        }

        public IWebElement LinkToWebFormIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbundefinedLinks0_icon\"]/i"));
            }
        }

        public IWebElement LinkToWebFormLink
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedLinks0_link"));
            }
        }

        public IWebElement TVBrowseLink
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_link_tile0"));
            }
        }

        public IWebElement UDTVRefresh
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_restart_tile0"));
            }
        }

        public IWebElement ChartBrowseLink
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_link_tile1"));
            }
        }

        public IWebElement ChartRefresh
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_restart_tile1"));
            }
        }

        public IWebElement LinkToDashBoard
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedLinks1_link"));
            }
        }

        public IWebElement LinkToDashBoardFD
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedLinks2_link"));
            }
        }

        public IWebElement FDButton
        {
            get
            {
                return this.driver.FindElement(By.Id("filter-dg"));
            }
        }

        public IWebElement FDLocationGlobal
        {
            get
            {
                return this.driver.FindElement(By.Id("paramdiv_UserLocation1_checkbox"));
            }
        }

        public IWebElement FDLocationOptionSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"paramdiv_UserLocation1Wraper\"]/span/div/button"));
            }
        }

        public IWebElement FDLocationOptionKochi
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"paramdiv_UserLocation1Wraper\"]/span/div/ul/li[2]/a/label/input"));
            }
        }

        public IWebElement RunButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnGo"));
            }
        }

        public IWebElement GoogleMapDiv
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tile6\"]/div[2]"));
            }
        }

        public IWebElement GoogleMapRefreshButton
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_restart_tile6"));
            }
        }

        public IWebElement GoogleMapBrowser
        {
            get
            {
                return this.driver.FindElement(By.Id("undefined_link_tile6"));
            }
        }

        public IWebElement DashBoardDropDownButton
        {
            get
            {
                return this.driver.FindElement(By.Id("UserDashBoardSwitchBtn"));
            }
        }

        public IWebElement DropDownDashBoard2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"UserDashBoardSwitchList\"]/div[2]/button"));
            }
        }

        public IWebElement DashBoard2DataLabel
        {
            get
            {
                return this.driver.FindElement(By.Id("tbundefinedDataLabel1_Data_pane"));
            }
        }

        public IWebElement TV1
        {
            get
            {
                return this.driver.FindElement(By.Id("t1"));
            }
        }

    }
}