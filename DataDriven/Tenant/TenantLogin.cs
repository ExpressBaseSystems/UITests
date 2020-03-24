using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.DataDriven.Tenant
{
    public class TenantLogin : GetDataFromXML
    {
        public static List<EbTestItem> GetValueFromXml()
        {
            List<EbTestItem> TestCases = new List<EbTestItem>();
            string path = @"TestData\Tenant\LoginData.xml";
            GetDataFromXML d = new GetDataFromXML();
            TestCases = GetDataFromFile(path);
            return TestCases;
        }
    }
}
