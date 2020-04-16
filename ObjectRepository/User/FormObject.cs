using OpenQA.Selenium;
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
                return this.driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[2]/table/tbody/tr[1]/td[1]/div"));
            }
        } 
        public IWebElement Date
        {
            get
            {
                return this.driver.FindElement(By.Id("date1"));
            }
        }
        public IWebElement Time
        {
            get
            {
                return this.driver.FindElement(By.Id("date2"));
            }
        }
        public IWebElement DateTime
        {
            get
            {
                return this.driver.FindElement(By.Id("date3"));
            }
        }
        public IWebElement DateTimeHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("date4"));
            }
        }
        public IWebElement DateTimeReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("date5"));
            }
        }
        public IWebElement DateTimeRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("date6"));
            }
        }
        public IWebElement DateTimeautocomplete
        {
            get
            {
                return this.driver.FindElement(By.Id("date7"));
            }
        }
        public IWebElement DateTimenullable
        {
            get
            {
                return this.driver.FindElement(By.Id("date8"));
            }
        }
        public IWebElement DateTimePlaceholder
        {
            get
            {
                return this.driver.FindElement(By.Id("date9"));
            }
        }
        public IWebElement DateTimeHelptext
        {
            get
            {
                return this.driver.FindElement(By.Id("date10"));
            }
        }
        public IWebElement DateTimeToolTip
        {
            get
            {
                return this.driver.FindElement(By.Id("date11"));
            }
        }
    }
}
