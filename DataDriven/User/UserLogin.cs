using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace UITests.DataDriven.User
{
    public class UserLogin : GetDataFromXML
    {
        public static List<EbTestItem> GetValueFromXml()
        {
            List<EbTestItem> TestCases = new List<EbTestItem>();
            string path = @"TestData\User\LoginData.xml";
            GetDataFromXML d = new GetDataFromXML();
            TestCases = GetDataFromFile(path);
            return TestCases;
        }
    }
}
