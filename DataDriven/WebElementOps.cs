using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.DataDriven
{
    public class WebElementOps
    {
        IWebDriver driver;
        WebDriverWait wait;

        public WebElementOps(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void ExistsXpath(string xpath)
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }

        public void ExistsId(string id)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id(id)));
        }

        public void ExistsLinkText(string text)
        {
            wait.Until(ExpectedConditions.ElementExists(By.LinkText(text)));
        }

        public void ExistsClass(string classname)
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(classname)));
        }

        public void ExistsName(string name)
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(name)));
        }

        public bool IsWebElementPresent(IWebElement webelement)
        {
            try
            {
                bool f = webelement.Displayed;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ChangeStyle(string Id, string attribute, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('"+Id+"').setAttribute('"+attribute+"', '"+value+"')");
        }

        public object GetValueFromJS(IWebElement element)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerHTML;", element);
        }

        public object GetTableRowCountFromJS(string id)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementById('"+id+"').rows.length);");
        }

    }
}
