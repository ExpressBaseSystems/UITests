using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace UITests.DataDriven
{

    public enum EbTenentDataTypes
    {
        String,
        Int,
        Decimal,
        Date,
        Datetime,
        Time
    }

    public class EbTenentData
    {
        public string Name { get; set; }
        public EbTenentDataTypes Type { get; set; }
        public dynamic Value { get; set; }
    }

    public class EbTenentItem : DynamicObject
    {
        public string Name { get; set; }

        public List<EbTenentData> TenentDatas { get; set; }

        public EbTenentItem()
        {
            TenentDatas = new List<EbTenentData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbTenentData item = TenentDatas.Find(e => e.Name == binder.Name);
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


    public class GetTenentFromXml
    {
        public static List<EbTenentItem> GetTenentValues()
        {
            var doc = XDocument.Load(@"E:\Expressbase.core\UITests\TestData\Tenent\LoginData.xml");
            List<EbTenentItem> TestCases = new List<EbTenentItem>();
            foreach (var testcase in doc.Descendants("test"))
            {
                string testname = testcase.Attribute("name").Value;
                EbTenentItem testdata = new EbTenentItem() { Name = testname };
                foreach (var child in testcase.Elements())
                {
                    EbTenentData td = new EbTenentData();
                    td.Name = child.Name.ToString();
                    td.Type = (EbTenentDataTypes)Enum.Parse(typeof(EbTenentDataTypes), child.Attribute("type").Value);
                    td.Value = child.Value;
                    testdata.TenentDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
