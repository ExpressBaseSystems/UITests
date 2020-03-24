using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace UITests.DataDriven
{

    public enum EbTenantDataTypes
    {
        String,
        Int,
        Decimal,
        Date,
        Datetime,
        Time
    }

    public class EbTenantData
    {
        public string Name { get; set; }
        public EbTenantDataTypes Type { get; set; }
        public dynamic Value { get; set; }
    }

    public class EbTenantItem : DynamicObject
    {
        public string Name { get; set; }

        public List<EbTenantData> TenantDatas { get; set; }

        public EbTenantItem()
        {
            TenantDatas = new List<EbTenantData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbTenantData item = TenantDatas.Find(e => e.Name == binder.Name);
            if (item == null)
            {
                result = null;
                //throw new Exception("Member Not Found : " + binder.Name);
            }
            else
            {
                result = item.Value;
            }
            return true;
        }
    }


    public class GetTenantFromXml
    {
        public static List<EbTenantItem> GetTenantValues()
        {
            var doc = XDocument.Load(@"E:\Expressbase.core\UITests\TestData\Tenant\LoginData.xml");
            List<EbTenantItem> TestCases = new List<EbTenantItem>();
            foreach (var testcase in doc.Descendants("test"))
            {
                string testname = testcase.Attribute("name").Value;
                EbTenantItem testdata = new EbTenantItem() { Name = testname };
                foreach (var child in testcase.Elements())
                {
                    EbTenantData td = new EbTenantData();
                    td.Name = child.Name.ToString();
                    td.Type = (EbTenantDataTypes)Enum.Parse(typeof(EbTenantDataTypes), child.Attribute("type").Value);
                    td.Value = child.Value;
                    testdata.TenantDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
