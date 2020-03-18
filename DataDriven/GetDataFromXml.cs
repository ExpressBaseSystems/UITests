using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace UITests.DataDriven
{
    public enum EbTestDataTypes
    {
        String,
        Int,
        Decimal,
        Date,
        Datetime,
        Time
    }

    public class EbTestData
    {
        public string Name { get; set; }
        public EbTestDataTypes Type { get; set; }
        public dynamic Value { get; set; }
    }

    public class EbTestDataCollection : DynamicObject
    {
        private Dictionary<string, EbTestData> _dict = new Dictionary<string, EbTestData>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            result = _dict[name].Value;
            return true;
        }
    }

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
