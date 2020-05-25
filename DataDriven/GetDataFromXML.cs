using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace UITests.DataDriven
{

    public enum EbDataTypes
    {
        String,
        Int,
        Decimal,
        Date,
        Datetime,
        Time
    }

    public class EbXmlData
    {
        public string Name { get; set; }
        public EbDataTypes Type { get; set; }
        public dynamic Value { get; set; }
    }
    
    public class EbTestItem : DynamicObject
    {
        public string Name { get; set; }

        public List<EbXmlData> testDatas { get; set; }

        public EbTestItem()
        {
            testDatas = new List<EbXmlData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbXmlData item = testDatas.Find(e => e.Name == binder.Name);
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

    public class GetDataFromXML
    {
        public static List<EbTestItem> GetDataFromFile(string path)
        {
            var doc = XDocument.Load(path);
            List<EbTestItem> TestCases = new List<EbTestItem>();
            foreach (var testcase in doc.Descendants("test"))
            {
                string testname = testcase.Attribute("name").Value;
                EbTestItem testdata = new EbTestItem() { Name = testname };
                foreach (var child in testcase.Elements())
                {
                    EbXmlData td = new EbXmlData();
                    td.Name = child.Name.ToString();
                    td.Type = (EbDataTypes)Enum.Parse(typeof(EbDataTypes), child.Attribute("type").Value);
                    td.Value = child.Value;
                    testdata.testDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
