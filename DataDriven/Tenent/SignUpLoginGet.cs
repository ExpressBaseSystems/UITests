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

    public class EbTestItem : DynamicObject
    {
        public string Name { get; set; }

        public List<EbTestData> TestDatas { get; set; }

        public EbTestItem()
        {
            TestDatas = new List<EbTestData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbTestData item = TestDatas.Find(e => e.Name == binder.Name);
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


    public class GetDataFromXml
    {
        public static List<EbTestItem> GetTestValues()
        {
            var doc = XDocument.Load(@"E:\Expressbase.core\UITests\TestData\Tenent\LoginData.xml");
            List<EbTestItem> TestCases = new List<EbTestItem>();
            foreach (var testcase in doc.Descendants("test"))
            {
                string testname = testcase.Attribute("name").Value;
                EbTestItem testdata = new EbTestItem() { Name = testname };
                foreach (var child in testcase.Elements())
                {
                    EbTestData td = new EbTestData();
                    td.Name = child.Name.ToString();
                    td.Type = (EbTestDataTypes)Enum.Parse(typeof(EbTestDataTypes), child.Attribute("type").Value);
                    td.Value = child.Value;
                    testdata.TestDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
