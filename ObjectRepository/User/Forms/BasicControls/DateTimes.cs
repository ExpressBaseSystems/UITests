using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class DateTimes
    {
        private IWebDriver driver;

        public DateTimes(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }

        public IWebElement Date1
        {
            get
            {
                return this.driver.FindElement(By.Id("Date1"));
            }
        }

        public IWebElement Date2
        {
            get
            {
                return this.driver.FindElement(By.Id("Date2"));
            }
        }

        public IWebElement Date3
        {
            get
            {
                return this.driver.FindElement(By.Id("Date3"));
            }
        }

        public IWebElement Date4
        {
            get
            {
                return this.driver.FindElement(By.Id("Date4"));
            }
        }

        public IWebElement Date4Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date4"));
            }
        }

        public IWebElement Date5
        {
            get
            {
                return this.driver.FindElement(By.Id("Date5"));
            }
        }

        public IWebElement Date5Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date5"));
            }
        }

        public IWebElement Date6
        {
            get
            {
                return this.driver.FindElement(By.Id("Date6"));
            }
        }

        public IWebElement Date6Div
        {
            get
            {
                return this.driver.FindElement(By.Id("Date6Wraper"));
            }
        }

        public IWebElement Date7
        {
            get
            {
                return this.driver.FindElement(By.Id("Date7"));
            }
        }

        public IWebElement Date8
        {
            get
            {
                return this.driver.FindElement(By.Id("Date8"));
            }
        }

        public IWebElement Date9
        {
            get
            {
                return this.driver.FindElement(By.Id("Date9"));
            }
        }

        public IWebElement Date9Check
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"Date9Wraper\"]/div/span[1]/input"));
            }
        }

        public IWebElement Date10
        {
            get
            {
                return this.driver.FindElement(By.Id("Date10"));
            }
        }

        public IWebElement Date11
        {
            get
            {
                return this.driver.FindElement(By.Id("Date11"));
            }
        }

        public IWebElement Date12
        {
            get
            {
                return this.driver.FindElement(By.Id("Date12"));
            }
        }

        public IWebElement Date13
        {
            get
            {
                return this.driver.FindElement(By.Id("Date13"));
            }
        }

        public IWebElement Date14
        {
            get
            {
                return this.driver.FindElement(By.Id("Date14"));
            }
        }

        public IWebElement Date15
        {
            get
            {
                return this.driver.FindElement(By.Id("Date15"));
            }
        }

        public IWebElement Date16
        {
            get
            {
                return this.driver.FindElement(By.Id("Date16"));
            }
        }

        public IWebElement Date17
        {
            get
            {
                return this.driver.FindElement(By.Id("Date17"));
            }
        }

        public IWebElement Date18
        {
            get
            {
                return this.driver.FindElement(By.Id("Date18"));
            }
        }

        public IWebElement Date18MonthPicker
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"MonthPicker_Date18\"]/div[2]/table/tr[1]/td[1]/a"));
            }
        }

        public IWebElement Date19
        {
            get
            {
                return this.driver.FindElement(By.Id("Date19"));
            }
        }

        public IWebElement Date19YearPicker
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[23]/div[2]/ul/li[6]"));
            }
        }

        public IWebElement Date20
        {
            get
            {
                return this.driver.FindElement(By.Id("Date20"));
            }
        }

        public IWebElement Date21
        {
            get
            {
                return this.driver.FindElement(By.Id("Date21"));
            }
        }

        public IWebElement Date22
        {
            get
            {
                return this.driver.FindElement(By.Id("Date22"));
            }
        }

        public IWebElement Date23
        {
            get
            {
                return this.driver.FindElement(By.Id("Date23"));
            }
        }

        public IWebElement Date24
        {
            get
            {
                return this.driver.FindElement(By.Id("Date24"));
            }
        }

        public IWebElement Date24Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date24"));
            }
        }

        public IWebElement Date25
        {
            get
            {
                return this.driver.FindElement(By.Id("Date25"));
            }
        }
        
        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformsave"));
            }
        }

        public IWebElement EditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }
    }
}
