﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    public class UserLogOut
    {
        private IWebDriver driver;

        public UserLogOut(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ProfileImageDropDown
        {
            get
            {
                return this.driver.FindElement(By.ClassName("obj_dash_proimage_drp"));
            }
        }

        public IWebElement ProfileImageDropDownXpath
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"notificaionandprofile\"]/div"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"notificaionandprofile\"]/div/div/ul/li[4]/a"));
            }
        }
    }
}
