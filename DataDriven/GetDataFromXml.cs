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

        public List<EbTestData> testDatas { get; set; }

        public EbTestItem()
        {
            testDatas = new List<EbTestData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbTestData item = testDatas.Find(e => e.Name == binder.Name);
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
            var doc = XDocument.Load(@"D:\ExpressBase\UITests\TestData\LoginData.xml");
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
                    testdata.testDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
