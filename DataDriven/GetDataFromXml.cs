using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Dynamic;
using System.Linq;
using System.Xml;
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
        public static Dictionary<string, string> LoginTestValues(string file_loc, string test_name)
        {
            // string[] sitemaps = Directory.GetFiles(@"C:\Users\User\source\repos\EBSelenium\EBSelenium\TestData");

            Dictionary<string, string> dict = new Dictionary<string, string>();
            //foreach (string sitemap in sitemaps)
            //{            
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(file_loc);
                var root = xDoc.FirstChild.NextSibling;

                if (root.HasChildNodes)
                {
                    foreach (XmlNode childnode in root.ChildNodes)
                    {
                        if (childnode.Name == "test" && test_name == "test1" && childnode.Attributes["name"].Value.ToString() == test_name)
                        {
                            if (childnode.HasChildNodes)
                            {
                                foreach (XmlNode node in childnode)
                                {
                                    dict.Add(node.Name, node.InnerText);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception  : " + e.ToString());
            }
            return dict;
            //}
        }
    }
}
