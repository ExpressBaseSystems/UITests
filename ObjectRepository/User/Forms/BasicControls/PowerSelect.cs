using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class PowerSelect
    {
        private IWebDriver driver;

        public PowerSelect(IWebDriver driver)
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

        public IWebElement PowerSelect1
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect1"));
            }
        }

        public IWebElement PowerSelect1Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect1email\"]/div/input"));
            }
        }

        public IWebElement PowerSelect1Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect1emailid\"]/div/input"));
            }
        }

        public IWebElement PowerSelect2Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect2name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect3Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect3name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect4Input1
        {
            get
            {
                return this.driver.FindElement(By.Id("radiobutton2"));
            }
        }

        public IWebElement PowerSelect5Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect5name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect6Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6numeric1\"]/div/input"));
            }
        }

        public IWebElement PowerSelect6Input1Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6numeric1\"]/div/span"));
            }
        }

        public IWebElement PowerSelect6Input2Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6numeric2\"]/div/span"));
            }
        }

        public IWebElement PowerSelect7Input1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect7date1\"]/div/input"));
            }
        }

        public IWebElement PowerSelect1Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect1tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect1ValueClose
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect1email\"]/div/span/button"));
            }
        }

        public IWebElement PowerSelect2
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect2"));
            }
        }

        public IWebElement PowerSelect2Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect2email\"]/div/input"));
            }
        }

        public IWebElement PowerSelect2Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect2tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect3
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect3"));
            }
        }

        public IWebElement PowerSelect3Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect3name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect3Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect3tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect4
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect4"));
            }
        }

        public IWebElement PowerSelect4Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect4name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect4Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect4tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect5
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect5"));
            }
        }

        public IWebElement PowerSelect5Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect5"));
            }
        }

        public IWebElement PowerSelect6
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect6"));
            }
        }

        public IWebElement PowerSelect6Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect6Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect7
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect7"));
            }
        }

        public IWebElement PowerSelect7Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect7name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect7Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect7tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect7Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect7"));
            }
        }

        public IWebElement PowerSelect8
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect8"));
            }
        }

        public IWebElement PowerSelect8Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect8name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect8Value
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect8tbl\"]/tbody/tr[1]/td[1]"));
            }
        }

        public IWebElement PowerSelect8Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect8"));
            }
        }

        public IWebElement PowerSelect9
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect9"));
            }
        }

        public IWebElement PowerSelect9Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect9"));
            }
        }

        public IWebElement PowerSelect10
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect10"));
            }
        }

        public IWebElement PowerSelect10Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect10name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect10Value1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect10tbl\"]/tbody/tr[1]/td[1]/input"));
            }
        }

        public IWebElement PowerSelect10Value2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect10tbl\"]/tbody/tr[2]/td[1]/input"));
            }
        }

        public IWebElement PowerSelect10Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect10"));
            }
        }

        public IWebElement PowerSelect10Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect10name\"]/div/span"));
            }
        }

        public IWebElement PowerSelect11
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect11"));
            }
        }

        public IWebElement PowerSelect11Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect11name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect12
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect12"));
            }
        }

        public IWebElement PowerSelect13
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect13"));
            }
        }

        public IWebElement PowerSelect13Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect13name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect13Div
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect13Wraper"));
            }
        }

        public IWebElement PowerSelect14
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect14"));
            }
        }

        public IWebElement PowerSelect14Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect14name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect15
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect15"));
            }
        }

        public IWebElement PowerSelect16
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect16"));
            }
        }

        public IWebElement PowerSelect16Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect16name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect16Scroll
        {
            get
            {
                return this.driver.FindElement(By.ClassName("dataTables_scroll"));
            }
        }

        public IWebElement PowerSelect18
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect16"));
            }
        }

        public IWebElement PowerSelect18Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect18name\"]/div/span"));
            }
        }

        public IWebElement PowerSelect19
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect19"));
            }
        }

        public IWebElement PowerSelect19Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect19name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect19Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect19name\"]/div/span"));
            }
        }
        
        public IWebElement PowerSelect20Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect20"));
            }
        }

        public IWebElement PowerSelect21
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect21"));
            }
        }

        public IWebElement PowerSelect21Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect21name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect21Span
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect21name\"]/div/span"));
            }
        }

        public IWebElement PowerSelect22
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect22"));
            }
        }

        public IWebElement TextBox4
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }

        public IWebElement TextBox5
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }

        public IWebElement TextBox6
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }

        public IWebElement TextBox9
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }

        public IWebElement TextBox10
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox10"));
            }
        }

        public IWebElement TextBox12
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox12"));
            }
        }

        public IWebElement TextBox13
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox13"));
            }
        }

        public IWebElement TextBox13Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox13"));
            }
        }

        public IWebElement TextBox14
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox14"));
            }
        }

        public IWebElement Numeric1
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }

        public IWebElement Numeric2
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric2"));
            }
        }

        public IWebElement Date2
        {
            get
            {
                return this.driver.FindElement(By.Id("Date2"));
            }
        }

        public IWebElement PowerSelect22Input
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect22name\"]/div/input"));
            }
        }

        public IWebElement PowerSelect22AddBtn
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect22_addbtn"));
            }
        }

        public IWebElement PowerSelectNumeric1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"PowerSelect6numeric1\"]/div/input"));
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
