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
        public  void ExistspresenceOfElementLocated(By xpath)
        {
             wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((xpath)));
        }

        public void ExistsId(string id)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id(id)));
        }

        public void ExistsLinkText(string text)
        {
            wait.Until(ExpectedConditions.ElementExists(By.LinkText(text)));
        }
        public void ExistsTextToBePresentInElement(IWebElement element, string text)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public void ExistsClass(string classname)
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(classname)));
        }
        public void PresenceOfAllElementsLocatedBy(string cssSelector)
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(cssSelector)));
        }

        public void ExistsName(string name)
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name(name)));
        }

        public void ExistsTagName(string name)
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName(name)));
        }
        public bool InvisibleWait(By we)
        {
           return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(we));
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

        public void ChangeStyleByXpath(IWebElement element, string attribute, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",element, attribute, value);
        }

        public void ChangeStyleByClassNameJQuery(string classname, string attribute, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("$('." + classname + "').attr('" + attribute + "', '" + value + "')");
        }

        public object GetValueFromJS(IWebElement element)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerHTML;", element);
        }
        public void DoubleClickUsingJS(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].dblclick();", element);
        }
        
        public void SetValue(string Id, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('"+Id+"').value = '"+value+"'");
        }

        public Boolean CheckForAttribute(string Id, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (Boolean)js.ExecuteScript("return document.getElementById('" + Id + "').hasAttribute('"+value+"')");
        }

        public void SetValueByTag(string tagname, string value, int id = 0)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByTagName('"+tagname+"')["+id+"].innerHTML = '"+value+"'");
        }

        public void SetQueryValue(string query, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('" + query+"').value = '"+value+"'");
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
        public void doubleClick(IWebElement webElement)
        {

            //For FF browser.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('dblclick',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", webElement);

            //For IE

            //((JavascriptExecutor)driver).executeScript("arguments[0].fireEvent('ondblclick');", webElement);

        }

        public string RadioButtonCheckValidator(string name)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript("return $('input[name="+name+"]:checked').val();");
        }

        public string GetValueById(string Id)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript("return document.getElementById('"+Id+ "').textContent");
        }

        public object GetTableRowCountFromJSusingID(string id)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementById('"+id+"').rows.length);");
        }

        public object GetTableRowCountFromJSusingTag(string tag, int id=0)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return (document.getElementsByTagName('" + tag + "')["+id+"].rows.length);");
        }

        public int GetTableRowCount(string xpath)
        {
            return driver.FindElements(By.XPath(xpath)).Count;
        }
        
    }
}
