using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class Location
    {
        private IWebDriver driver;

        public Location(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LocationTypeTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[2]/a"));
            }
        }

        public IWebElement CustomizeTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div[2]/ul/li[3]/a"));
            }
        }

        //---------------------------------------------------------

        public IWebElement AddNewRootLocation
        {
            get
            {
                return this.driver.FindElement(By.Id("add_root_loc"));
            }
        }

        public IWebElement LocType
        {
            get
            {
                return this.driver.FindElement(By.Id("loc_type"));
            }
        }

        public IWebElement LocName
        {
            get
            {
                return this.driver.FindElement(By.Name("_longname"));
            }
        }

        public IWebElement LocShortName
        {
            get
            {
                return this.driver.FindElement(By.Name("_shortname"));
            }
        }   
        
        public IWebElement Logo
        {
            get
            {
                return this.driver.FindElement(By.Name("Logo"));
            }
        }
        
        public IWebElement AddLocButton
        {
            get
            {
                return this.driver.FindElement(By.Id("add_location"));
            }
        }

        //-----------------------------------------------------------------SubLoc

        public IWebElement LocField3
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl\"]/tbody/tr[3]"));
            }
        }

        public IWebElement LocField4
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl\"]/tbody/tr[4]"));
            }
        }

        public IWebElement LocField5
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl\"]/tbody/tr[5]"));
            }
        }

        public IWebElement LocField6
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl\"]/tbody/tr[6]/td"));
            }
        }

        public IWebElement LocField7
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"tbl\"]/tbody/tr[7]/td"));
            }
        }

        public IWebElement AddSubLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/ul/li[1]"));
            }
        }

        public IWebElement EditSubLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/ul/li[2]"));
            }
        }

        public IWebElement MoveSubLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/ul/li[3]"));
            }
        }

        public IWebElement MoveGroupButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("treemodalul"));
            }
        }

        public IWebElement MoveGroup
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/ul/li[5]"));
            }
        }

        public IWebElement MoveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("treemodal_submit"));
            }
        }

        //--------------------------------------------------------------------LocationType

        public IWebElement AddLocationType
        {
            get
            {
                return this.driver.FindElement(By.Id("add_location_type"));
            }
        }

        public IWebElement LocationTypeName
        {
            get
            {
                return this.driver.FindElement(By.Name("TypeName"));
            }
        }

        public IWebElement LocationTypeNameVal
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"types-space\"]/table/tbody/tr[4]/td[3]"));
            }
        }

        public IWebElement LocationTypeAddButton
        {
            get
            {
                return this.driver.FindElement(By.Id("add_type_btn"));
            }
        }

        public IWebElement EditLocationType
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"types-space\"]/table/tbody/tr[4]/td[4]/i"));
            }
        }

        public IWebElement RemoveLocationType
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"types-space\"]/table/tbody/tr[4]/td[4]/i[2]"));
            }
        }

        

        //-----------------------------------------------------------------------Customize

        public IWebElement AddCustomFieldButton
        {
            get
            {
                return this.driver.FindElement(By.Id("addkey"));
            }
        }

        public IWebElement CustomFieldName
        {
            get
            {
                return this.driver.FindElement(By.Name("KeyName"));
            }
        }

        public IWebElement CustomFieldRequired
        {
            get
            {
                return this.driver.FindElement(By.Name("IsRequired"));
            }
        }

        public IWebElement CustomFieldType
        {
            get
            {
                return this.driver.FindElement(By.Name("KeyType"));
            }
        }

        public IWebElement CustomFieldAdd
        {
            get
            {
                return this.driver.FindElement(By.Id("add_key_btn"));
            }
        }

        public IWebElement RemoveCustomField
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"textspace\"]/table/tbody/tr[4]/td[4]/i"));
            }
        }

        public IWebElement CustomFieldInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"add_location_bdy\"]/div[5]/div/input"));
            }
        }

        //------------------------------Location Switcher

        public IWebElement LocationSwitcherTab
        {
            get
            {
                return this.driver.FindElement(By.Id("switch_loc"));
            }
        }

        public IWebElement LocationKochi
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[3]/a"));
            }
        }

        public IWebElement LocationKerala
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[2]/a"));
            }
        }

        public IWebElement LocationDefault
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[1]/a"));
            }
        }

        public IWebElement LocationSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Id("setLocSub"));
            }
        }

        public IWebElement CurrentLocationName
        {
            get
            {
                return this.driver.FindElement(By.Id("LocInfoCr_name"));
            }
        }

        public IWebElement LocationSwitcherTreei
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[19]/i"));
            }
        }

        public IWebElement LocationSwitcherTreeLoc
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"loc_switchModal\"]/div/div/div[2]/ul/li[19]/ul/li[1]/a"));
            }
        }

        public IWebElement LocationSearch
        {
            get
            {
                return this.driver.FindElement(By.Id("loc-search"));
            }
        }

    }
}
