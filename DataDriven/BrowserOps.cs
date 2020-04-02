﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UITests.DataDriven
{
    public class BrowserOps
    {
        IWebDriver driver;
        public void Init_Browser()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
        }

        public void Goto(string url)
        {
            driver.Url = url;
        }

        public void NewTab(string url)
        {
            String a = "window.open('"+url+"','_blank');";  // replace link with your desired link
            ((IJavaScriptExecutor)driver).ExecuteScript(a);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void Close()
        {
            driver.Quit();
        }

        public IWebDriver getDriver
        {
            get
            {
                return driver;
            }
        }
        public void implicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
