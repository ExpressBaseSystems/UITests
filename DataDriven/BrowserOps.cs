using JSErrorCollector;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        WebDriverWait wait;
        string ConsoleErr = "";
        public void Init_Browser()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),options);
            driver.Manage().Window.Maximize();
        }

        public void Goto(string url)
        {
            GetConsoleErrors();
            driver.Url = url;
        }

        public void SwitchTo()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void NewTab(string url)
        {
            String a = "window.open('" + url + "','_blank');";  // replace link with your desired link
            ((IJavaScriptExecutor)driver).ExecuteScript(a);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(url);
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

        public WebDriverWait DriverWait()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            return wait;
        }

        public void UrlToBe(string url)
        {
            wait.Until(ExpectedConditions.UrlToBe(url));
        }               

        public void Refresh()
        {
            GetConsoleErrors();
            driver.Navigate().Refresh();
        }

        public void implicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void ClickableWait(IWebElement we)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(we));
        }
        
        public void GetConsoleErrors()
        {
            //List<LogEntry> logs = driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            //foreach (LogEntry log in logs)
            //{
            //    while (logs.Count > 0)
            //    {
            //        String logInfo = log.ToString();
            //        ConsoleErr = ConsoleErr + log.Message.ToString();
            //    }
            //    ConsoleErr = ConsoleErr + log.ToString();
            //}
            Console.WriteLine("GetConsoleErrors ;"+ Convert.ToString(driver));
            List<JavaScriptError> logs = JavaScriptError.ReadErrors(driver).ToList();
            foreach (var log in logs)
            {
                ConsoleErr = ConsoleErr + log.ToString();
            }
            Console.WriteLine("GetConsoleErrors : Finished");
        }

        public string ShowConsoleError()
        {
            return ConsoleErr;
        }

    }
}
