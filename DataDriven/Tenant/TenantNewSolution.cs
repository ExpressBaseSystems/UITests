using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.DataDriven.Tenant
{
    public class TenantNewSolution : GetDataFromXML
    {
        public static List<EbTestItem> GetValueFromXml()
        {
            List<EbTestItem> TestCases = new List<EbTestItem>();
            string path = @"TestData\Tenant\SignupData.xml";
            TestCases = GetDataFromFile(path);
            return TestCases;
        }
    }
}
