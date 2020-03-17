using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Xml.Linq;

namespace Selenium.DataDriven
{
    public class GetDataFromXml
    {
        public static Dictionary<string, string> LoginTestValues()
        {
            var doc = XDocument.Load(@"D:\Selenium\Selenium\TestData\login.xml");
            Dictionary<string, string> login = new Dictionary<string, string>();
            foreach (var credential in doc.Descendants("user"))
            {
                login.Add(credential.Attribute("username").Value, credential.Attribute("password").Value);
            }
            return login;
        }
    }
}
