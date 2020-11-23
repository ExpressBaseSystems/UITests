using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class SimpleSelect
    {
        private IWebDriver driver;

        public SimpleSelect(IWebDriver driver)
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

        public IWebElement SimpleSelect1OptGrp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect1\"]/optgroup"));
            }
        }

        public IWebElement SimpleSelect1
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect1"));
            }
        }

        public IWebElement SimpleSelect1Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect1_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect2
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect2"));
            }
        }

        public IWebElement SimpleSelect2Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect2_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect3
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect3"));
            }
        }

        public IWebElement SimpleSelect3Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect3_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect4Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleSelect4"));
            }
        }

        public IWebElement SimpleSelect7Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleSelect7"));
            }
        }

        public IWebElement SimpleSelect5
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect5"));
            }
        }

        public IWebElement SimpleSelect5Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect5_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect5Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleSelect5"));
            }
        }

        public IWebElement SimpleSelect6
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect6"));
            }
        }

        public IWebElement SimpleSelect6Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect6_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect6Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_SimpleSelect6"));
            }
        }

        public IWebElement SimpleSelect6SelectButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect6_dd\"]/button"));
            }
        }

        public IWebElement SimpleSelect8Al
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect8-al"));
            }
        }

        public IWebElement SimpleSelect10
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect10"));
            }
        }

        public IWebElement SimpleSelect10Al
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect10-al"));
            }
        }

        public IWebElement SimpleSelect11
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect11"));
            }
        }

        public IWebElement SimpleSelect11Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect11_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect12
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect12"));
            }
        }

        public IWebElement SimpleSelect12Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"SimpleSelect12_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement SimpleSelect15
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect15"));
            }
        }

    }
}
