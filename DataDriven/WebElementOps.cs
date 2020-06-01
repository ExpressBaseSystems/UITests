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
        public void ExistsXpathClickable(IWebElement xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable((xpath)));
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
            wait.Until(ExpectedConditions.ElementExists(By.Name(name)));
        }

        public void ExistsTagName(string name)
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName(name)));
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
        
        public void SetValue(string Id, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('"+Id+"').value = '"+value+"'");
        }

        public string GetValue(string Id)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript("return document.querySelector('#"+Id+"').value");
        }

        public void ExecuteScripts(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        

        public object GetTableRowCountFromJSusingID(string id)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementById('"+id+"').rows.length);");
        }

        public object GetTableRowCountFromJSusingTag(string tag)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementsByTagName('" + tag + "')[0].rows.length);");
        }

        public object GetTableRowCountFromJS()
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementsByTagName('table')[0].rows.length);");
        }
    }
}
