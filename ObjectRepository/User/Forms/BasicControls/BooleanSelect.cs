using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class BooleanSelect
    {
        private IWebDriver driver;

        public BooleanSelect(IWebDriver driver)
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

        public IWebElement BooleanSelect1
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect1"));
            }
        }

        public IWebElement BooleanSelect1Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect1"));
            }
        }

        public IWebElement BooleanSelect1Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect1_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect2
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect2"));
            }
        }

        public IWebElement BooleanSelect2Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect2"));
            }
        }

        public IWebElement BooleanSelect2Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect2_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect3
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect3"));
            }
        }

        public IWebElement BooleanSelect3Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect3_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect4
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect4"));
            }
        }

        public IWebElement BooleanSelect4Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect4"));
            }
        }

        public IWebElement BooleanSelect4Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect4_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect5
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect5"));
            }
        }
        public IWebElement BooleanSelect5Div
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect5_dd\"]/button"));
            }
        }

        public IWebElement BooleanSelect5Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect5_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect6
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect6"));
            }
        }

        public IWebElement BooleanSelect6Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect6_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect6Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect6"));
            }
        }

        public IWebElement BooleanSelect7
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect7"));
            }
        }

        public IWebElement BooleanSelect7Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect7_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect7Sup
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_BooleanSelect7\"]/sup"));
            }
        }

        public IWebElement BooleanSelect8
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect8"));
            }
        }

        public IWebElement BooleanSelect8Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect8_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect9
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect9"));
            }
        }

        public IWebElement BooleanSelect9Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect9_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect10
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect10"));
            }
        }

        public IWebElement BooleanSelect10Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect10_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect11
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect1"));
            }
        }

        public IWebElement BooleanSelect11Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect11_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect12
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect12"));
            }
        }

        public IWebElement BooleanSelect12Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect12_dd\"]/button/div/div/div"));
            }
        }

        public IWebElement BooleanSelect13
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect13"));
            }
        }

        public IWebElement BooleanSelect13Text
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"BooleanSelect13_dd\"]/button/div/div/div"));
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
