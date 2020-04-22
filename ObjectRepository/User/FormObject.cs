﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class FormObject
    {
        private IWebDriver driver;

        public FormObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MenuApplication
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul/li/ul/li[7]/a"));
            }
        }
        public IWebElement MenuSelectFormMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div[2]/div[2]/div[2]/div[1]"));
            }
        }
        public IWebElement MenuSelectForm
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div/div[2]/div[3]/div[2]/div[1]/a"));
            }
        }
        public IWebElement TextBoxLowerCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }

        }
        public IWebElement TextBoxUpperCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }        
        public IWebElement TextBoxPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }
        }
        public IWebElement TextBoxEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }
        public IWebElement TextBoxMultiLine
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }        
        public IWebElement TextBoxMaxLength
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }        
        public IWebElement TextboxAutosuggestion
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox7"));
            }
        }
        public IWebElement TextboxHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox8"));
            }
        }
        public IWebElement TextboxReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }
        public IWebElement TextboxRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox10"));
            }
        }
        public IWebElement TextboxUnique
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox11"));
            }
        }
        public IWebElement TextboxDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox12"));
            }
        }



        public IWebElement NumericBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }
        public IWebElement NumericBoxCurrency
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric2"));
            }
        }
        public IWebElement NumericBoxPhone
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric3"));
            }
        }       
        public IWebElement NumericBoxReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric5"));
            }
        }
        public IWebElement NumericBoxRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric6"));
            }
        }
        public IWebElement NumericBoxMax
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric7"));
            }
        }
        public IWebElement NumericBoxMin
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric8"));
            }
        }
        public IWebElement NumericBoxUnique
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric9"));
            }
        }
        public IWebElement NumericBoxDecimal
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric10"));
            }
        }
        public IWebElement NumericBoxNegative
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric11"));
            }
        }
        public IWebElement NumericBoxDonotpersist
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric12"));
            }
        }        
        public IWebElement NumericBoxHelpText
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric13"));
            }
        }
        public IWebElement NumericBoxTooltip
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric14"));
            }
        }
        


        public IWebElement SelectDate
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[2]/table/tbody/tr[1]/td[5]"));
            }
        } 
        public IWebElement Date
        {
            get
            {
                return this.driver.FindElement(By.Id("Date1"));
            }
        }
        public IWebElement Time
        {
            get
            {
                return this.driver.FindElement(By.Id("Date2"));
            }
        }
        public IWebElement DateTime
        {
            get
            {
                return this.driver.FindElement(By.Id("Date3"));
            }
        }
        public IWebElement DateTimeHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("Date4"));
            }
        }
        public IWebElement DateTimeReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("Date5"));
            }
        }
        public IWebElement DateTimeRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("Date6"));
            }
        }
        public IWebElement DateTimeautocomplete
        {
            get
            {
                return this.driver.FindElement(By.Id("Date7"));
            }
        }
        public IWebElement DateTimenullable
        {
            get
            {
                return this.driver.FindElement(By.Id("Date8"));
            }
        }
        public IWebElement DateTimePlaceholder
        {
            get
            {
                return this.driver.FindElement(By.Id("Date9"));
            }
        }
        public IWebElement DateTimeHelptext
        {
            get
            {
                return this.driver.FindElement(By.Id("Date10"));
            }
        }
        public IWebElement DateTimeToolTip
        {
            get
            {
                return this.driver.FindElement(By.Id("Date11"));
            }
        }



        public IWebElement BoolenSelectHidden
        {
            get
            {
                return this.driver.FindElement(By.XPath("cont_BooleanSelect1"));
            }
        }
        public IWebElement BoolenSelectToolTip
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect6Wraper']/div/button"));
            }
        }
        public IWebElement BoolenSelectDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect7Wraper']/div/button"));
            }
        }
        public IWebElement BoolenSelectTrueText
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect8Wraper']/div/button"));
            }
        }
        public IWebElement BoolenSelectTrueTextSelect
        {
            get//*[@id="WebForm_k8r8cuzt"]/div[6]/div/div/ul/li[1]/a/span
            {
                return this.driver.FindElement(By.XPath("//*[@class='dropdown-menu open dd_of_BooleanSelect8']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement BoolenSelectFalseText
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect9Wraper']/div/button"));
            }
        }
        public IWebElement BoolenSelectFalseTextSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='dd_of_BooleanSelect9']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement BoolenSelectHelptext
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect5Wraper']/div/button"));
            }
        }



        public IWebElement CheckBoxGroupHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup1"));
            }
        }
        public IWebElement CheckBoxGroupReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup2_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup3"));
            }
        }
        public IWebElement CheckBoxGroupDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup4_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupAllHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup5_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupAllReadonly
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup5_Rd1"));
            }
        }
        public IWebElement CheckBoxGroupAllDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup5_Rd2"));
            }
        }



        public IWebElement RadioButtonGroupHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioGroup1"));
            }
        }
        public IWebElement RadioButtonGroupReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup2_Rd0"));
            }
        }
        public IWebElement RadioButtonGroupRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup3_Rd0"));
            }
        }
        public IWebElement RadioButtonGroupDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup4_Rd0"));
            }
        }
        
        public IWebElement RadioButtonGroupHorizontalRender
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup5Wraper"));
            }
        }
        
        public IWebElement RadioButtonGroupIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup5Wraper"));
            }
        }
    }
}
